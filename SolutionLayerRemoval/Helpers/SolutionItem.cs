using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace SolutionLayerRemoval.Helpers
{
    public class SolutionItem
    {
        public Entity Solution { get; set; }
        public SolutionItem(Entity solution)
        {
            this.Solution = solution;
        }

        public override string ToString()
        {
            return Solution.GetAttributeValue<string>("uniquename");
        }
    }
}
