# C-DataStructures
A Net. Core Library for C# Datastructure. 



## Binomial Heap (BinomialHeap.cs)
- Binomial Heap is an abstract structure, which is actually implemented as 
HatinaryTree in the program.
- The children of each tree is ordered in Descending rank: B_0 <= B_1<= B_2...
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
    Choose the smaller among hat1node and hat2node, make it into hat 
of the new HatinaryTree. 
    Choose the smaller among hatnode and make it into the root of the 
inner Binary Tree such that, the left is the root of the BinaryTree with 
smaller value. 
```
 - This codes will enforce the Binomial Invariant. 
### The Node
- The node is just an ordinary Binary Tree Node. 

### The Heap
- It's an array of trees. 