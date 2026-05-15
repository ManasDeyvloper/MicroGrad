
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using Microsoft.Msagl.GraphViewerGdi;
using ScottPlot;

public class Micrograd
{
    public static void Main(string[] args)
    {
        Value x1 = new Value(2.0, label: "x1");
        Value x2 = new Value(0.0, label: "x2");
        Value w1 = new Value(-3.0, label: "w1");
        Value w2 = new Value(1.0, label: "w2");
        Value b = new Value(1.0, label: "b");
        // Value b2 = Value.tanh(b); b2.Label = "b2";
        // Draw.DrawDot(b2);

        Value x1w1 = x1 * w1; x1w1.Label = "x1 * w1";
        Value x2w2 = x2 * w2; x2w2.Label = "x2 * w2";
        Value x1w1x2w1 = x1w1 + x2w2; x1w1x2w1.Label = "x1 * w1 + x2 * w2";
        Value L1 = x1w1x2w1 + b; L1.Label = "L1";
        Value L2 = Value.tanh(L1); L2.Label = "L2";
        Draw.DrawDot(L2);
    }
    public class Value
    {
        public string Label;
        public double Data;
        public double Grad;
        public HashSet<Value> Prev;
        public string Op;

        public Value(double data, HashSet<Value>? prev = null, string op = "", string label = "")
        {
            this.Label = label;
            this.Data = data;
            this.Grad = 0.0;
            this.Prev = prev ?? [];
            this.Op = op;
        }

        public void Print()
        {
            Console.WriteLine($"Value(label={Label}, data={Data})");
        }

        public static Value operator +(Value a, Value b)
        {
            return new Value(a.Data + b.Data, new HashSet<Value> { a, b }, op: "+");
        }

        public static Value operator *(Value a, Value b)
        {
            return new Value(a.Data * b.Data, new HashSet<Value> { a, b }, op: "*");
        }

        public static Value tanh(Value a)
        {
            double t = Math.Tanh(a.Data);
            return new Value(t, new HashSet<Value> { a }, op: " tanh");
        }



    }


}
// }
