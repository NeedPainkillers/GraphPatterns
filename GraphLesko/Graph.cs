using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GraphLesko
{
    public class Graph : IEnumerable
    {
        private Vertex[] _vertices;
        private ITraversal _strategy;

        public Graph(Vertex[] array)
        {
            _vertices = new Vertex[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                _vertices[i] = array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        public GraphEnum GetEnumerator()
        {
            return new GraphEnum(_vertices, _strategy);
        }
    }

    public class GraphEnum : IEnumerator
    {
        private Vertex[] _vertices;
        private ITraversal _strategy;
        private Vertex _current;

        public GraphEnum(Vertex[] array, ITraversal strategy)
        {
            _vertices = array;
            _strategy = strategy;
            _strategy.Init(_vertices[0]);
        }

        public bool MoveNext()
        {
            _current = _strategy.Next();
            return _current != null;
        }

        public void Reset()
        {
            _current = _vertices[0];
            _strategy.Init(_current);
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Vertex Current
        {
            get
            {
                try
                {
                    return _current;
                }
                catch (NullReferenceException)
                {
                    throw new Exception("Null reference exception");
                }
            }
        }
    }
}
