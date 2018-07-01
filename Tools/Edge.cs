using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Edge<T>
    {
        public Node<T> First { get; set; }
        public Node<T> Second { get; set; }
        public int Dist { get; set; }
        protected bool was;
        public bool Was
        {
            get => was;
            set
            {
                was = value;
                for (int i = 0; i < Second.Edges.Count; i++)
                    if(Second.Edges[i].Second == First)
                    {
                        if(Second.Edges[i].was != value)
                        {
                            Second.Edges[i].was = value;
                            return;
                        }
                    }
            }
        }
        public Edge(Node<T> first, Node<T> second, int value = 0)
        {
            First = first;
            Second = second;
            Dist = value;
        }

    }
}
