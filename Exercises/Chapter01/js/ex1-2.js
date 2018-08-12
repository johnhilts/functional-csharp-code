/*
Quicksort first divides a large array into two smaller sub-arrays: the low elements and the high elements. Quicksort can then recursively sort the sub-arrays.

The steps are:

1. Pick an element, called a pivot, from the array.
2. Partitioning: reorder the array so that all elements with values less than the pivot come before the pivot, 
    while all elements with values greater than the pivot come after it (equal values can go either way). 
    After this partitioning, the pivot is in its final position. This is called the partition operation.
3. Recursively apply the above steps to the sub-array of elements with smaller values and separately to the sub-array of elements with greater values.
The base case of the recursion is arrays of size zero or one, which are in order by definition, so they never need to be sorted.

The pivot selection and partitioning steps can be done in several different ways; the choice of specific implementation schemes greatly affects 
the algorithm's performance.
*/
let counter = 0
let selectPivot = (l) => Math.floor(l.length / 2)
let partitionLess = (l, i) => l.filter(e => e <= l[i])
let partitionGreater = (l, i) => l.filter(e => e > l[i])
let quickSort = (l) => {
    let i = selectPivot(l)
    let lesser = partitionLess(l, i)
    let greater = partitionGreater(l, i)
    if (JSON.stringify(l) == JSON.stringify([...lesser, ...greater].reduce((acc, val) => acc.concat(val), []))) {
        return l;
    }
    let sortedLess = (lesser.length > 1) ? quickSort(lesser) : lesser;
    let sortedGreater = (greater.length > 1) ? quickSort(greater) : greater;
    return [...sortedLess, ...sortedGreater].reduce((acc, val) => acc.concat(val), [])
}
let runIt = (l) => {
    console.log(l)
    console.log(quickSort(l))
    console.log()
}
runIt([4, 5, 6, 1, 3, 2, 7])
runIt([322, 126, 258, 78, 233, 90, 42])
runIt([10,7,8,9,6])
