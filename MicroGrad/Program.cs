using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Windows.Forms;

var graph = new Graph("micrograd");

// Node for 'a'
var a = graph.AddNode("a");
a.LabelText = "a | data 3.0000 | grad 2.0000";
a.Attr.Shape = Shape.Box;

// Node for 'b'
var b = graph.AddNode("b");
b.LabelText = "b | data 6.0000 | grad 1.0000";
b.Attr.Shape = Shape.Box;

// Operation node '+'
var plus = graph.AddNode("+");
plus.LabelText = "+";
plus.Attr.Shape = Shape.Circle;

// Edges
graph.AddEdge("a", "+");
graph.AddEdge("+", "b");

// Display
var form = new Form { Width = 800, Height = 400 };
var viewer = new GViewer { Graph = graph, Dock = DockStyle.Fill };
form.Controls.Add(viewer);
Application.Run(form);