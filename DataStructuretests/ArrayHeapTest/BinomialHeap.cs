using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MyDatastructure.PriorityQueue;
using static System.Console;

namespace DataStructureTests.ArrayHeapTest
{
    class BinomialHeap
    {
        [Test]
        public void TestRun()
        {
            var stuff = new HatinaryTree<int>(1);
            var otherstuff = new HatinaryTree<int>(2);
            WriteLine(HatinaryTree<int>.Merge(stuff, otherstuff));
        }

        [Test]
        public void HatinaryTreeMerging()
        {
            WriteLine(new BNode<int>(1, new BNode<int>(2), new BNode<int>(3)));
            WriteLine("This is a B2 three constructed: ");
            WriteLine(ConstructBasicIntB2());
        }


        public HatinaryTree<int> ConstructBasicIntB2()
        {
            var B0 = new HatinaryTree<int>(65);
            var B1 = HatinaryTree<int>.Merge(B0,new HatinaryTree<int>(24));
            var B0_1 = new HatinaryTree<int>(21);
            var B1_1 = HatinaryTree<int>.Merge(B0_1, new HatinaryTree<int>(12));
            return HatinaryTree<int>.Merge(B1, B1_1);
        }
    }
}
