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


    public class BNode<T>
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

        public BNode(T data, BNode<T> l = null, BNode<T> r = null)
        {
            Data = data;
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

        /// <summary>
        /// Represents the rank of the binomial tree. 
        /// </summary>
        int Rank;


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
        /// Merging 2 tree with the same rank
        /// <exception>
        /// Can not merge tree with 2 different rank.
        /// </exception>
        /// </summary>
        public void Merger(HatinaryTree<T> t)
        {
            if (t.Rank != Rank)
                throw new Exception("Intenal Error.");

        }



    }

}
