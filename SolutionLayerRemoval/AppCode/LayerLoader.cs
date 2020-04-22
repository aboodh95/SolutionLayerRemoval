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
using Newtonsoft.Json;

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
                    if (CancelOperation)
                    {
                        OperationRunning = false;
                        return;
                    }
                    var sw = Stopwatch.StartNew();
                    var total = AllSolutionComponent.Count;
                    var current = 0;
                    var loaded = 0;
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
                            }
                            if (CancelOperation)
                            {
                                break;
                            }
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
        public void LoadComponentsDefinitions(RunWorkerCompletedEventArgs resultArgs)
        {
            if (CancelOperation)
            {
                        OperationRunning = false;
                return;
            }
            ComponentIds = new Dictionary<int, Guid>();
            ActiveLayers = new List<Entity>();
            dataGridLayers.Rows.Clear();
            var results = resultArgs.Result as List<RetrieveMultipleResponse>;
            int rowIndex = 0;
            if (results.Count == 0)
            {
                MessageBox.Show("No active layer on this solution components", "Info");
                return;
            }

            ActiveLayers.AddRange(results.Where(x => x.EntityCollection.Entities.Count != 0).Select(x => x.EntityCollection.Entities[0]).ToList());
            var activeLayersComponent = AllSolutionComponent
                .Where(x =>
                ActiveLayers.Any(y => y.GetAttributeValue<Guid>("msdyn_componentid") == x.GetAttributeValue<Guid>("objectid")) &&
                x.GetAttributeValue<OptionSetValue>("componenttype") != null &&
                (x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.Workflow ||
                 x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.Attribute ||
                 x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SavedQuery ||
                 x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SystemForm));
            SavedQueries = new List<Entity>();
            SystemForms = new List<Entity>();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Components Definitions",
                Work = (worker, args) =>
                {
                    //Load the entity name
                    if (activeLayersComponent.Any(x => x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SavedQuery))
                    {
                        QueryExpression queryExpression = new QueryExpression("savedquery");
                        queryExpression.Criteria.AddCondition("savedqueryid", ConditionOperator.In,
                            activeLayersComponent.Where(x => x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SavedQuery).Select(x => x.GetAttributeValue<Guid>("objectid").ToString()).ToArray());
                        queryExpression.ColumnSet.AddColumn("returnedtypecode");
                        SavedQueries = Service.RetrieveMultiple(queryExpression).Entities.ToList();
                    }
                    if (activeLayersComponent.Any(x => x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SystemForm))
                    {
                        QueryExpression queryExpression = new QueryExpression("systemform");
                        queryExpression.Criteria.AddCondition("formid", ConditionOperator.In,
                            activeLayersComponent.Where(x => x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SystemForm).Select(x => x.GetAttributeValue<Guid>("objectid").ToString()).ToArray());
                        queryExpression.ColumnSet.AddColumn("objecttypecode");
                        SystemForms = Service.RetrieveMultiple(queryExpression).Entities.ToList();
                    }
                    if (activeLayersComponent.Any(x => x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.Workflow))
                    {
                        QueryExpression queryExpression = new QueryExpression("workflow");
                        queryExpression.Criteria.AddCondition("workflowid", ConditionOperator.In,
                            activeLayersComponent.Where(x => x.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.Workflow).Select(x => x.GetAttributeValue<Guid>("objectid").ToString()).ToArray());
                        queryExpression.ColumnSet.AddColumn("primaryentity");
                        WorkFlows = Service.RetrieveMultiple(queryExpression).Entities.ToList();
                    }
                    
                },
                PostWorkCallBack = (result) => {
                    ActiveLayers = ActiveLayers.OrderBy(x => x.GetAttributeValue<string>("msdyn_solutioncomponenttype")).ToList();
                    foreach (var item in ActiveLayers)
                    {
                        var ComponentName = item.GetAttributeValue<string>("msdyn_name");
                        var componentType = item.GetAttributeValue<string>("msdyn_solutioncomponentname");
                        int order = item.GetAttributeValue<int>("msdyn_order");
                        var entityName = "";
                        string publisherName = item.GetAttributeValue<string>("msdyn_publishername");
                        var component = AllSolutionComponent.FirstOrDefault(x => x.GetAttributeValue<Guid>("objectid") == item.GetAttributeValue<Guid>("msdyn_componentid"));

                        //Set the entity name
                        if (component.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SavedQuery)
                        {
                            entityName = SavedQueries.FirstOrDefault(x => x.Id == component.GetAttributeValue<Guid>("objectid")).GetAttributeValue<string>("returnedtypecode");
                        }
                        if (component.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.SystemForm)
                        {
                            entityName = SystemForms.FirstOrDefault(x => x.Id == component.GetAttributeValue<Guid>("objectid")).GetAttributeValue<string>("objecttypecode");
                        }
                        if (component.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.Workflow)
                        {
                            entityName = WorkFlows.FirstOrDefault(x => x.Id == component.GetAttributeValue<Guid>("objectid")).GetAttributeValue<string>("primaryentity");
                        }
                        if (component.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.Entity)
                        {
                            entityName = ComponentName;
                        }
                        if (component.GetAttributeValue<OptionSetValue>("componenttype").Value == (int)ComponentType.Attribute)
                        {
                            var attribute = JsonConvert.DeserializeObject<AttributeJSON>(item.GetAttributeValue<string>("msdyn_componentjson"));
                            if (attribute != null && attribute.Attributes.Any(x => x.Key == "tablecolumnname"))
                            {
                                entityName = attribute.Attributes.First(x => x.Key == "tablecolumnname").Value;
                            }
                        }
                        ComponentIds.Add(rowIndex++, item.GetAttributeValue<Guid>("msdyn_componentid"));
                        this.dataGridLayers.Rows.Add(item.GetAttributeValue<Guid>("msdyn_componentid").ToString(), false, ComponentName, componentType, entityName, order, publisherName);
                    }
                    OperationRunning = false;
                }
            });
        }

    }
}
