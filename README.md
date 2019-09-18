# C-DataStructures
A Net. Core Library for C# Datastructure. 



## Binomial Heap (BinomialHeap.cs)
- Binomial Heap is an abstract structure, which is actually implemented as 
HatinaryTree in the program.
- The children of each tree is ordered in **descending rank**: 
B_0 <= B_1<= B_2... 
- The values contained by children **is not ordered**. 
## Hatinary Tree
- This tree has 2^N of nodes for height of N, it's meant to represent the 
abstract structure called "BinomialTree"
    - Full Binary tree with an extra node on the top. 
    - Intuition behind: 
      - Repesenting the Binomial tree structure directly will result in 
      frequent resizing of the pointer in each nodes when merging, however
      using a Bijective transform on the structure and change it into this 
      Hatnary Tree structure helps with speed a lot. 
- The tree cotains 2 elements, one is a root of a binary tree, and an extra
hat, representing the **smallest element** on the top of the Binomial Tree. 
- Properties: 
  - Going **right** in the tree will go **Down** level in the Binomial Tree. 
  - Going **left** in the tree will visit **all the top nodes** of the Binomial 
  tree at that level, Or all the children of B_Level. 
- ### Merge
  - A Binomial tree will merge with another with the same rank, and it will keep
  their root node as the same. 
  - This operation will be represnted in our Hatinary Tree too.
  - When merging, here is the things that stay unchanged: 
    - The children of Binomial tree is in **ascending order**
    when ranks increases.
    - The new Hat of the tree is **still going to be the smallest**. 
  - Given 2 Hatinary Tree, Hat1, Hat2, with hat1node and hat2node, 
  and BinaryTree1, and BinaryTree2 in them. here is the Pseudo code for    
  merging: 
    ```
        The smaller hat node of the 2 becomes the hat of the new Hatinary tree.
        The larger hat node's right connects to the inner binary tree with 
    the larger hatnode, left is the other binary tree. 
    ```
  - This codes will enforce the Binomial Invariant.
  - Uses the symmetry of the operation:
    ```
    if this.hatnode.value < that.hatnode.value
     => this.merge(that) else that.merge(this) 
    ```
	- The merging of process for 2 B0 tree seems to be different than the general case. 
    - **NOETS** 12/09/2019
      - The non static method for merging is obsoleted because of the reference concerns and 
      immutability of the object. A static method is added for merging of the tree instead. 
	  - The merging process is a communtative operation, which means that a.Merge(b) == b.merge(a), 
      it creates a reference to the new tree too.  
- ### Expand
  - Remove the hat of the Htree (Root of Btree), and add all its children in order into an array,
    thi method will be used for remove min of the heap. 
  - The rank of the tree is equaled to its index in the returned array. 
  - **Null is returned if the given tree is Rank 0**
  - Tranversing down the left side of the tree, adding the traversing node as the hat of the new 
  tree and adding the reference to the right of the node as the root of the new HTree. 

- ### Test Cases
### The Node
- The node is just an ordinary Binary Tree Node with left and right children. 

### The Heap
- What is has: 
  - An Array of Hatinary tree, forest, in order: [B_0, B_1, B_2... B_N]
  - The rank of the Binomial tree is equaled to the index it is at. 
- What it does: 
  - Merge, Add, RemoveMin
  - Merging: 
    - It's simliar to binary addition, the codes is in the Weiss book on page 260. 