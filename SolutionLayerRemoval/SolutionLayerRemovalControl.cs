using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Workflow;
using SolutionLayerRemoval.Helpers;
using Microsoft.Xrm.Tooling.Connector;
using System.Diagnostics;
using Newtonsoft.Json.Linq;


namespace SolutionLayerRemoval
{
    public partial class SolutionLayerRemovalControl : PluginControlBase
    {
        private List<Entity> SavedQueries;
        private List<Entity> SystemForms;
        private List<Entity> WorkFlows;
        private List<Entity> AllSolutionComponent;
        private List<Entity> SelectedActiveLayers;
        private List<Entity> ActiveLayers;
        private Dictionary<int,Guid> ComponentIds;
        private Settings mySettings;
        public SolutionLayerRemovalControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plug-in
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
            ExecuteMethod(GetSolutions);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CancelWorker();
        }

        private void GetSolutions()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Managed Solutions",
                Work = (worker, args) =>
                {
                    QueryExpression queryExpression = new QueryExpression("solution");
                    queryExpression.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, true);
                    queryExpression.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
                    queryExpression.ColumnSet.AddColumn("uniquename");
                    queryExpression.Orders.Add(new OrderExpression("uniquename", OrderType.Ascending));
                    args.Result = Service.RetrieveMultiple(queryExpression);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    EntityCollection result = args.Result as EntityCollection;
                    lboxSolutions.Items.Add(new SolutionItem(new Entity
                    {
                        Id = Guid.Empty,
                        ["uniquename"] = "All Solutions",
                    }));
                    if (result != null)
                    {
                        foreach (var item in result.Entities)
                        {
                            lboxSolutions.Items.Add(new SolutionItem(item));
                        }
                    }
                    lboxSolutions.SelectedIndex = 0;
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void tsbtnLoadUmanagedComponents_Click(object sender, EventArgs e)
        {
            
            var selectedSolutionId = (lboxSolutions.SelectedItem as SolutionItem).Solution.Id;
            if (selectedSolutionId == Guid.Empty)
            {
                var confiratmion = MessageBox.Show($"Please note that the operation might take a long time, as it's going to check all Components{Environment.NewLine}Would you like to continue", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.No == confiratmion)
                {
                    return;
                }
            }
            LoadSolutionComponents(selectedSolutionId);
        }

        private void tsbtnRemoveActiveCustomizations_Click(object sender, EventArgs e)
        {
            SelectedActiveLayers = new List<Entity>();
            DataGridViewRowCollection rows = dataGridLayers.Rows;
            foreach (DataGridViewRow item  in rows)
            {
                if ((bool)item.Cells[1].Value)
                {
                    var id = new Guid(item.Cells[0].Value.ToString());
                    SelectedActiveLayers.Add(ActiveLayers.First(x => x.GetAttributeValue<Guid>("msdyn_componentid") == id));
                }
            }
            if (SelectedActiveLayers.Count == 0)
            {
                MessageBox.Show("You haven't select any component", "Error", MessageBoxButtons.OK);
                return;
            }
            ActiveCustomizationsRemoval();
        }
    }
}