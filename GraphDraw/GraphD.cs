using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using System.Drawing;

namespace GraphDraw
{
    public struct NodeD<T>
    {
        public T Value { get; set; }
        public Point point { get; set; }

        public NodeD(T value, Point point) : this()
        {
            Value = value;
            this.point = point;
        }
    }
    public class GraphD<T>
    {
        public Graph<NodeD<T>> graph { get; set; }
        public Size size { get; set; }
        Bitmap Image;
        Graphics G;
        int Rad = 30;
        public Bitmap Draw()
        {
            Image = new Bitmap(size.Width, size.Height);
            G = Graphics.FromImage(Image);
            graph.SetEdgeWasFalse();
            for (int i = 0; i < graph.Nodes.Count; i++)
                for (int j = 0; j < graph.Nodes[i].Edges.Count; j++)
                    if(!graph.Nodes[i].Edges[j].Was)
                    {
                        G.DrawLine(Pens.Black, graph.Nodes[i].Value.point, graph.Nodes[i].Edges[j].Second.Value.point);
                        graph.Nodes[i].Edges[j].Was = true;
                        G.DrawString(graph.Nodes[i].Edges[j].Dist.ToString(), new Font("Microsoft Sans Serif", 19), Brushes.Green,
                            (graph.Nodes[i].Value.point.X + graph.Nodes[i].Edges[j].Second.Value.point.X) / 2, (graph.Nodes[i].Value.point.Y + graph.Nodes[i].Edges[j].Second.Value.point.Y) / 2 );
                    }
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                G.FillEllipse(Brushes.Red, graph.Nodes[i].Value.point.X - Rad, graph.Nodes[i].Value.point.Y - Rad, 2 * Rad, 2 * Rad);
                float size = 0;
                string print = graph.Nodes[i].Value.Value.ToString();
                do
                {
                    size += (float)0.2;
                }
                while (G.MeasureString(print, new Font("Microsoft Sans Serif", size)).Width < Rad);
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                G.DrawString(print, new Font("Microsoft Sans Serif", size), Brushes.Black, new Rectangle(graph.Nodes[i].Value.point.X - Rad, graph.Nodes[i].Value.point.Y - Rad, 2 * Rad, 2 * Rad), sf);
            }
            return Image;
        }
        public Node<NodeD<T>> GetNode(int X, int Y) => CheckDist(X, Y, Rad);
        private Node<NodeD<T>> CheckDist(int X, int Y, int r)
        {
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (Math.Pow(graph.Nodes[i].Value.point.X - X, 2) + Math.Pow(graph.Nodes[i].Value.point.Y - Y, 2) < r*r)
                    return graph.Nodes[i];
            }
            return null;
        }
        public bool PlaceFree(int X, int Y) => CheckDist(X, Y, 4 * Rad) == null;

        public GraphD(Size size)
        {
            this.size = size;
            graph = new Graph<NodeD<T>>();
        }
    }
}
