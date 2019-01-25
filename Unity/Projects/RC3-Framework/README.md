# RC3-Framework

Tutorials on fundamental algorithms and data structures for modelling complex systems

```dot
digraph {
    rankdir=LR
    size="8,4"

    node [shape=circle style=filled fillcolor=black fontcolor=white fontname=arial
    fontsize=10]
    edge [arrowsize=0.75]

    R -> R
    R -> C

    C -> R
    C -> C
    C -> 3

    3 -> R
    3 -> C
    3 -> 3
}
```

## Assignments

### 19.01.24
- Write a function that moves each vertex in a given graph to the average position of its neigbours