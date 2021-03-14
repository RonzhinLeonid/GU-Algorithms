using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafLibrary
{
    public class Node //Вершина
    {
        public char Value { get; set; }
        public List<Node> Edges { get; set; } //исходящие связи
        public Node(char value)
        {
            Value = value;
            Edges = new List<Node>();
        }
        public override bool Equals(object obj)
        {
            var user = obj as Node;

            if (user == null)
                return false;

            return Value == user.Value;
        }

    }
}
