using MyDatastructure.PriorityQ;
using System;
using System.Text;

namespace MyDatastructure.PriorityQueue
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinomialHeap<T> : IPriorityQ<T> where T : IComparable<T>
    {

        HatinaryTree<T>[] Forest = new HatinaryTree<T>[64]; 


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
        /// Interal use only. 
        /// </summary>
        protected HatinaryTree()
        {

        }

        /// <summary>
        /// Merging 2 tree with the same rank, it merges the root
        /// of THIS TREE to THE t TREE, which assumes that this hatnode
        /// is less than that hat node.
        /// <exception>
        /// Can not merge tree with 2 different rank.
        /// </exception>
        /// </summary>
        [Obsolete("It's Plain Wrong")]
        public HatinaryTree<T> Merge(HatinaryTree<T> t)
        {
            if (t.Rank != Rank)
                throw new Exception("Intenal Error.");
            // Check if this hat smaller than that hat, if not, merge that 
            // with this.
            if (Hat.Data.CompareTo(t.Hat.Data) > 0)
            {
                HatinaryTree<T> MergedTree =  t.Merge(this);
                return MergedTree;
            }
            // Assume this hat node less than that hat node.
            BNode<T> NewInnerBinaryTreeNode = t.Hat; // t.hat is never null. 
            NewInnerBinaryTreeNode.RightChild = t.Root;
            NewInnerBinaryTreeNode.LeftChild = Root;
            Root = NewInnerBinaryTreeNode;
            Rank++;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="tis"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static HatinaryTree<R> Merge<R>(HatinaryTree<R> tis, HatinaryTree<R> that)
            where R: IComparable<R>
        {
            if (object.ReferenceEquals(tis, that))
                throw new Exception("Dude stops right there.");
            if (tis.Rank != that.Rank)
                throw new Exception("Tree Merge different rank. ");
            if (tis.Hat.Data.CompareTo(that.Hat.Data) > 0)
                return Merge(that, tis);
            HatinaryTree<R> MergedTree = new HatinaryTree<R>();
            MergedTree.Hat = tis.Hat;
            BNode<R> NewRoot = that.Hat;
            NewRoot.RightChild = that.Root;
            NewRoot.LeftChild = tis.Root;
            MergedTree.Root = NewRoot;
            MergedTree.Rank = tis.Rank+1;
            return MergedTree;
        }

        /// <summary>
        /// <code>
        /// \{hat:&lt;hatdata&gt,[rank]\|&lt;Thebinarytree &gt;\}
        /// </code>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append($"{{{Hat.Data},[{Rank}]|{Root}}}");
            return res.ToString();
        }
    }


  
}