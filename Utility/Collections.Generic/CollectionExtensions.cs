using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Utility.Properties;

namespace Utility.Collections.Generic
{
    public static class CollectionExtensions
    {
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            return new ReadOnlyCollection<T>(list);
        }

        public static void AddAll<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (items != null)
            {
                foreach (T item in items)
                {
                    collection.Add(item);
                }
            }
        }

        /// <summary>
        /// Copies the items of the collection to an <typeparamref name="T"/> array starting placing the items in the destination array at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of the collection's items</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="destArray">The array which the items will be copied to</param>
        /// <exception cref="ArgumentNullException">Either collection or destArray are null</exception>
        public static void CopyTo<T>(this ICollection<T> collection, T[] destArray)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            collection.CopyTo(destArray, 0);
        }

        public static T[] ToArray<T>(this ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection is T[] arr)
            {
                return arr;
            }

            return ToArrayCore(collection);
        }

        public static T[] ToArray<T>(this ICollection<T> collection, int destStartIndex, int length)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection is T[] arr)
            {
                int arrLength = arr.Length;
                if (length < arrLength)
                {
                    throw new ArgumentOutOfRangeException(Resources.Argument_OutOfRange_LengthTooShort);
                }
                else if (length == arrLength)
                {
                    if (destStartIndex < 0)
                    {
                        throw new ArgumentOutOfRangeException(Resources.Argument_OutOfRange_ArgIndex);
                    }
                    else if (destStartIndex > 0)
                    {
                        throw new ArgumentOutOfRangeException(Resources.Argument_OutOfRange_Count);
                    }
                }

                return arr;
            }

            return ToArrayCore(collection, destStartIndex, length);
        }

        internal static T[] ToArrayCore<T>(ICollection<T> collection)
        {
            return ToArrayCore(collection, 0, collection.Count);
        }
        internal static T[] ToArrayCore<T>(ICollection<T> collection, int destStartIndex, int length)
        {
            var destArray = new T[length];
            collection.CopyTo(destArray, destStartIndex);
            return destArray;
        }

        /// <summary>
        /// Swaps the items in the specified indexes.
        /// </summary>
        /// <typeparam name="T">The type of the list of items</typeparam>
        /// <param name="items">The list of items</param>
        /// <param name="index1">The index of the first item</param>
        /// <param name="index2">The index of the second item</param>
        /// <exception cref="ArgumentNullException">items is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Index was outside the bounds of the collection.</exception>
        /// <exception cref="NotSupportedException">The property is set and the <see cref="IList{T}"/> is read-only</exception>
        public static void Swap<T>(this IList<T> items, int index1, int index2)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            if (index1 < 0 || index1 >= items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index1), index1, Resources.Argument_OutOfRange_Index);
            }
            if (index2 < 0 || index2 >= items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index2), index2, Resources.Argument_OutOfRange_Index);
            }

            SwapNoChecks(items, index1, index2);
        }
        public static void SwapNoChecks<T>(this IList<T> items, int index1, int index2)
        {
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IList<T> list, int splitBatchSize)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (splitBatchSize < 1)
            {
                throw new ArgumentException(Resources.Argument_InvalidSplitSize, nameof(splitBatchSize));
            }

            return SplitIterator(list, splitBatchSize);
            //return new ListSplitEnumerator<T>(list, splitBatchSize);
        }
        private static IEnumerable<IEnumerable<T>> SplitIterator<T>
        (
            IList<T> list,
            int splitBatchSize
        )
        {
            int i = 0;
            int itemsCount = list.Count;
            while (i < itemsCount)
            {
                int currentBatchSize = Math.Min(splitBatchSize, itemsCount - i);
                yield return SplitItemsIterator(currentBatchSize);
                i += currentBatchSize;
            }

            IEnumerable<T> SplitItemsIterator(int batchSize)
            {
                for (int j = 0; j < batchSize; j++)
                {
                    yield return list[i];
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> Split<T>
        (
            this ICollection<T> collection,
            int splitBatchSize
        )
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (splitBatchSize < 1)
            {
                throw new ArgumentException(Resources.Argument_InvalidSplitSize, nameof(splitBatchSize));
            }

            return SplitIterator(collection, splitBatchSize);
            //return new CollectionSplitEnumerator<T>(collection, splitBatchSize);
        }
        private static IEnumerable<IEnumerable<T>> SplitIterator<T>(ICollection<T> collection, int splitBatchSize)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                int i = 0;
                int itemsCount = collection.Count;
                while (i < itemsCount)
                {
                    int currentBatchSize = Math.Min(splitBatchSize, itemsCount - i);
                    yield return SplitItemsIterator(currentBatchSize);
                    i += currentBatchSize;
                }

                IEnumerable<T> SplitItemsIterator(int batchSize)
                {
                    for (int j = 0; j < batchSize; j++)
                    {
                        enumerator.MoveNext();
                        yield return enumerator.Current;
                    }
                }
            }
        }

        public static bool IsNullOrEmpty<T>(ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }
        public static bool IsValidIndex<T>(this ICollection<T> collection, int index)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return index >= 0 && index <= collection.Count;
        }
        public static bool IsValidRange<T>
        (
            this ICollection<T> collection,
            int startIndex,
            int count
        )
        {
            return collection.IsValidIndex(startIndex) &&
                   count >= 0 &&
                   startIndex + count <= collection.Count;
        }
        public static bool IsValidRangeReverse<T>
        (
            this ICollection<T> collection,
            int startIndex,
            int count
        )
        {
            return collection.IsValidIndex(startIndex) && count >= 0 && startIndex - count >= -1;
        }

        public static T RemoveLast<T>(this IList<T> list)
        {
            if (IsNullOrEmpty(list))
            {
                throw new ArgumentNullOrEmptyException(nameof(list));
            }

            int index = list.Count - 1;
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }
    }
}