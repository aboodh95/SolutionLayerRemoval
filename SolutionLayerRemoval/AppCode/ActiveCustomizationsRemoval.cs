using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System.Diagnostics;
using SolutionLayerRemoval.Helpers;

namespace SolutionLayerRemoval
{

    public partial class SolutionLayerRemovalControl
    {
        public void RemoveActiveCustomizations()
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Removing Active Customizations",
                IsCancelable = true,
                Work = (bgworker, workargs) =>
                {
             
                    var sw = Stopwatch.StartNew();
                    var total = SelectedActiveLayers.Count;
                    var current = 0;
                    var removedCustomizations = new List<Entity>();
                    foreach (var component in SelectedActiveLayers)
                    {
                        current++;
                        var pct = 100 * current / total;
                        try
                        {
                            var request = new OrganizationRequest("RemoveActiveCustomizations");
                            request.Parameters["SolutionComponentName"] = component.GetAttributeValue<string>("msdyn_solutioncomponentname");
                            request.Parameters["ComponentId"] = component.GetAttributeValue<Guid>("msdyn_componentid");
                            Service.Execute(request);
                            bgworker.ReportProgress(pct, $"Removing Active Customizations {current} of {total}");
                            removedCustomizations.Add(component);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        if (CancelOperation)
                        {
                            break;
                        }
                    }
                    sw.Stop();
                },
                PostWorkCallBack = (result) => {
                    var selectedSolutionId = (lboxSolutions.SelectedItem as SolutionItem).Solution.Id;
                    LoadSolutionComponents(selectedSolutionId);
                },
                ProgressChanged = (changeargs) =>
                {
                    SetWorkingMessage(changeargs.UserState.ToString());
                }
            });
        }


    }
}
