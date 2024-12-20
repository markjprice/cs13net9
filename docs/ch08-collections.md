**.NET Collections Overview**

> Thanks to **rene** in the book's Discord channel for suggesting and starting this document.

- [Arrays](#arrays)
- [Lists](#lists)
- [Stacks](#stacks)
- [Queues](#queues)
- [Dictionaries](#dictionaries)
- [Sets](#sets)
- [Specialized Collections](#specialized-collections)
- [Observable and Reactive Collections](#observable-and-reactive-collections)
- [Pools](#pools)
- [Specialized Read-Only Collections](#specialized-read-only-collections)

---

# Arrays

These data structures always represent a contiguous block of memory.

- **Array**: Base type for all arrays in .NET.
- **ImmutableArray\<T>**: An immutable array.
- **Memory\<T>**: Represents a region of contiguous memory.
- **ReadOnlyMemory\<T>**: Immutable counterpart to `Memory<T>`.
- **Span\<T>**: A stack-only type representing a slice of contiguous memory.
- **ReadOnlySpan\<T>**: A stack-allocated, read-only slice of memory.

---

# Lists
- **ArrayList**: Non-generic, legacy type (pre-.NET 2.0).
- **List\<T>**: Generic, flexible list.
- **ConcurrentList\<T>**: Thread-safe list.
- **ImmutableList\<T>**: Immutable list.
- **SortedList\<TKey, TValue>**: Key-value list sorted by key.
- **LinkedList\<T>**: Generic doubly linked list.

---

# Stacks
- **Stack\<T>**: Generic stack (LIFO).
- **ConcurrentStack\<T>**: Thread-safe stack.
- **ImmutableStack\<T>**: Immutable stack.

---

# Queues
- **Queue\<T>**: Generic queue (FIFO).
- **ConcurrentQueue\<T>**: Thread-safe queue.
- **ImmutableQueue\<T>**: Immutable queue.
- **PriorityQueue\<TElement, TPriority>**: Queue with priorities.

---

# Dictionaries
- **Hashtable**: Non-generic, legacy type (pre-.NET 2.0).
- **Dictionary\<TKey, TValue>**: Generic dictionary.
- **ConcurrentDictionary\<TKey, TValue>**: Thread-safe dictionary.
- **ImmutableDictionary\<TKey, TValue>**: Immutable dictionary.
- **ImmutableSortedDictionary\<TKey, TValue>**: Immutable dictionary sorted by key.
- **SortedDictionary\<TKey, TValue>**: Generic dictionary sorted by key.
- **ReadOnlyDictionary\<TKey, TValue>**: Read-only dictionary.
- **FrozenDictionary\<TKey, TValue>**: Optimized, immutable dictionary for high-performance lookups (introduced in .NET 8).
- **Lookup\<TKey, TValue>**: Maps keys to collections of values, allowing multiple values per key (immutable).

---

# Sets
- **HashSet\<T>**: Generic set with no duplicates.
- **FrozenSet\<T>**: Optimized, immutable set (introduced in .NET 7).
- **ImmutableHashSet\<T>**: Immutable set with no duplicates.
- **ImmutableSortedSet\<T>**: Immutable set sorted by elements.
- **SortedSet\<T>**: Mutable set sorted by elements.

---

# Specialized Collections
- **ConcurrentBag\<T>**: Thread-safe, unordered collection.
- **BlockingCollection\<T>**: Thread-safe collection with blocking and bounding capabilities.
- **Channel\<T>**: Thread-safe messaging and data-passing primitive.
- **BufferBlock\<T>**: Part of TPL Dataflow for producer-consumer scenarios.

---

# Observable and Reactive Collections
- **ReadOnlyCollection\<T>**: Read-only view of a list.
- **ObservableCollection\<T>**: Collection with change notifications.
- **ReadOnlyObservableCollection\<T>**: Read-only view of an `ObservableCollection`.

---

# Pools
- **ArrayPool\<T>**: Provides a pool of arrays to minimize allocations.
- **MemoryPool\<T>**: Provides pooled memory segments.

---

# Specialized Read-Only Collections
- **ReadOnlySequence\<T>**: High-performance abstraction over a sequence of memory blocks.
