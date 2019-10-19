using System;

namespace GraphLesko
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertex[] vertex = { new Vertex() {data = "Zero vertex",    status = 0 },
                                new Vertex() {data = "First vertex",   status = 0 },
                                new Vertex() {data = "Second vertex",    status = 0 },
                                new Vertex() {data = "Third vertex",    status = 0 },
                                new Vertex() {data = "Fourth vertex",    status = 0 },
                                new Vertex() {data = "Fifth vertex",    status = 0 },
                                new Vertex() {data = "Sixth vertex",  status = 0 }
                              };
            vertex[0].vertices.Add(vertex[1]);
            vertex[0].vertices.Add(vertex[2]);

            vertex[1].vertices.Add(vertex[3]);
            vertex[1].vertices.Add(vertex[4]);

            vertex[2].vertices.Add(vertex[5]);

            vertex[3].vertices.Add(vertex[6]);

            VertexLocator provider = new VertexLocator();

            Observer observer1 = new Observer("SomeName");
            Observer observer2 = new Observer("NASA");

            observer1.Subscribe(provider);
            observer2.Subscribe(provider);

            Graph graph = new Graph(vertex, new BreadthTraversal());
            foreach (var item in graph)
            {
                Console.WriteLine(item.data);
                if (item.vertices.Count.Equals(0))
                { 
                    provider.SendMessage(item);
                }
            }
                    observer1.OnCompleted();




        }
    }
}
