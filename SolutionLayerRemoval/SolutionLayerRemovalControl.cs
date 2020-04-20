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
using XrmToolBox.Extensibility.Interfaces;
using XrmToolBox.Extensibility.Args;
using SolutionLayerRemoval.Forms;

namespace SolutionLayerRemoval
{
   public partial class SolutionLayerRemovalControl : PluginControlBase, IPayPalPlugin, IAboutPlugin, IGitHubPlugin
    {
        private List<Entity> SavedQueries;
        private List<Entity> SystemForms;
        private List<Entity> WorkFlows;
        private List<Entity> AllSolutionComponent;
        private List<Entity> SelectedActiveLayers;
        private List<Entity> ActiveLayers;
        private Dictionary<int,Guid> ComponentIds;
        private Settings mySettings;
        private bool OperationRunning = false;
        private bool CancelOperation = false;

        public string DonationDescription => "Donate for me to do more wonderful tools :)";

        public string EmailAccount => "abod.h95@gmail.com";

        public string RepositoryName => "SolutionLayerRemoval";

        public string UserName => "aboodh95";

        public SolutionLayerRemovalControl()
        {
            InitializeComponent();
        }
        private void SolutionLayerRemovalControl_Load(object sender, EventArgs e)
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
            if (Service == null || ConnectionDetail == null || ConnectionDetail.OrganizationDataServiceUrl == null)
            {
                MessageBox.Show("You have to connection to an environment before loading the solutions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (OperationRunning)
            {
                MessageBox.Show("An operation is already running, pleas wait till it's finish", "Info");
                return;
            }
            var selectedSolutionId = (lboxSolutions.SelectedItem as SolutionItem).Solution.Id;
            if (selectedSolutionId == Guid.Empty)
            {
                var confiratmion = MessageBox.Show($"Please note that the operation might take a long time, as it's going to check all Components{Environment.NewLine}Would you like to continue", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.No == confiratmion)
                {
                    return;
                }
            }
            OperationRunning = true;
            CancelOperation = false;
            LoadSolutionComponents(selectedSolutionId);
        }

        private void tsbtnRemoveActiveCustomizations_Click(object sender, EventArgs e)
        {
            if (Service == null || ConnectionDetail == null || ConnectionDetail.OrganizationDataServiceUrl == null)
            {
                MessageBox.Show("You have to connection to an environment before loading the solutions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (OperationRunning)
            {
                MessageBox.Show("An operation is already running, pleas wait till it's finish", "Info");
                return;
            }
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
            OperationRunning = true;
            CancelOperation = false;
            RemoveActiveCustomizations();
        }

        public void ShowAboutDialog()
        {
            var about = new AboutBox
            {
                StartPosition = FormStartPosition.CenterParent
            };
            about.ShowDialog();
            about.Dispose();
        }

        private void btnLoadSolutions_Click(object sender, EventArgs e)
        {
            if (Service == null || ConnectionDetail == null || ConnectionDetail.OrganizationDataServiceUrl == null)
            {
                MessageBox.Show("You have to connection to an environment before loading the solutions","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (OperationRunning)
            {
                MessageBox.Show("An operation is already running, pleas wait till it's finish","Info");
                return;
            }
            CancelOperation = false;
            OperationRunning = true;
            ExecuteMethod(LoadSolutions);
        }

        private void tsbCancelOperation_Click(object sender, EventArgs e)
        {
            CancelOperation = true;
        }
    }
}