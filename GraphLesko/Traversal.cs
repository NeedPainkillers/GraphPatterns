using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLesko
{
    public interface ITraversal
    {
        void Init(Vertex vertex);
        Vertex Next();
    }

    public class BreadthTraversal : ITraversal
    {
        List<Vertex> _queue { get; set; } = new List<Vertex>();
        int position = -1;

        public void Init(Vertex vertex)
        {
            vertex.status = 1;
            _queue.Clear();

            for (int i = 0; i < vertex.vertices.Count; i++)
            {
                vertex.vertices[i].status = 1;
            }
            _queue.AddRange(vertex.vertices);
            position = 0;
        }

        public Vertex Next()
        {
            try
            {
                return _queue[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public class DepthTraversal : ITraversal
    {
        List<Vertex> stack { get; set; } = new List<Vertex>();

        public void Init(Vertex vertex)
        {
            throw new NotImplementedException();
        }

        public Vertex Next()
        {
            throw new NotImplementedException();
        }
    }
}
