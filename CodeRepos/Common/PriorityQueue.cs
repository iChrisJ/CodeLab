using System;
using System.Collections.Generic;

/// <summary>
/// PriorityQueue
/// </summary>
namespace Common.PriorityQueue
{
	public class PriorityQueue<TElement>
	{
		private TElement[] _nodes;
		private int _size;
		private int _capacity;

		private readonly IComparer<TElement> _comparer;

		public int Count => _size;

		public IComparer<TElement> Comparer => _comparer ?? Comparer<TElement>.Default;

		public bool IsFull => _size == _capacity;

		public bool IsEmpty => _size == 0;

		public PriorityQueue()
		{
			_nodes = Array.Empty<TElement>();
			_comparer = InitializeComparer(null);
		}

		public PriorityQueue(IComparer<TElement>? comparer)
		{
			_nodes = Array.Empty<TElement>();
			_comparer = InitializeComparer(comparer);
		}

		public PriorityQueue(int initialCapacity, IComparer<TElement>? comparer)
		{
			if (initialCapacity < 0)
				throw new ArgumentOutOfRangeException(nameof(initialCapacity), initialCapacity, "The capacity of an array cannot less than 0.");

			_capacity = initialCapacity;
			_nodes = new TElement[initialCapacity];
			_comparer = InitializeComparer(comparer);
		}

		public void Enqueue(TElement element)
		{
			if (IsFull)
				throw new InvalidOperationException("The Priority Queue is full!");
			_nodes[_size] = element;
			_size++;

			ShiftUp(element, _size - 1);
		}

		private void ShiftUp(TElement node, int index)
		{
			while (index > 0)
			{
				int parentIndex = (index - 1) >> 1;

				if ((_comparer == null && Comparer<TElement>.Default.Compare(node, _nodes[parentIndex]) < 0)
					|| (_comparer != null && _comparer.Compare(node, _nodes[parentIndex]) < 0))
				{
					_nodes[index] = _nodes[parentIndex];
					index = parentIndex;
				}
				else
					break;
			}
			_nodes[index] = node;
		}

		public TElement Dequeue()
		{
			if (IsEmpty)
				throw new InvalidOperationException("The Priority Queue is empty.");

			TElement res = _nodes[0];
			_nodes[0] = _nodes[_size - 1];
			_size--;

			ShiftDown(0);
			return res;
		}

		private void ShiftDown(int index)
		{
			while (index * 2 + 1 <= _size)
			{
				int childIndex = index * 2 + 1;
				if (childIndex + 1 <= _size &&
					((_comparer == null && Comparer<TElement>.Default.Compare(_nodes[childIndex], _nodes[childIndex + 1]) > 0)
					|| (_comparer != null && _comparer.Compare(_nodes[childIndex], _nodes[childIndex + 1]) > 0)))
					childIndex += 1;

				if ((_comparer == null && Comparer<TElement>.Default.Compare(_nodes[childIndex], _nodes[index]) > 0)
					|| (_comparer != null && _comparer.Compare(_nodes[childIndex], _nodes[index]) > 0))
					return;

				TElement tmp = _nodes[childIndex];
				_nodes[childIndex] = _nodes[index];
				_nodes[index] = tmp;

				index = childIndex;
			}
		}

		public TElement Peek()
		{
			if (IsEmpty)
				throw new InvalidOperationException("The Priority Queue is empty.");
			return _nodes[0];
		}

		/// <summary>
		/// Initializes the custom comparer to be used internally by the heap.
		/// </summary>
		private static IComparer<TElement>? InitializeComparer(IComparer<TElement>? comparer)
		{
			if (typeof(TElement).IsValueType)
			{
				if (comparer == Comparer<TElement>.Default)
				{
					// if the user manually specifies the default comparer,
					// revert to using the optimized path.
					return null;
				}

				return comparer;
			}
			else
			{
				// Currently the JIT doesn't optimize direct Comparer<T>.Default.Compare
				// calls for reference types, so we want to cache the comparer instance instead.
				// TODO https://github.com/dotnet/runtime/issues/10050: Update if this changes in the future.
				return comparer ?? Comparer<TElement>.Default;
			}
		}
	}
}
