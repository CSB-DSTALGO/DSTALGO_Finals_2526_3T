# E-Commerce Data Structure and Algorithm Analysis

## 1. CustomArrayList and ShoppingCart

### Structure
`CustomArrayList<T>` stores items in a contiguous generic array. `Count` identifies the occupied portion of the array. When the array becomes full, `Resize()` creates a new array with twice the capacity and copies the current items.

### Search
`Search()` uses linear search. It starts at index 0 and compares each occupied item until it finds a match.

- Best case: O(1), when the item is first.
- Average case: O(n).
- Worst case: O(n), when the item is last or missing.
- Extra space: O(1).

### Sort
`Sort()` uses insertion sort. It grows a sorted section on the left and inserts each next item into its correct position by shifting larger values right.

- Best case: O(n), when already sorted.
- Average case: O(n^2).
- Worst case: O(n^2).
- Extra space: O(1).

`ShoppingCart` uses this structure for indexed access, removal by index, searching, and sorting products by price.

## 2. CustomSinglyLinkedList and ProductCatalog

### Structure
`CustomSinglyLinkedList<T>` is a chain of nodes. Each node stores data and a reference to the next node. The first node is referenced by `_head`.

### Search
`Search()` uses linear traversal from the head node until it finds a matching product or reaches the end.

- Best case: O(1), when the item is at the head.
- Average case: O(n).
- Worst case: O(n), when the item is last or missing.
- Extra space: O(1).

### Sort
`Sort()` uses bubble sort by repeatedly comparing adjacent node data and swapping values that are out of order.

- Best case: O(n) when no swap occurs during the first pass.
- Average case: O(n^2).
- Worst case: O(n^2).
- Extra space: O(1).

`ProductCatalog` uses the linked list for appending, removing, locating, traversing, searching, and sorting products by price.

## 3. CustomQueue and OrderProcessingQueue

### Structure
`CustomQueue<T>` uses linked nodes with `_front` and `_rear` references. It follows FIFO: the first order added is the first order processed.

### Search
`Search()` performs a linear traversal from front to rear.

- Best case: O(1).
- Average and worst case: O(n).
- Extra space: O(1).

### Sort
`Sort()` uses bubble sort on adjacent node data. After sorting, the order with the smallest `TotalAmount` is at the front.

- Average and worst case: O(n^2).
- Extra space: O(1).

Queue insertion, removal, and peek operations are O(1).

## 4. CustomStack and ReturnHistoryStack

### Structure
`CustomStack<T>` uses linked nodes and a `_top` reference. It follows LIFO: the newest return request is removed first.

### Search
`Search()` traverses from the top and returns the one-based depth of a matching item.

- Best case: O(1).
- Average and worst case: O(n).
- Extra space: O(1).

### Sort
`Sort()` uses insertion sort directly on the linked nodes. Each node is inserted into its correct position in a sorted chain. The smallest `ReturnId` becomes the top item.

- Best case: O(n).
- Average and worst case: O(n^2).
- Extra space: O(1).

Stack push, pop, and peek operations are O(1).
