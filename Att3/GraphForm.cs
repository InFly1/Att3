using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using GraphDraw;
namespace Att3
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }
        GraphD<int> graph;
        private void GraphForm_Load(object sender, EventArgs e)
        {
            select.SelectedIndex = 0;
            graph = new GraphD<int>(Image.Size);
        }
        Node<NodeD<int>> selected = null;
        List<int> was = new List<int>();
        private int GetNumber()
        {
            int i = 0;
            while (was.Contains(i))
            {
                i++;
            }
            was.Add(i);
            return i;
        }

        private void select_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = null;
            if (select.SelectedIndex  != 2)
                GetDist.Visible = false;
            else
                GetDist.Visible = true;
        }

        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            switch (select.SelectedIndex)
            {
                case 0:
                    if(graph.PlaceFree(e.X,e.Y))
                    graph.graph.Nodes.Add(new Node<NodeD<int>>(new NodeD<int>(GetNumber(), e.Location)));
                    Image.Image = graph.Draw();
                    break;
                case 1:
                    selected = graph.GetNode(e.X, e.Y);
                    if(selected!=null)
                    {
                        selected.RemoveEdges();
                        graph.graph.Nodes.Remove(selected);
                        was.Remove(selected.Value.Value);
                        selected = null;
                    }
                    Image.Image = graph.Draw();
                    break;
                case 2:
                    if(selected == null)
                        selected = graph.GetNode(e.X, e.Y);
                    else
                    {
                        Node<NodeD<int>> T = graph.GetNode(e.X, e.Y);
                        if (T != null && T!= selected)
                        {
                            selected.AddEdgeTo(T,(int)GetDist.Value);
                            Image.Image = graph.Draw();
                        }
                        selected = null;
                    }
                    break;
                case 3:
                    if (selected == null)
                        selected = graph.GetNode(e.X, e.Y);
                    else
                    {
                        Node<NodeD<int>> T = graph.GetNode(e.X, e.Y);
                        if (T != null&&T!=selected)
                        {
                            selected.RemoveEdgeTo(T);
                        }
                        selected = null;
                        Image.Image = graph.Draw();
                    }
                    break;

            }
        }

        private void GetWayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Node<NodeD<int>>> Way = graph.graph.GetWay();
                StringBuilder sb = new StringBuilder();
                foreach (var item in Way)
                {
                    sb.Append(item.Value.Value.ToString());
                    sb.Append(" ");
                }
                MessageBox.Show(sb.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("невозможно","Error");
            }
        }
    }
}
