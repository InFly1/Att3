using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node<T>>();
        }
        public void SetNodeClear()
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Was = false;
            }
        }//очистка
        public void SetEdgeWasFalse()
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].SetEdgeWasFalse();
            }
        }//очистка
        public List<Node<T>> GetWay() //основная задача
        {
            if (Nodes.Count != 0 && Connected())
            {
                int Max = 0;
                foreach (var item in Nodes)
                    Max += item.Edges.Count;
                Max *= 2;
                SetNodeClear();
                return Nodes[0].getWay(Nodes.Count, Nodes[0], 0, out int result, Max, 0);
            }
            else
                throw new InvalidOperationException();
        }
        private List<Node<T>> Way;
        private int Dist = -1;
        public bool Connected()
        {
            SetNodeClear();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(Nodes[0]);
            int Count = 1;
            while (queue.Count != 0)
            {
                Node<T> node = queue.Dequeue();
                node.Was = true;
                
                for (int i = 0; i < node.Edges.Count; i++)
                    if (!node.Edges[i].Second.Was)
                    {
                        queue.Enqueue(node.Edges[i].Second);
                        Count++;
                        node.Edges[i].Second.Was = true;
                    }
            }
            return Count == Nodes.Count;
        }//проверка связанности
    }
}
