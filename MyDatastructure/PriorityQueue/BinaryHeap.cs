using MyDatastructure.Maps;
using MyDatastructure.PriorityQ;
using System;
using static System.Array;

namespace MyDatastructure.PriorityQueue
{
    /// <summary>
    /// Simple binary heap that uses a hash map to keep track of the element
    /// , supports unique elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Obsolete("Never tested yet.")]
    public class FancierBinaryHeap<T> : SimpleBinaryHeap<T> where T : IComparable<T>
    {
        /// <summary>
        /// maps the object to index in the heap array.
        /// </summary>
        protected IMap<T, int> IndexMap;

        /// <summary>
        /// Create an Fancier Binary Min Heap. 
        /// </summary>
        public FancierBinaryHeap() : base()
        {
            IndexMap = new SysDefaultMap<T, int>();
        }

        /// <summary>
        /// Creates a fancier binary heap, with the specified ordering of the elements. 
        /// </summary>
        /// <param name="asc">
        /// True for min heap, false for max heap. 
        /// </param>
        public FancierBinaryHeap(bool asc) : base(asc)
        {
            IndexMap = new SysDefaultMap<T, int>();
        }

        /// <summary>
        /// Floyd Build Heap on this.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        protected FancierBinaryHeap(T[] arr, int offset, int len) : base(arr, offset, len)
        {
        }

        /// <summary>
        /// True if the element is in the heap. else, false. 
        /// </summary>
        /// <param name="arg">
        /// An instance of type T. 
        /// </param>
        /// <returns>
        /// </returns>
        override public bool Contains(T arg)
        {
            return IndexMap.ContainsKey(arg);
        }

        /// <summary>
        /// you cannot add duplicated element to the heap.
        /// </summary>
        /// <param name="arg">
        /// An non null instance of the type of T element. 
        /// </param>
        override public void Enqueue(T arg)
        {
            if (IsNull(arg))
                throw new InvalidArgumentException();
            if (IndexMap.ContainsKey(arg))
            {
                throw new InvalidArgumentException();
            }
            IndexMap[arg] = ElementCount + 1;
            base.Enqueue(arg);
        }
        /// <summary>
        /// Remove an element of type T from thea queue. 
        /// </summary>
        /// <param name="arg">
        /// An instance of the type T element. 
        /// </param>
        override public void Remove(T arg)
        {
            if (!IndexMap.ContainsKey(arg))
            {
                throw new InvalidArgumentException();
            }
            int IndexOfRemove = IndexMap[arg];
            Swap(IndexOfRemove, ElementCount);
            IndexMap.Remove(arg);
            ElementCount--;
            Percolate(IndexOfRemove);
        }

        /// <summary>
        /// Remoe the minimum element from the heap. 
        /// </summary>
        override public T RemoveMin()
        {
            if (ElementCount == 0)
                throw new InvalidOperationException();
            T Removed = Peek();
            base.RemoveMin();
            IndexMap.Remove(Removed);
            return Removed;
        }

        /// <summary>
        /// Internal use, for swapping element in the array heap. 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        new protected void Swap(int arg1, int arg2)
        {
            T a = HeapArray[arg1];
            T b = HeapArray[arg2];
            IndexMap[a] = arg2;
            IndexMap[b] = arg1;
            base.Swap(arg1, arg2);
        }
    }

    /// <summary>
    /// This will be the simplest Binary Heap imaginable, Min or Max.
    /// 0 index will be a dummy;
    /// Null is not a accepted value;
    /// Repeated elements are ok;
    /// <para>Doesn't support remove and contain operations. </para>
    /// <para>
    /// Virtual keywords are used for the public members in the class for easier extension. 
    /// </para>
    /// </summary>
    public class SimpleBinaryHeap<T> : IPriorityQ<T> where T : IComparable<T>
    {
        /// <summary>
        /// A boolean to indicated the ordering.
        /// </summary>
        protected bool AscendingOrder = true;
        /// <summary>
        /// The number of total element in the array. 
        /// </summary>
        protected int ElementCount = 0;

        /// <summary>
        /// index 0 is dummy.
        /// </summary>
        protected T[] HeapArray;

        /// <summary>
        /// Get an instance of the Binary Heap.
        /// </summary>
        public SimpleBinaryHeap()
        {
            HeapArray = new T[32];
        }

        /// <summary>
        /// Instanciate an instance of Binary heap, a boolean to indicate prefered odering. 
        /// </summary>
        /// <param name="ascending">
        /// True: Ascending order; False: Descending order. 
        /// </param>
        public SimpleBinaryHeap(bool ascending) : this()
        {
            AscendingOrder = false;
        }

        /// <summary>
        /// Give an array of element it will build the heap from it.
        /// It will copy the array.
        /// <remark>
        /// It uses floyd build heap, good for partial sort.
        /// </remark>
        /// </summary>
        /// <param name="list">
        /// The list should not comtain null, it will blows up if it contains
        /// null.
        /// <param name="offset">
        /// Where you want to start add element from the array to the heap.
        /// Invalid argument will be set to 0.
        /// It's default to be 0.
        /// </param>
        /// <param name="len">
        /// The length you want off from the offset you set.
        /// </param>
        public SimpleBinaryHeap(T[] source, int offset = 0, int len = -1)
        {
            len = (len == -1 || len + offset >= source.Length) ? source.Length - offset : len;
            offset = (offset >= source.Length || offset < 0) ? 0 : offset;
            HeapArray = new T[len * 2];
            Copy(source, offset, HeapArray, 1, len);
            ElementCount = len;
            for (int i = len / 2; i >= 1; i--)
            {
                PercolateDown(i);
            }
        }

        /// <summary>
        /// Getter method for getting size of the heap. 
        /// </summary>
        public virtual int Size
        {
            get
            {
                return ElementCount;
            }
        }

        /// <summary>
        /// Internal method for checking the reference of object is null or not. (Kinda uneccesary...)
        /// </summary>
        /// <param name="o">
        /// Reference to any object. 
        /// \</param>
        /// <returns>
        /// True if it's null. 
        /// </returns>
        public static bool IsNull(object o)
        {
            return object.Equals(o, null);
        }

        /// <summary>
        /// Not supported for this class.
        /// </summary>
        /// <param name="arg">
        /// Any instance of the type T. 
        /// </param>
        /// <returns>
        /// True if it's in the queue, else false. 
        /// </returns>
        public virtual bool Contains(T arg)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// add a new element into the queue.
        /// </summary>
        /// <param name="arg">
        /// Non null instance of the type T. 
        /// </param>
        public virtual void Enqueue(T arg)
        {
            if (IsNull(arg))
                throw new InvalidArgumentException();
            AutomaticResize();
            HeapArray[ElementCount + 1] = arg;
            PercolateUp(ElementCount + 1);
            ElementCount++;
        }

        /// <summary>
        /// Returns an reference to the smallest element in the queue. 
        /// </summary>
        /// <returns></returns>
        public virtual T Peek()
        {
            return HeapArray[1]; // 0 element is the dummy node.
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="arg"></param>
        public virtual void Remove(T arg)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Remove the minimum element from the queue.
        /// </summary>
        /// <throw>
        /// InvalidOperationException is the heap is empty when
        /// trying to remove elements.
        /// </throw>
        /// <returns></returns>
        public virtual T RemoveMin()
        {
            if (ElementCount == 0)
                throw new InvalidOperationException();
            T res = HeapArray[1];
            Swap(1, ElementCount);
            ElementCount--;
            PercolateDown(1);
            return res;
        }

        /// <summary>
        /// Internal method for resizing the heap array in the object. 
        /// </summary>
        protected void AutomaticResize()
        {
            if (ElementCount + 1 == HeapArray.Length)
            {
                Resize(ref HeapArray, HeapArray.Length * 2);
            }
        }

        /// <summary>
        /// Take in account into the settings of the heap to compare the
        /// element.
        /// <code>
        /// a.CompareTo(b) if ascending
        /// - a.CompareTo(b) if descending.
        /// </code>
        /// </summary>
        /// <param name="a">
        /// an element
        /// </param>
        /// <param name="b">
        /// another element</param>
        protected int Compare(T a, T b)
        {
            return AscendingOrder ? a.CompareTo(b) : -a.CompareTo(b);
        }

        /// <summary>
        /// Given any index, it will return the index of where the first child of the element 
        /// will be in. 
        /// </summary>
        /// <param name="arg">
        /// index of the node you are currently looking at. 
        /// </param>
        /// <returns>
        /// Index of it's left child; in the heap. 
        /// </returns>
        protected int GetFirstChildIndex(int arg)
        {
            if (arg < 1)
                throw new InvalidArgumentException();
            return 2 * arg;
        }

        /// <summary>
        ///Return the index of where the parent of the given node is at. 
        /// </summary>
        /// <param name="arg">
        /// Index of the node you are looking at. 
        /// </param>
        /// <returns>
        /// The index of where to look for the parent node. 
        /// </returns>
        protected int GetParentIndex(int arg)
        {
            if (arg <= 1)
            {
                return 1;
            }
            return arg / 2;
        }

        /// <summary>
        /// Internal method, if either percolate the node up, or it percolate the element down. 
        /// </summary>
        /// <param name="arg">
        /// The index of the element you want to percolate. 
        /// </param>
        /// <returns>
        /// The index of where the element finally ended up. 
        /// </returns>
        protected int Percolate(int arg)
        {
            return PercolateUp(PercolateDown(arg));
        }

        /// <summary>
        /// Percolate the element down and move the smallest children up to where the parent is at. 
        /// </summary>
        /// <param name="arg">
        /// The index of the where the elenet you want to percolate down. 
        /// </param>
        /// <returns>
        /// Where the index of the node finally ended up with. 
        /// </returns>
        protected int PercolateDown(int arg)
        {
            int LeftChildIdx = GetFirstChildIndex(arg);
            int RightChildIdx = LeftChildIdx + 1;
            T Parent = HeapArray[arg];

            if (RightChildIdx <= ElementCount)
            {
                T LChild = HeapArray[LeftChildIdx];
                T RChild = HeapArray[RightChildIdx];
                int TheSmallerChildIdx =
                    Compare(LChild, RChild) < 0 ? LeftChildIdx : RightChildIdx;

                if (Compare(HeapArray[TheSmallerChildIdx], Parent) < 0)
                {
                    Swap(TheSmallerChildIdx, arg);
                    return PercolateDown(TheSmallerChildIdx);
                }
                return arg;
            }
            //Only one child
            if (LeftChildIdx <= ElementCount)
            {
                T LChild = HeapArray[LeftChildIdx];
                if (Compare(LChild, Parent) < 0)
                {
                    Swap(LeftChildIdx, arg);
                    return PercolateDown(LeftChildIdx);
                }
                return arg;
            }
            //No child
            return arg;
        }
        
        /// <summary>
        /// Percolate the element up the heap, if it's smaller than the parent
        /// <para>Internal use only. </para>
        /// </summary>
        /// <param name="arg">
        /// Index of the element you want to percolate up. 
        /// </param>
        /// <returns>
        /// The index where it finally ended up with. 
        /// </returns>
        protected int PercolateUp(int arg)
        {
            if (arg == 1)
                return arg;
            int Pidx = GetParentIndex(arg);
            T Parent = HeapArray[Pidx];
            T Child = HeapArray[arg];
            if (Compare(Child, Parent) < 0)
            {
                Swap(Pidx, arg);
                return PercolateUp(Pidx);
            }
            return arg;
        }

        /// <summary>
        /// Give index of 2 elements, it will swap those 2 elements in the heap array. 
        /// </summary>
        /// <param name="arg1">
        /// First index. 
        /// </param>
        /// <param name="arg2">
        /// Another index. 
        /// </param>
        protected void Swap(int arg1, int arg2)
        {
            if (arg1 == arg2)
                return;
            T a = HeapArray[arg1];
            T b = HeapArray[arg2];
            HeapArray[arg1] = b;
            HeapArray[arg2] = a;
        }
    }
}