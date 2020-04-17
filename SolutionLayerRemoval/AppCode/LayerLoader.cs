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
        public void LoadComponentLayer(RunWorkerCompletedEventArgs args)
        {
            WorkAsync(new WorkAsyncInfo()

            {
                Message = "Loading Layers",
                IsCancelable = true,
                Work = (bgworker, workargs) =>
                {
                    var sw = Stopwatch.StartNew();
                    var total = AllSolutionComponent.Count;
                    var waitnow = false;
                    var waitcur = 0;
                    var current = 0;
                    var loaded = 0;
                    var failed = 0;
                    var results = new List<RetrieveMultipleResponse>();
                    var batch = new ExecuteMultipleRequest
                    {
                        Settings = new ExecuteMultipleSettings { ContinueOnError = true, ReturnResponses = true },
                        Requests = new OrganizationRequestCollection()
                    };
                    batch = new ExecuteMultipleRequest
                    {
                        Settings = new ExecuteMultipleSettings { ContinueOnError = true, ReturnResponses = true },
                        Requests = new OrganizationRequestCollection()
                    };

                    foreach (var component in AllSolutionComponent)
                    {
                        current++;
                        var pct = 100 * current / total;
                        if (component.GetAttributeValue<OptionSetValue>("componenttype") != null)
                        {
                            QueryExpression queryExpression = new QueryExpression("msdyn_componentlayer");
                            queryExpression.Criteria.AddCondition("msdyn_solutionname", ConditionOperator.Equal, "Active");
                            queryExpression.Criteria.AddCondition("msdyn_solutioncomponentname", ConditionOperator.Equal, ((ComponentType)component.GetAttributeValue<OptionSetValue>("componenttype").Value).ToString());
                            queryExpression.Criteria.AddCondition("msdyn_componentid", ConditionOperator.Equal, component.GetAttributeValue<Guid>("objectid").ToString());
                            queryExpression.ColumnSet = new ColumnSet(true);
                            RetrieveMultipleRequest retrieveMultipleRequest = new RetrieveMultipleRequest
                            {
                                Query = queryExpression,
                            };
                            batch.Requests.Add(retrieveMultipleRequest);
                            if (batch.Requests.Count == 1000 || current == total)
                            {
                                bgworker.ReportProgress(pct, $"Retrieving Components Active Layers {current} of {total}");
                                var result = Service.Execute(batch) as ExecuteMultipleResponse;
                                loaded += batch.Requests.Count;
                                results.AddRange(result.Responses.Select(x => x.Response as RetrieveMultipleResponse));
                                batch.Requests.Clear();
                                batch = new ExecuteMultipleRequest
                                {
                                    Settings = new ExecuteMultipleSettings { ContinueOnError = true, ReturnResponses = true },
                                    Requests = new OrganizationRequestCollection()
                                };
                                waitnow = true;
                            }
                        }
                        else
                        {

                        }
                    }
                    sw.Stop();
                    workargs.Result = results;
                },
                PostWorkCallBack =LoadComponentsDefinitions,
                ProgressChanged = (changeargs) =>
                {
                    SetWorkingMessage(changeargs.UserState.ToString());
                }
            });
        }
    }
}
