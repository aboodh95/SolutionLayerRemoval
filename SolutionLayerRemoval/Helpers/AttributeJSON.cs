using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayerRemoval.Helpers
{

    public class AttributeJSON
    {
        public string LogicalName { get; set; }
        public string Id { get; set; }
        public List<KeyValuePair<string,string>> Attributes { get; set; }
        public object EntityState { get; set; }
        public List<object> FormattedValues { get; set; }
        public List<object> RelatedEntities { get; set; }
        public object RowVersion { get; set; }
        public List<object> KeyAttributes { get; set; }
    }
}
