using MyDatastructure.PriorityQ;
using System;
using System.Text;

namespace MyDatastructure.PriorityQueue
{
    /// <summary>
    /// This is the major class for the Binomial heap.
    /// - it has a forest of hatinary tree in it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinomialHeap<T> : IPriorityQ<T> where T : IComparable<T>
    {
        /// <summary>
        /// Array of Hatinary tree.
        /// </summary>
        private HatinaryTree<T>[] Forest = new HatinaryTree<T>[64];

        /// <summary>
        ///
        /// </summary>

        public int Size => throw new NotImplementedException();

        /// <summary>
        /// Returns a bool representing if the element is presented in the queue.
        /// </summary>
        /// <param name="arg">
        /// Type T arg, null will be false always.
        /// </param>
        /// <returns>
        ///
        /// </returns>
        public bool Contains(T arg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add an element to the queue
        /// </summary>
        /// <param name="arg"></param>
        public void Enqueue(T arg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a reference to the smallest element in the queue.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unsoported operation.
        /// </summary>
        /// <param name="arg"></param>
        public void Remove(T arg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove the minimum element from the queue.
        /// </summary>
        /// <returns></returns>
        public T RemoveMin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Merges the rhs(righthandside) of the tree, the rhs will becompe an empty and unusable
        /// heap after the merge, the referece "this" will be come the new tree.
        /// </summary>
        protected void MergeHeaps(BinomialHeap<T> rhs)
        {
            if (this == rhs)
                throw new Exception("Alias reference to the same tree. ");
        }
    }

    /// <summary>
    /// Binary Node.
    /// </summary>
    /// <typeparam name="T">Any Type</typeparam>
    public class BNode<T>
    {
        /// <summary>
        /// Type T data ths is stored in the node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Visiting Children at that level.
        /// </summary>
        public BNode<T> LeftChild { get; set; }

        /// <summary>
        /// Go down in the level of the Binomial Tree.
        /// </summary>
        public BNode<T> RightChild { get; set; }

        /// <summary>
        /// Construct a Binary Node, with data, left child and right child.
        /// </summary>
        /// <param name="data">
        /// Nullable
        /// </param>
        /// <param name="l">
        /// BNode of the same type. left child.
        /// </param>
        /// <param name="r">
        /// BNode of the same type, right child.
        /// </param>
        public BNode(T data, BNode<T> l = null, BNode<T> r = null)
        {
            Data = data;
            LeftChild = l;
            RightChild = r;
        }

        /// <summary>
        /// [&lt;node &gt;:[left tree] ,[rightree]]
        /// if empty, then the element will not be there.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var res = new StringBuilder();
            GetStringRepresentation(res);
            return res.ToString();
        }

        /// <summary>
        /// A helper method for fast string concatenation.
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        protected void GetStringRepresentation(StringBuilder sb)
        {
            sb = sb ?? new StringBuilder();
            sb.Append($"[{Data}:");
            if (LeftChild != null)
                LeftChild.GetStringRepresentation(sb);
            else
                sb.Append(" ");
            sb.Append(",");
            if (RightChild != null)
                RightChild.GetStringRepresentation(sb);
            else
                sb.Append(" ");
            sb.Append("]");
        }
    }

    /// <summary>
    /// A representation of the abstract Binomial tree.
    /// ! Cannot accept null element.
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
        /// ! : Cannot put null into it.
        /// </summary>
        /// <param name="data">
        /// Type T data, cannot be null.
        /// </param>
        /// <exception cref="InvalidArgumentException">
        /// data is null.
        /// </exception>
        public HatinaryTree(T data)
        {
            if (data == null)
            {
                throw new InvalidArgumentException();
            }
            Rank = 0;
            Hat = new BNode<T>(data);
        }

        /// <summary>
        /// Interal use only.
        /// </summary>
        protected HatinaryTree()
        {
        }

        /// <summary>
        /// Internal use only
        /// </summary>
        protected HatinaryTree(BNode<T> hat, BNode<T> root)
        {
            Hat = hat;
            Root = root;
        }

        // ! Passed Casual Testing
        /// <summary>
        /// Extenstion method, Merge.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="tis"></param>
        /// <param name="that"></param>
        /// <exception cref="InvalidArgumentException">
        /// Thrown when merging 2 Btree with different rank.
        /// </exception>
        /// <returns></returns>
        public static HatinaryTree<R> Merge<R>
            (HatinaryTree<R> tis, HatinaryTree<R> that)
            where R : IComparable<R>
        {
            if (object.ReferenceEquals(tis, that))
                throw new Exception("Dude stops right there.");
            if (tis.Rank != that.Rank)
                throw new InvalidArgumentException("Tree Merge different rank. ");

            if (tis.Hat.Data.CompareTo(that.Hat.Data) > 0)
                return Merge(that, tis);
            HatinaryTree<R> MergedTree = new HatinaryTree<R>();
            MergedTree.Hat = tis.Hat;
            BNode<R> NewRoot = that.Hat;
            NewRoot.RightChild = that.Root;
            NewRoot.LeftChild = tis.Root;
            MergedTree.Root = NewRoot;
            MergedTree.Rank = tis.Rank + 1;
            return MergedTree;
        }

        // ! Haven't been tested yet!!!
        /// <summary>
        /// Method will remove the root nodes of the tree and return
        /// a new array of trees for merging in the heap, with the size of rank.
        /// <para>
        ///  It will not modifiy the current tree. 
        ///  </para>
        ///  
        /// <para>
        /// The size of the returned array equals to the rank of the tree. 
        /// </para>
        /// </summary>
        /// <returns>
        /// Null is returned in the current tree is rank 0.
        /// </returns>
        public HatinaryTree<T>[] Expand()
        {
            if (Rank == 0) return null;
            var res = new HatinaryTree<T>[Rank];
            {
                res[Rank - 1] = new HatinaryTree<T>(Hat.Data);
                BNode<T> node = Root; // ! Reference pointer, for traversing the tree.
                for (int i = Rank - 2; i >= 0; i--)
                {
                    res[i] = new HatinaryTree<T>
                        (
                            new BNode<T>(node.Data), node.RightChild
                        );
                    node = node.LeftChild;
                }
            }
            return res;
        }

        /// <summary>
        ///Merge 2 Btree with the same rank. It will not modify any of the tree, it
        ///will return a new reference to the merged new tree.
        /// <exception>
        /// Can not merge tree with 2 different rank.
        /// </exception>
        /// </summary>
        public HatinaryTree<T> Merge(HatinaryTree<T> t)
        {
            return Merge(this, t);
        }

        /// <summary>
        /// <code>
        /// \{hat:&lt;hatdata&gt;[rank]\|&lt;Thebinarytree &gt;\}
        /// </code>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append($"{{{Hat.Data},Rank: {Rank} | {Root}}}");
            return res.ToString();
        }
    }
}