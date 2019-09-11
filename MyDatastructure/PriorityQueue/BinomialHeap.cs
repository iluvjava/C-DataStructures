using MyDatastructure.PriorityQ;
using System;

namespace MyDatastructure.PriorityQueue
{
    public class BinomialHeap<T> : IPriorityQ<T> where T : IComparable<T>
    {
        public int Size => throw new NotImplementedException();

        public bool Contains(T arg)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T arg)
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void Remove(T arg)
        {
            throw new NotImplementedException();
        }

        public T RemoveMin()
        {
            throw new NotImplementedException();
        }
    }

    public class BNode<T>
    {
        public T Data { get; set; }

        /// <summary>
        /// Visiting Children at that level.
        /// </summary>
        public BNode<T> LeftChild { get; set; }

        /// <summary>
        /// Go down in the level of the Binomial Tree.
        /// </summary>
        public BNode<T> RightChild { get; set; }

        public BNode(T data, BNode<T> l = null, BNode<T> r = null)
        {
            Data = data;
            LeftChild = l;
            RightChild = r;
        }
    }

    /// <summary>
    /// A representation of the abstract Binomial tree. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HatinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Represents the rank of the binomial tree.
        /// </summary>
        private int Rank;

        /// <summary>
        /// The smallest element, top node of the binomial tree.
        /// </summary>
        public BNode<T> Hat { get; set; }

        /// <summary>
        /// Root of an ordinary binary tree.
        /// </summary>
        public BNode<T> Root { get; set; }

        /// <summary>
        /// Construct B_0 Binomial tree.
        /// </summary>
        /// <param name="data"></param>
        public HatinaryTree(T data)
        {
            Rank = 0;
            Hat = new BNode<T>(data);
        }

        /// <summary>
        /// Merging 2 tree with the same rank, it merges the root
        /// of THIS TREE to THE t TREE, which assumes that this hatnode
        /// is less than that hat node.
        /// <exception>
        /// Can not merge tree with 2 different rank.
        /// </exception>
        /// </summary>
        public void Merge(HatinaryTree<T> t)
        {
            if (t.Rank != Rank)
                throw new Exception("Intenal Error.");
            // Check if this hat smaller than that hat, if not, merge that 
            // with this.
            if (Hat.Data.CompareTo(t.Hat.Data) > 0)
            {
                t.Merge(this);
                Rank++;
                return;
            }
            // Assume this hat node less than that hat node.
            BNode<T> NewInnerBinaryTreeNode = t.Hat;
            NewInnerBinaryTreeNode.RightChild = t.Root;
            NewInnerBinaryTreeNode.LeftChild = Root;
            Root = NewInnerBinaryTreeNode;
            Rank++;
        }
    }
}