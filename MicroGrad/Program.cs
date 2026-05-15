using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Windows.Forms;
using static Micrograd;

// Trace: builds set of all nodes and edges
public static class Draw
{
    static (HashSet<Value> nodes, HashSet<(Value, Value)> edges) Trace(Value root)
    {
        var nodes = new HashSet<Value>();
        var edges = new HashSet<(Value, Value)>();

        void Build(Value v)
        {
            if (!nodes.Contains(v))
            {
                nodes.Add(v);
                foreach (var child in v.Prev)
                {
                    edges.Add((child, v));
                    Build(child);
                }
            }
        }

        Build(root);
        return (nodes, edges);
    }

    // DrawDot: creates the graph visualization
    public static void DrawDot(Value root)
    {
        var (nodes, edges) = Trace(root);
        var graph = new Graph();
        graph.Attr.LayerDirection = LayerDirection.LR; // left to right

        foreach (var n in nodes)
        {
            string uid = n.GetHashCode().ToString();

            // rectangular node showing data and grad
            var node = graph.AddNode(uid);
            node.LabelText = $" {n.Label} |  data {n.Data:F4} |  grad {n.Grad:F4} ";
            node.Attr.Shape = Shape.Box;

            // if result of an operation, add an op node
            if (!string.IsNullOrEmpty(n.Op))
            {
                string opId = uid + n.Op;
                var opNode = graph.AddNode(opId);
                opNode.LabelText = n.Op;
                opNode.Attr.Shape = Shape.Circle;

                // connect op node to this node
                graph.AddEdge(opId, uid);
            }
        }

        foreach (var (n1, n2) in edges)
        {
            // connect n1 to the op node of n2
            string n1Id = n1.GetHashCode().ToString();
            string n2OpId = n2.GetHashCode().ToString() + n2.Op;
            graph.AddEdge(n1Id, n2OpId);
        }

        // Show in window
        var form = new Form { Width = 1000, Height = 400, Text = "MicroGrad" };
        var viewer = new GViewer { Graph = graph, Dock = DockStyle.Fill };
        form.Controls.Add(viewer);
        Application.Run(form);
    }
}