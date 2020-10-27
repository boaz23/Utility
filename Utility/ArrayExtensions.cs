using System;
using System.Collections.Generic;

using Utility.Properties;

using static Utility.Collections.Generic.CollectionExtensions;

namespace Utility
{
    public static class ArrayExtensions
    {
        public static int BinarySearch<T>(this T[] array, T value)
        {
            return Array.BinarySearch(array, value);
        }
        public static int BinarySearch<T>(this T[] array, T value, IComparer<T> comparer)
        {
            return Array.BinarySearch(array, value, comparer);
        }
        public static int BinarySearch<T>(this T[] array, T value, int startIndex, int length)
        {
            return Array.BinarySearch(array, startIndex, length, value);
        }
        public static int BinarySearch<T>
        (
            this T[] array,
            T value,
            int startIndex,
            int length,
            IComparer<T> comparer
        )
        {
            return Array.BinarySearch(array, startIndex, length, value, comparer);
        }

        public static T[] Clone<T>(this T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            return (T[])array.Clone();
        }

        public static TResult[] Covert<TSource, TResult>
        (
            this TSource[] array,
            Converter<TSource, TResult> converter
        )
        {
            return Array.ConvertAll(array, converter);
        }
        public static TResult[] Covert<TSource, TResult>
        (
            this TSource[] array,
            Converter<TSource, TResult> converter,
            int startIndex
        )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }

            int length = array.Length;
            return ConvertCore(array, converter, startIndex, length, length - startIndex);
        }
        public static TResult[] Covert<TSource, TResult>
        (
            this TSource[] array,
            Converter<TSource, TResult> converter,
            int startIndex,
            int count
        )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }
            if (count < 0 || startIndex + count > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resources.Argument_OutOfRange_Count);
            }

            return ConvertCore(array, converter, startIndex, startIndex + count, count);
        }
        private static TResult[] ConvertCore<TSource, TResult>
        (
            this TSource[] array,
            Converter<TSource, TResult> converter,
            int startIndex,
            int endIndex,
            int length
        )
        {
            var newArray = new TResult[length];
            for (int i = startIndex; i < endIndex; i++)
            {
                newArray[i] = converter(array[i]);
            }

            return newArray;
        }

        public static void CopyTo<T>(this T[] array, T[] destArray)
        {
            Array.Copy(array, destArray, array.Length);
        }
        public static void CopyTo<T>(this T[] array, T[] destArray, int length)
        {
            Array.Copy(array, destArray, length);
        }
        public static void CopyTo<T>
        (
            this T[] array,
            int startIndex,
            T[] destArray,
            int destStartIndex
        )
        {
            Array.Copy(array, startIndex, destArray, destStartIndex, array.Length);
        }
        public static void CopyTo<T>
        (
            this T[] array,
            int startIndex,
            T[] destArray,
            int destStartIndex,
            int length
        )
        {
            Array.Copy(array, startIndex, destArray, destStartIndex, length);
        }

        public static bool Exists<T>(this T[] array, Predicate<T> match)
        {
            return Array.Exists(array, match);
        }
        public static bool Exists<T>(this T[] array, Predicate<T> match, int startIndex)
        {
            return FindIndex(array, match, startIndex) > 1;
        }
        public static bool Exists<T>(this T[] array, Predicate<T> match, int startIndex, int count)
        {
            return FindIndex(array, match, startIndex, count) > 1;
        }

        public static T Find<T>(this T[] array, Predicate<T> match)
        {
            return Array.Find(array, match);
        }
        public static T Find<T>(this T[] array, Predicate<T> match, int startIndex)
        {
            int index = Array.FindIndex(array, startIndex, match);
            return index >= 0 ? array[index] : default;
        }
        public static T Find<T>(this T[] array, Predicate<T> match, int startIndex, int count)
        {
            int index = Array.FindIndex(array, startIndex, count, match);
            return index >= 0 ? array[index] : default;
        }

        public static T[] FindAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindAll(array, match);
        }
        public static T[] FindAll<T>(this T[] array, Predicate<T> match, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }

            int length = array.Length;
            return FindAllCore(array, match, startIndex, length, length - startIndex);
        }
        public static T[] FindAll<T>(this T[] array, Predicate<T> match, int startIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }
            if (count < 0 || startIndex + count > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resources.Argument_OutOfRange_Count);
            }

            return FindAllCore(array, match, startIndex, startIndex + count, count);
        }
        private static T[] FindAllCore<T>
        (
            T[] array,
            Predicate<T> match,
            int startIndex,
            int endIndex,
            int capacity
        )
        {
            var list = new List<T>(capacity);
            for (int i = startIndex; i < endIndex; i++)
            {
                T item = array[i];
                if (match(item))
                {
                    list.Add(item);
                }
            }

            return list.ToArray();
        }

        public static int FindIndex<T>(T[] array, Predicate<T> match)
        {
            return Array.FindIndex(array, match);
        }
        public static int FindIndex<T>(T[] array, Predicate<T> match, int startIndex)
        {
            return Array.FindIndex(array, startIndex, match);
        }
        public static int FindIndex<T>(T[] array, Predicate<T> match, int startIndex, int count)
        {
            return Array.FindIndex(array, startIndex, count, match);
        }

        public static T FindLast<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindLast(array, match);
        }
        public static T FindLast<T>(this T[] array, Predicate<T> match, int startIndex)
        {
            int index = Array.FindLastIndex(array, startIndex, match);
            return index >= 0 ? array[index] : default;
        }
        public static T FindLast<T>(this T[] array, Predicate<T> match, int startIndex, int count)
        {
            int index = Array.FindLastIndex(array, startIndex, count, match);
            return index >= 0 ? array[index] : default;
        }

        public static int FindLastIndex<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindLastIndex(array, match);
        }
        public static int FindLastIndex<T>(this T[] array, Predicate<T> match, int startIndex)
        {
            return Array.FindLastIndex(array, startIndex, match);
        }
        public static int FindLastIndex<T>
        (
            this T[] array,
            Predicate<T> match,
            int startIndex,
            int count
        )
        {
            return Array.FindLastIndex(array, startIndex, count, match);
        }

        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            Array.ForEach(array, action);
        }
        public static void ForEach<T>(this T[] array, Action<T> action, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }

            ForEachCore(array, action, startIndex, array.Length);
        }
        public static void ForEach<T>(this T[] array, Action<T> action, int startIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }
            if (count < 0 || startIndex + count > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resources.Argument_OutOfRange_Count);
            }

            ForEachCore(array, action, startIndex, startIndex + count);
        }
        private static void ForEachCore<T>
        (
            T[] array,
            Action<T> action,
            int startIndex,
            int endIndex
        )
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                action(array[i]);
            }
        }

        public static void ForEach<T>(this T[] array, Action<T, int> action)
        {
            ForEachCore(array, action, 0, array.Length);
        }
        public static void ForEach<T>(this T[] array, Action<T, int> action, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }

            ForEachCore(array, action, startIndex, array.Length);
        }
        public static void ForEach<T>
        (
            this T[] array,
            Action<T, int> action,
            int startIndex,
            int count
        )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }
            if (count < 0 || startIndex + count > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resources.Argument_OutOfRange_Count);
            }

            ForEachCore(array, action, startIndex, startIndex + count);
        }
        private static void ForEachCore<T>
        (
            T[] array,
            Action<T, int> action,
            int startIndex,
            int endIndex
        )
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                action(array[i], i);
            }
        }

        public static void ForEachReverse<T>(this T[] array, Action<T> action)
        {
            ForEachReverseCore(array, action, array.Length, 0);
        }
        public static void ForEachReverse<T>(this T[] array, Action<T> action, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }

            ForEachReverseCore(array, action, startIndex, 0);
        }
        public static void ForEachReverse<T>
        (
            this T[] array,
            Action<T> action,
            int startIndex,
            int count
        )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }
            if (count < 0 || startIndex - count < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resources.Argument_OutOfRange_Count);
            }

            ForEachReverseCore(array, action, startIndex, startIndex - count);
        }
        private static void ForEachReverseCore<T>
        (
            T[] array,
            Action<T> action,
            int startIndex,
            int endIndex
        )
        {
            for (int i = startIndex; i > endIndex; i--)
            {
                action(array[i]);
            }
        }

        public static void ForEachReverse<T>(this T[] array, Action<T, int> action)
        {
            ForEachReverseCore(array, action, array.Length, 0);
        }
        public static void ForEachReverse<T>(this T[] array, Action<T, int> action, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }

            ForEachReverseCore(array, action, startIndex, 0);
        }
        public static void ForEachReverse<T>
        (
            this T[] array,
            Action<T, int> action,
            int startIndex,
            int count
        )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }
            if (count < 0 || startIndex - count < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resources.Argument_OutOfRange_Count);
            }

            ForEachReverseCore(array, action, startIndex, startIndex - count);
        }
        private static void ForEachReverseCore<T>
        (
            T[] array,
            Action<T, int> action,
            int startIndex,
            int endIndex
        )
        {
            for (int i = startIndex; i > endIndex; i--)
            {
                action(array[i], i);
            }
        }

        public static int IndexOf<T>(this T[] array, T value)
        {
            return Array.IndexOf(array, value);
        }
        public static int IndexOf<T>(this T[] array, T value, int startIndex)
        {
            return Array.IndexOf(array, value, startIndex);
        }
        public static int IndexOf<T>(this T[] array, T value, int startIndex, int count)
        {
            return Array.IndexOf(array, value, startIndex, count);
        }

        public static int LastIndexOf<T>(this T[] array, T value)
        {
            return Array.LastIndexOf(array, value);
        }
        public static int LastIndexOf<T>(this T[] array, T value, int startIndex)
        {
            return Array.LastIndexOf(array, value, startIndex);
        }
        public static int LastIndexOf<T>(this T[] array, T value, int startIndex, int count)
        {
            return Array.LastIndexOf(array, value, startIndex, count);
        }

        public static void Reverse<T>(this T[] array)
        {
            Array.Reverse(array);
        }
        public static void Reverse<T>(this T[] array, int startIndex, int length)
        {
            Array.Reverse(array, startIndex, length);
        }

        public static void Sort<T>(this T[] array)
        {
            Array.Sort(array);
        }
        public static void Sort<T>(this T[] array, int index, int length)
        {
            Array.Sort(array, index, length);
        }
        public static void Sort<T>(this T[] array, IComparer<T> comparer)
        {
            Array.Sort(array, comparer);
        }
        public static void Sort<T>(this T[] array, Comparison<T> comparison)
        {
            Array.Sort(array, comparison);
        }
        public static void Sort<T>(this T[] array, int index, int length, IComparer<T> comparer)
        {
            Array.Sort(array, index, length, comparer);
        }
        public static void Sort<T>(this T[] array, int index, int length, Comparison<T> comparison)
        {
            Array.Sort
            (
                array,
                index,
                length,
                comparison == null ? null : Comparer<T>.Create(comparison)
            );
        }

        public static bool TrueForAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.TrueForAll(array, match);
        }
        public static bool TrueForAll<T>(this T[] array, Predicate<T> match, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }

            return TrueForAllCore(array, match, startIndex, array.Length);
        }
        public static bool TrueForAll<T>
        (
            this T[] array,
            Predicate<T> match,
            int startIndex,
            int count
        )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, Resources.Argument_OutOfRange_Index);
            }
            if (count < 0 || startIndex + count > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resources.Argument_OutOfRange_Count);
            }

            return TrueForAllCore(array, match, startIndex, count);
        }
        public static bool TrueForAllCore<T>
        (
            T[] array,
            Predicate<T> match,
            int startIndex,
            int endIndex
        )
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                if (!match(array[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}