using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Edges { get; set; }
        public void AddEdgeTo(Node<T> second, int value)
        {
            if (second == this)
                return;
            for (int i = 0; i < Edges.Count; i++)
                if (Edges[i].Second == second)
                    return;
            Edges.Add(new Edge<T>(this, second,value));
            second.Edges.Add(new Edge<T>(second, this, value));
        }
        public bool Was { get; set; }
        public void RemoveEdgeTo(Node<T> second)
        {
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].Second == second)
                {
                    Edges.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < second.Edges.Count; i++)
            {
                if(second.Edges[i].Second == this)
                {
                    second.Edges.RemoveAt(i);
                    break;
                }
            }
        }
        public void SetEdgeWasFalse()
        {
            for (int i = 0; i < Edges.Count; i++)
            {
                Edges[i].Was = false;
            }
        }
        public Node(T value)
        {
            Value = value;
            Edges = new List<Edge<T>>();
        }
        public void RemoveEdges()
        {
            for (int i = 0; i < Edges.Count;)
            {
                Edges[i].Second.RemoveEdgeTo(this);
            }
        }
        internal List<Node<T>> getWay(int NeedCount, Node<T> start, int Dist, out int result, int Max, int currnet)
        {
            result = 0;
            if (currnet == Max)
                return null;
            if (NeedCount == 0 && start == this&& Dist<=100)
                return new List<Node<T>>() { this };
            if (Dist >= 100)
                return null;
            bool Added = !Was;
            Was = true;
            List<Node<T>> BestWay = null;
            foreach (var item in Edges)
            {
                List<Node<T>> Way = item.Second.getWay(NeedCount - (Added ? 1 : 0), start, Dist + item.Dist, out int resultT, Max, currnet+1);
                resultT += item.Dist;
                if(Way!= null &&  (BestWay == null|| resultT<result))
                {
                    BestWay = Way;
                    result = resultT;
                }
            }
            if (Added)
                Was = false;
            if (BestWay != null)
                BestWay.Add(this);
            return BestWay;
        }
    }
}
