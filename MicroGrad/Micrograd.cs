class Micrograd
{
    static void Main(string[] args)
    {
        Value a = new Value(2.0);
        Value b = new Value(3.0);
        Value c = new Value(10.0);
        Value d = a * b;
        Value e = a * b + c;
        e.Print();
        foreach (var child in e.children)
        {
            child.Print();
            Console.WriteLine(child.op);
        }
    }
    public class Value
    {
        public double data;
        public double grad;
        public HashSet<Value> children;
        public string op;

        public Value(double data, HashSet<Value>? children = null, string op = "")
        {
            this.data = data;
            this.grad = 0.0;
            this.children = children ?? [];
            this.op = op;
        }

        public void Print()
        {
            Console.WriteLine($"Value(data={data})");
        }

        public static Value operator +(Value a, Value b)
        {
            return new Value(a.data + b.data, new HashSet<Value> { a, b }, op: "+");
        }

        public static Value operator *(Value a, Value b)
        {
            return new Value(a.data * b.data, new HashSet<Value> { a, b }, op: "*");
        }
    }


}
// }
