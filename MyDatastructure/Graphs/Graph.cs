using System;
using System.Collections.Generic;
using System.Text;

namespace MyDatastructure.Graphs
{

   /// <summary>
   /// Graph is a collection of GNodes and edges. 
   /// </summary>
    public class Graph
    {
    }

    /// <summary>
    /// A node of a graph, storing data type E, 
    /// <para>
    /// No multiple edges. 
    /// </para>
    /// The edges are directed. 
    /// </summary>
    /// <typeparam name="D">
    /// The type of data stored in thie Gnode.
    /// </typeparam>
    /// <typeparam name="E">
    /// Type of data associated with the directed edge this node is connected to. 
    /// </typeparam>
    public class GNode<D, E>
    {
        /// <summary>
        /// The data stroed in the node in the graph. 
        /// </summary>
        public D Data { get; set; }
        /// <summary>
        /// Mapping from neibours of this node, and the value that is associated 
        /// with the edge connected from this node to the neibour node. 
        /// </summary>
        public IDictionary<GNode<D, E>, E> Edges;
        /// <summary>
        /// Create a node. 
        /// </summary>
        /// <param name="item"></param>
        public GNode(D item)
        {
            this.Data = item;
        }


       
    }

    
}
