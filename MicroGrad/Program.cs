// using System.Windows.Forms;
// using ScottPlot;

// // 1. Generate data points
// double[] xs = ScottPlot.Generate.Range(-10, 10, 0.1);
// double[] ys = xs.Select(x => x * x).ToArray(); // y = x²

// // 2. Plot it
// var form = new Form { Width = 800, Height = 600, Text = "Function Plot" };
// var formsPlot = new ScottPlot.WinForms.FormsPlot { Dock = DockStyle.Fill };
// form.Controls.Add(formsPlot);

// formsPlot.Plot.Add.Scatter(xs, ys);
// formsPlot.Refresh();

// Application.Run(form);