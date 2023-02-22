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
        private void LoadSolutions()
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
                    lboxSolutions.Items.Clear();
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
                    OperationRunning = false;
                }
            });
        }

        private void SearchSolutions(string search)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Managed Solutions",
                Work = (worker, args) =>
                {
                    QueryExpression queryExpression = new QueryExpression("solution");
                    queryExpression.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, true);
                    queryExpression.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
                    queryExpression.Criteria.AddCondition("uniquename", ConditionOperator.Like, "%" + search + "%");
                    queryExpression.ColumnSet.AddColumn("uniquename");
                    queryExpression.ColumnSet.AddColumn("version");
                    queryExpression.Orders.Add(new OrderExpression("uniquename", OrderType.Ascending));
                    args.Result = Service.RetrieveMultiple(queryExpression);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    lboxSolutions.Items.Clear();
                    EntityCollection result = args.Result as EntityCollection;
                    lboxSolutions.Items.Add(new SolutionItem(new Entity
                    {
                        Id = Guid.Empty,
                        ["uniquename"] = "All Solutions",
                        ["version"] = "0.0.0.0"
                    }));
                    if (result != null)
                    {
                        foreach (var item in result.Entities)
                        {
                            lboxSolutions.Items.Add(new SolutionItem(item));
                        }
                    }
                    lboxSolutions.SelectedIndex = 0;
                    OperationRunning = false;
                }
            });
        }
    }
}
