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
                    while (hasMoreRecord && !CancelOperation)
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

     
    }
}
