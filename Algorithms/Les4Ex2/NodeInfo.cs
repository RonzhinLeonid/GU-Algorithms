using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les4Ex2
{
    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
        public override bool Equals(object obj)
        {
            var node = obj as NodeInfo;

            if (node == null)
                return false;

            return (node.Node == Node && node.Depth == Depth);
        }
    }
}
