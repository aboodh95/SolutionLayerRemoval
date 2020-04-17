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
        public void LoadSolutionComponents(Guid SelectedSolutionId)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Solution Components",
                Work = (worker, args) =>
                {
                    int i = 1, pageCount = 5000;
                    string cookies = "";
                    bool hasMoreRecord = true;
                    AllSolutionComponent = new List<Entity>();
                    
                    while (hasMoreRecord)
                    {

                        QueryExpression queryExpression = new QueryExpression("solutioncomponent");
                        queryExpression.PageInfo = new PagingInfo
                        {
                            PageNumber = i++,
                            PagingCookie = cookies,
                            Count = pageCount,
                        };
                        if (SelectedSolutionId != Guid.Empty)
                        {
                            queryExpression.Criteria.AddCondition("solutionid", ConditionOperator.Equal, SelectedSolutionId);
                        }
                        //So far, the action of removing the layer will not work in component with Is Metadata field as Yes
                        queryExpression.Criteria.AddCondition("ismetadata", ConditionOperator.Equal, false);
                        queryExpression.ColumnSet.AddColumn("objectid");
                        queryExpression.ColumnSet.AddColumn("componenttype");
                        EntityCollection entityCollection = Service.RetrieveMultiple(queryExpression);
                        AllSolutionComponent.AddRange(entityCollection.Entities);
                        hasMoreRecord = entityCollection.MoreRecords;
                        cookies = entityCollection.PagingCookie;
                    }
                },
                PostWorkCallBack = LoadComponentLayer
            });
        }

        public void LoadComponentsDefinitions(RunWorkerCompletedEventArgs resultArgs)
        {
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
                PostWorkCallBack = (result)=>{
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
                            var attribute= JsonConvert.DeserializeObject<AttributeJSON>(item.GetAttributeValue<string>("msdyn_componentjson"));
                            if (attribute!= null && attribute.Attributes.Any(x => x.Key == "tablecolumnname"))
                            {
                                entityName = attribute.Attributes.First(x => x.Key == "tablecolumnname").Value;
                            }
                        }
                        ComponentIds.Add(rowIndex++, item.GetAttributeValue<Guid>("msdyn_componentid"));
                        this.dataGridLayers.Rows.Add(item.GetAttributeValue<Guid>("msdyn_componentid").ToString(), false, ComponentName, componentType, entityName, order, publisherName);
                    }
                }
            });
        }

    }
}
