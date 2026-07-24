# Sorting and Search Algorithm Analysis

12521269 Joaquin Bryan G. Ross

This document covers the required analysis for every implementation class in both
systems: the structural mechanism of the algorithm, its operational efficiency,
and its time complexity. The same analysis is repeated in doc comments directly
above each method so it is readable from the code as well.

No built-in collection type is used anywhere. Every structure is backed by a
plain array or by nodes, and every sort is written by hand rather than delegated
to a framework sort.

## Summary table

| Implementation class | Structure | Search | Sort | Sort best | Sort worst | Space |
|---|---|---|---|---|---|---|
| ShoppingCart | CustomArrayList | Linear, returns index | Insertion | O(n) | O(n^2) | O(1) |
| ProductCatalog | CustomSinglyLinkedList | Linear, returns bool | Insertion by re-linking | O(n) | O(n^2) | O(1) |
| OrderProcessingQueue | CustomQueue | Linear, non-destructive | Insertion after realign | O(n) | O(n^2) | O(1) or O(n) |
| ReturnHistoryStack | CustomStack | Linear from top, returns depth | Insertion, inverted | O(n) | O(n^2) | O(1) |
| StudentRegistry | CustomArrayList | Linear, returns index | Insertion | O(n) | O(n^2) | O(1) |
| CourseCurriculum | CustomSinglyLinkedList | Linear by course code | Insertion by re-linking | O(n) | O(n^2) | O(1) |
| AdmissionsDesk | CustomQueue | Linear, non-destructive | Insertion after realign | O(n) | O(n^2) | O(1) or O(n) |
| AdministrativeLogs | CustomStack | Linear from top, returns depth | Insertion, inverted | O(n) | O(n^2) | O(1) |

## Why insertion sort throughout

Insertion sort was chosen for all eight classes for three reasons.

It is in place. The only extra memory is a single variable holding the item being
placed, so sorting a cart or a registry does not double its memory footprint.

It is adaptive. On input that is already sorted or nearly sorted it degrades to
O(n), because the inner loop exits immediately on every pass. Every one of these
modules is appended to far more often than it is reordered, so nearly sorted is
the case that actually shows up at runtime.

It is stable. Items that compare equal keep their original relative order. That
matters for the queue modules, where two orders with the same total or two
tickets issued in the same batch should still be served in the order they
arrived.

The trade is the O(n^2) worst case. On reversed input every element shifts past
every element already placed, giving n(n-1)/2 comparisons. Merge sort would give
a guaranteed O(n log n) and is the textbook answer for the linked list, but it
needs either recursion or an explicit merge pass, and for a shopping cart or a
class curriculum n is small enough that the constant factors dominate anyway.

## Per structure detail

### CustomArrayList: ShoppingCart and StudentRegistry

Search walks index 0 upward comparing each slot. Best case O(1) when the target
is first, average O(n/2) which is still O(n), worst O(n) when the item is last or
absent. It returns a zero-based index, which is meaningful here because an array
list is the one structure with real random access.

Binary search would be O(log n), but it requires the data to be sorted at all
times. These modules sort only on demand, so a binary search would silently
return wrong answers on unsorted input. Linear search is correct regardless of
order, which is the property that matters more than the speed.

Sort grows a sorted region at the front of the array. For each item it walks
backward through the sorted region, shifting larger items right, until it finds
the slot where the item belongs. Shifting rather than swapping halves the writes.

### CustomSinglyLinkedList: ProductCatalog and CourseCurriculum

Search follows Next from the head until it matches or the chain ends. Same O(n)
profile as the array list, but a chain cannot do better even in principle. There
is no way to jump to the middle without walking there first, so binary search is
not merely unhelpful here, it is impossible. That is the fundamental trade a
linked list makes: O(1) insertion at a known node, in exchange for no indexing.

ProductCatalog returns a bool because a chain has no index worth reporting.
CourseCurriculum returns the matching Course, since the requirement table asks
for a method that locates and returns a node.

Sort is insertion sort performed by re-linking. A second, sorted chain is built
and each node is spliced into place by rewriting Next pointers. No course or
product data is copied at any point, only pointers move. This is the version of
insertion sort worth studying, because it shows the algorithm is about ordering,
not about arrays.

Add is O(n) rather than O(1), because no tail pointer is kept and the chain must
be walked to reach the end. Adding a tail pointer would make appends
O(1) at the cost of one more field to keep correct on every removal.

### CustomQueue: OrderProcessingQueue and AdmissionsDesk

The queue is a circular buffer. The items occupy Count slots starting at the
front index and wrapping past the end of the array with modulo arithmetic. This
is what keeps Dequeue at O(1): the front index moves forward instead of every
remaining item shifting one place left, which a naive array queue would need and
which would make Dequeue O(n).

Search steps from the front through Count slots, wrapping the same way. The
property that matters is that it is non-destructive. The obvious way to search a
queue is to drain it into another structure and rebuild it, which is the same
O(n) but destroys and rebuilds the waiting order in the process. Indexing the
buffer directly avoids touching the queue at all.

Sort realigns the buffer back to index 0 first, so the wrapped region becomes
contiguous and the sort can treat it as an ordinary array. The realign is the
only reason the space bound is ever O(n) instead of O(1), and it is skipped
entirely when the front is already at index 0.

Sorting a FIFO queue turns it into a priority pass, which is a deliberate change
of behaviour. That is why it is an explicit call rather than something that
happens automatically on enqueue.

### CustomStack: ReturnHistoryStack and AdministrativeLogs

Search scans from the highest index downward and reports depth from the top,
counting the top as 1, or -1 when absent. Depth is reported instead of an array
index because a caller reasoning about a stack thinks in "how many pops away"
terms, not in storage positions.

Sort is the one to read carefully, because its comparison is inverted against
the other three structures. Ascending for a stack means that popping yields
ascending order. The smallest item therefore has to end up on top, and since the
top is the highest array index, the backing array finishes descending from bottom
to top. Writing the comparison the same way as the array list version produces a
stack that is sorted backwards, and the test that catches it is the one asserting
what Peek returns after a sort.

## Complexity of the non-sorting operations

| Operation | ArrayList | LinkedList | Queue | Stack |
|---|---|---|---|---|
| Insert | O(1) amortised | O(n) append | O(1) amortised | O(1) amortised |
| Remove | O(n) shift | O(n) find, O(1) unlink | O(1) dequeue | O(1) pop |
| Access by index | O(1) | O(n) | front only, O(1) | top only, O(1) |
| Search | O(n) | O(n) | O(n) | O(n) |

Amortised O(1) on the array-backed structures means the doubling growth is
included. A resize copies n items and is O(n), but it happens after n insertions,
so the cost spread across those insertions is constant. Doubling is what makes
this work. Growing by a fixed amount instead would make insertion O(n) amortised.
