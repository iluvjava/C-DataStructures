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
        int Rank;
        T Data;
        BNode<T>[] Children;

        public BNode(int Rank, T Data)
        {
            if (Rank < 0 || object.ReferenceEquals(Data, null))
                throw new Exception();
            Children = Rank == 0? null : new BNode<T>[Rank] ;
        }


    }

}
