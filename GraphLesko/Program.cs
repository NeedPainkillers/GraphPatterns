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

            Graph graph = new Graph(vertex, new BreadthTraversal());
            foreach (var item in graph)
            {
                Console.WriteLine(item.data);
            }
        }
    }
}
