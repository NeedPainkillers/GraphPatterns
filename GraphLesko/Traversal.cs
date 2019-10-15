using System;
using System.Collections.Generic;
using System.Linq;

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
            _queue.Add(vertex);

            List<Vertex> toAdd = vertex.vertices.Where(x => x.status.Equals(0)).ToList();
            _queue.AddRange(toAdd);
            for (int i = 0; i < toAdd.Count(); i++)
            {
                toAdd[i].status = 1;
            }
            position = -1;
        }

        public Vertex Next()
        {
            try
            {
                position++;
                if (position >= _queue.Count())
                    return null;

                if (position == 0)
                {
                    _queue[position].status = 2;
                    return _queue[position];
                }

                List<Vertex> toAdd = _queue[position].vertices.Where(x => x.status.Equals(0)).ToList();
                _queue.AddRange(toAdd);
                for (int i = 0; i < toAdd.Count(); i++)
                {
                    toAdd[i].status = 1;
                }
                _queue[position].status = 2;
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
        Stack<Vertex> stack { get; set; } = new Stack<Vertex>();

        public void Init(Vertex vertex)
        {
            stack.Push(vertex);
            vertex.status = 1;
        }

        public Vertex Next()
        {
            if(stack.Count() == 0)
                return null;

            Vertex item = stack.Pop();
            item.status = 2;

            List<Vertex> vertices = item.vertices.Where(x => x.status == 0).ToList();
            for (int i = 0; i < vertices.Count; i++)
            {
                stack.Push(vertices[i]);
                vertices[i].status = 1;
            }

            return item;
        }
    }
}
