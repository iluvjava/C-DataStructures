# C-DataStructures
A Net. Core Library for C# Datastructure. 



## Binomial Heap (BinomialHeap.cs)
- Binomial Heap is an abstract structure, which is actually implemented as 
HatinaryTree in the program.
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

### The Node
- The node is just an ordinary Binary Tree Node.    

### The Heap
- It's an array of trees. 