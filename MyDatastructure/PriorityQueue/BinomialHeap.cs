using MyDatastructure.PriorityQ;
using System;
using System.Collections.Generic;
using System.Text;

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


    public class BNode<T> where T : IComparable<T>
    {
        T Data;
        /// <summary>
        /// Visiting Children at that level. 
        /// </summary>
        BNode<T> LeftChild;
        /// <summary>
        /// Go down in the level of the Binomial Tree. 
        /// </summary>
        BNode<T> RightChild;

        public BNode(BNode<T> l, BNode<T> r)
        {
            LeftChild = l;
            RightChild = r;
        }
    }

    public class HatinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Root of an ordinary binary tree. 
        /// </summary>
        BNode<T> Root;
        /// <summary>
        /// The smallest element, top node of the binomial tree. 
        /// </summary>
        BNode<T> Hat;

    }

}
