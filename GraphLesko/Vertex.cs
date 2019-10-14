using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLesko
{
    public class Vertex
    {
        /// <summary>
        /// Variable status represents current state of vertex
        ///     0 - object is never visited
        ///     1 - object is in queue
        ///     2 - object is visited
        /// </summary>

        public List<Vertex> vertices { get; set; } = new List<Vertex>();

        public string data { get; set; } = string.Empty;
        public byte status { get; set; } = 0;
    }
}
