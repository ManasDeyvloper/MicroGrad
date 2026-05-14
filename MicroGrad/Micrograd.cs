
using System.Windows.Forms;
using Microsoft.Msagl.GraphViewerGdi;
using ScottPlot;

public class Micrograd
{
    public static void Main(string[] args)
    {
        Value a = new Value( 2.0,label:"a");
        Value b = new Value( 3.0,label:"b");
        Value c = new Value( 10.0,label:"c");
        
        Value d = a * b; d.Label = "d";

        Value e = d + c; e.Label = "e";
       
       Draw.DrawDot(e);
    }
    public class Value
    {
        public string Label;
        public double Data;
        public double Grad;
        public HashSet<Value> Prev;
        public string Op;

        public Value( double data, HashSet<Value>? prev = null, string op = "",string label = "")
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
         


    }


}
// }
