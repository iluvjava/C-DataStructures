using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MyDatastructure.PriorityQueue;
using static DataStructureTests.GeneralTestingTools.ToolsCollection1;
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

        /// <summary>
        /// Construct a basic B2 out of this shit. 
        /// </summary>
        /// <returns></returns>
        public static HatinaryTree<int> ConstructBasicIntB2()
        {
            var B0 = new HatinaryTree<int>(65);
            var B1 = HatinaryTree<int>.Merge(B0,new HatinaryTree<int>(24));
            var B0_1 = new HatinaryTree<int>(21);
            var B1_1 = HatinaryTree<int>.Merge(B0_1, new HatinaryTree<int>(12));
            return HatinaryTree<int>.Merge(B1, B1_1);
        }

        /// <summary>
        /// Construct one  instance of the B2 tree with given T elements. 
        /// </summary>
        [Test]
        public void TestConstructArbitaryIntB2()
        {
            var arr = new int[] {1,2,3,4};
            var B2 = ConstructB2(arr);
            WriteLine(B2);
            Assert.True("{1,Rank: 2 | [3:[2: , ],[4: , ]]}" == B2.ToString());
        }

        /// <summary>
        /// Assert that error  occurs when merging tree with 2 different rank. 
        /// </summary>
        [Test]
        public void TestMergingDifferentRank()
        {
            var B2 = ConstructB2(new int[] { 1, 2, 3, 4 });
            TestDelegate stuff = () =>
            {
                HatinaryTree<int>.Merge(B2, new HatinaryTree<int>(5));
            };
            AssertThrow<Exception>(stuff);
        }


        /// <summary>
        /// Given 4 element, method constructs a B2 binomial tree. 
        /// </summary>
        /// <typeparam name="T">Comprable Type</typeparam>
        /// <param name="args">List </param>
        /// <returns>
        /// Hatinary Tree contating all the elements in it. 
        /// </returns>
        public static HatinaryTree<T> ConstructB2<T>(params T[] args) 
        where T: IComparable<T>
        {
            var B0_1 = new HatinaryTree<T>(args[0]);
            var B0_2 = new HatinaryTree<T>(args[1]);
            var B1_1 = HatinaryTree<T>.Merge(B0_1, B0_2);
            var B0_3 = new HatinaryTree<T>(args[2]);
            var B0_4 = new HatinaryTree<T>(args[3]);
            var B1_2 = HatinaryTree<T>.Merge(B0_3, B0_4);
            return HatinaryTree<T>.Merge(B1_1, B1_2);
        }

    }
}
