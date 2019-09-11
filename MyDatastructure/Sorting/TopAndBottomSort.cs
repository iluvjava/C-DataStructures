using System;
using System.Collections.Generic;
using System.Text;

namespace MyDatastructure.Sorting
{

    /// <summary>
    /// A better version of Top K sort, it find the top and bottom N-k, k element 
    /// from a list of comparable, it will also remember the min and the max too, 
    /// on average, close to O(N log(K)) performace. 
    /// 
    /// It will not modified the original structure. 
    /// </summary>
    class TopAndBottomSort<T> where T: IComparable<T>
    {
        T[] UnoderedData;
        T Max { get; }
        T Min { get; }
        T MinK { get; }
        T MaxK { get; }
        /// <summary>
        /// All elements less than the K th max element and 
        /// larger than the Kth element. 
        /// </summary>
        T[] MiddleBody;



        /// <summary>
        /// Only Support K, on number, symmetric. 
        /// It will not modify the array. 
        /// </summary>
        /// <param name="K">
        /// The number of top and bottom you want from the data set. 
        /// </param>
        /// <param name="arr">
        /// The random number of comparable you prepared.   
        /// </param>
        public TopAndBottomSort(int K, T[] arr)
        {
            if (K <= 1 || 2*K >= arr.Length)
            {
                throw new Exception();
            }

        }

    }
}
