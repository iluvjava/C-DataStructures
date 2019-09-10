# C-DataStructures
A Net. Core Library for C# Datastructure. 



## Binomial Heap (BinomialHeap.cs)

### The Node
- Holds data, rank of the tree, left and right child
  - Data Can not be null, because it's comparable. 
- For a tree with rank N, it has N subtree, includes the B_0.
- What does it do? 
  - B_N merges with B_N. Tree with the same rank merges together, the one with 
  larger root is connected to the one with smaller root. 

### The Tree

### The Heap