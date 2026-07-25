Course curriculum analysis
John Paul Eustaquio - Member 2 (CustomSInglyLinkedList and CourseCurriculum)
12418743

My coursecurriculum uses a singly linked list to hold the courses while for sorting, I used bubble sort. For searching I used linear search and both are written inside the linked list.

For sorting, Bubble Sort as this goes through the list an compares two courses next to each other. In case they are in the wrong order, it swaps them and would keep on going through the list
again andd again until a full pass has no swaps which only means that the list has been sorted.

It uses a swapped flag for efficiency so that ifthe list is already sorted it just stops early. It only uses one temporary variable when swapping so it doesnt eat up memory. For its time complexity,
the best case is O(n) if hte list is already sorted, while the average and worst case is O(n^2), and the space is O(1).

For search, Linear Search as it starts first at the head of the list and then check each course one by one until it finds a match or reaches the end. If it finds the course, it returns, and if not,
it returns -1.

For the linear search's efficiency, if the course is near the front it finishes fast, butif it's at the end or not there, it has to go through everything. It only uses a pointer and a counter.
For the time complexity, best case is O(1) if the course is first and worst case is O(n). Linear search best fits becuase if i went with binary it would need to jump straight to the middle, and a
linked list isn't able to do that since it has to go one by one.
