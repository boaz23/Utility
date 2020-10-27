using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utility.Properties;

namespace Utility.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> AsEnumerable<TSource>(params TSource[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            return items;
        }

        public static bool IsEmpty<TSource>(this IEnumerable<TSource> enumerable)
        {
            return !enumerable.Any();
        }

        public static bool IsNullOrEmpty<T>(IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is TSource[] array)
            {
                return array;
            }

            if (source is ICollection<TSource> collection)
            {
                return Collections.Generic.CollectionExtensions.ToArrayCore(collection);
            }

            return Enumerable.ToArray(source);
        }

        /// <summary>
        /// Returns a value indicating whether the second enumerable is entirely contained in the first enumerable, potentially passing an <see cref="IEqualityComparer{TSource}"/> to be used to determine whether two items are considered equal.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the enumerables</typeparam>
        /// <param name="first">The first enumerable</param>
        /// <param name="second">The second enumerable</param>
        /// <param name="comparer">If specified, a comparer to be used to determine whether two items are considered equal</param>
        /// <returns>A value indicating whether the second enumerable is entirely contained in the first enumerable</returns>
        /// <exception cref="ArgumentNullException">first or second are null</exception>
        public static bool ContainsAll<TSource>
        (
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer = null
        )
        {
            return second.SequenceEqual(first.Intersect(second, comparer), comparer);
        }

        /// <summary>
        /// Returns a value indicating whether an element from the second enumerable is contained in the first enumerable,
        /// potentially passing an <see cref="IEqualityComparer{TSource}"/> to be used to determine whether two items are considered equal.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the enumerables</typeparam>
        /// <param name="first">The first enumerable</param>
        /// <param name="second">The second enumerable</param>
        /// <param name="comparer">If specified, a comparer to be used to determine whether two items are considered equal</param>
        /// <returns>A value indicating whether an element from the second enumerable is contained in the first enumerable</returns>
        /// <exception cref="ArgumentNullException">first or second are null</exception>
        public static bool ContainsAny<TSource>
        (
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer = null
        )
        {
            return first.Intersect(second, comparer).Any();
        }

        /// <summary>
        /// Executes an action on each elements of the enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the enumerable</typeparam>
        /// <param name="source">The enumerable</param>
        /// <param name="action">The action to be invoked on an element</param>
        /// <exception cref="ArgumentNullException">source or action are null</exception>
        public static void ForEach<TSource>
        (
            this IEnumerable<TSource> source,
            Action<TSource> action
        )
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (TSource item in source)
            {
                action(item);
            }
        }
        /// <summary>
        /// Executes an action on each elements of the enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the enumerable</typeparam>
        /// <param name="source">The enumerable</param>
        /// <param name="action">The action to be invoked on an element. The first parameter of the function is it's index in the enumerable.</param>
        /// <exception cref="ArgumentNullException">source or action are null</exception>
        public static void ForEach<TSource>
        (
            this IEnumerable<TSource> source,
            Action<TSource, int> action
        )
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            int i = -1;
            foreach (TSource item in source)
            {
                checked { i++; }
                action(item, i);
            }
        }

        /// <summary>
        /// Returns a value indicating whether the two sequence of elements are equal by comparing their elements,
        /// potentially passing an <see cref="IEqualityComparer{TSource}"/> to be used to determine whether two items are considered equal.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the enumerables</typeparam>
        /// <param name="first">The first enumerable</param>
        /// <param name="second">The second enumerable</param>
        /// <param name="comparer">If specified, a comparer to be used to determine whether two items are considered equal</param>
        /// <returns>A value indicating whether an element from the second enumerable is contained in the first enumerable</returns>
        /// <exception cref="ArgumentNullException">first or second are null</exception>
        public static bool SequenceEqual<TSource>
        (
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer = null
        )
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            if (!CompareICollectionCount(first, second))
            {
                return false;
            }

            return Enumerable.SequenceEqual(first, second, comparer);
        }

        public static IEnumerable<TSource> CloneElements<TSource>(this IEnumerable<TSource> source)
            where TSource : ICloneable
        {
            return source.Select(x => (TSource)x.Clone());
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source)
        {
            return OrderBy(source, null);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource>
        (
            this IEnumerable<TSource> source,
            IComparer<TSource> comparer
        )
        {
            return source.OrderBy(Funcs<TSource>.Identity, comparer);
        }

        public static IOrderedEnumerable<TSource> OrderByDescending<TSource>
        (
            this IEnumerable<TSource> source
        )
        {
            return OrderByDescending(source, null);
        }
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource>
        (
            this IEnumerable<TSource> source,
            IComparer<TSource> comparer
        )
        {
            return source.OrderByDescending(Funcs<TSource>.Identity, comparer);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>
        (
            this IEnumerable<TSource> source,
            SortOrder sortOrder
        )
        {
            return OrderBy(source, null, sortOrder);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource>
        (
            this IEnumerable<TSource> source,
            IComparer<TSource> comparer,
            SortOrder sortOrder
        )
        {
            return OrderBy(source, Funcs<TSource>.Identity, comparer, sortOrder);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>
        (
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            SortOrder sortOrder
        )
        {
            return OrderBy(source, keySelector, null, sortOrder);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>
        (
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer,
            SortOrder sortOrder
        )
        {
            return sortOrder == SortOrder.Ascending ?
                source.OrderBy(keySelector, comparer) :
                source.OrderByDescending(keySelector, comparer);
        }

        public static IEnumerable<TFirst> Except<TFirst, TSecond, TKey>
        (
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TKey> firstKeySelector,
            Func<TSecond, TKey> secondKeySelector
        )
        {
            return Except(first, second, firstKeySelector, secondKeySelector, null, x => x);
        }
        public static IEnumerable<TFirst> Except<TFirst, TSecond, TKey>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TKey> firstKeySelector,
            Func<TSecond, TKey> secondKeySelector,
            IEqualityComparer<TKey> equalityComparer
        )
        {
            return Except(first, second, firstKeySelector, secondKeySelector, equalityComparer, x => x);
        }
        public static IEnumerable<TResult> Except<TFirst, TSecond, TKey, TResult>
        (
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TKey> firstKeySelector,
            Func<TSecond, TKey> secondKeySelector,
            Func<TFirst, TResult> resultSelector
        )
        {
            return Except(first, second, firstKeySelector, secondKeySelector, null, resultSelector);
        }
        public static IEnumerable<TResult> Except<TFirst, TSecond, TKey, TResult>
        (
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TKey> firstKeySelector,
            Func<TSecond, TKey> secondKeySelector,
            IEqualityComparer<TKey> equalityComparer,
            Func<TFirst, TResult> resultSelector
        )
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            if (firstKeySelector == null)
            {
                throw new ArgumentNullException(nameof(firstKeySelector));
            }
            if (secondKeySelector == null)
            {
                throw new ArgumentNullException(nameof(secondKeySelector));
            }
            if (resultSelector == null)
            {
                throw new ArgumentNullException(nameof(resultSelector));
            }

            return ExceptIterator(first, second, firstKeySelector, secondKeySelector, equalityComparer, resultSelector);
        }

        private static IEnumerable<TResult> ExceptIterator<TFirst, TSecond, TKey, TResult>
        (
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TKey> firstKeySelector,
            Func<TSecond, TKey> secondKeySelector,
            IEqualityComparer<TKey> equalityComparer,
            Func<TFirst, TResult> resultSelector
        )
        {
            var hashSet = new HashSet<TKey>(equalityComparer);
            foreach (TSecond element in second)
            {
                hashSet.Add(secondKeySelector(element));
            }
            foreach (TFirst element in first)
            {
                if (hashSet.Add(firstKeySelector(element)))
                {
                    yield return resultSelector(element);
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> enumerable, int splitBatchSize)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }
            if (splitBatchSize < 1)
            {
                throw new ArgumentException(Resources.Argument_InvalidSplitSize, nameof(splitBatchSize));
            }

            return SplitIterator(enumerable, splitBatchSize);
        }
        private static IEnumerable<IEnumerable<T>> SplitIterator<T>(IEnumerable<T> enumerable, int splitBatchSize)
        {
            using (var enumerator = new ProgressEnumerator<T>(enumerable))
            {
                while (!enumerator.HasEnumerationEnded && enumerator.MoveNext())
                {
                    yield return SplitItemsIterator();
                }

                IEnumerable<T> SplitItemsIterator()
                {
                    int i = 0;
                    do
                    {
                        yield return enumerator.Current;
                    } while (++i < splitBatchSize && enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Returns the amount of items in an enumerable.
        /// This method tries to check if the enumerable is an <see cref="ICollection{TSource}"/> or <see cref="ICollection"/>,
        /// if it is one of them, it returns the value of <see cref="ICollection{TSource}.Count"/> or <see cref="ICollection.Count"/> respectively.
        /// If it is no more than just an <see cref="IEnumerable{TSource}"/>, then the method calls <see cref="Enumerable.Count{TSource}(IEnumerable{TSource})"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the enumerables</typeparam>
        /// <param name="source">The enumerable</param>
        /// <returns>Yhe amount of items in the enumerable (smartly)</returns>
        public static int GetCount<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int count = Count(source);
            if (count < 0)
            {
                return source.Count();
            }

            return count;
        }

        /// <summary>
        /// Compares the count of each enumerable by trying to cast them into <see cref="ICollection{TSource}"/> and compare the <see cref="ICollection{TSource}.Count"/> property.
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first enumerables</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second enumerables</typeparam>
        /// <param name="first">The first enumerable</param>
        /// <param name="second">The second enumerable</param>
        /// <returns>True if the method successfully casted both enumerables to <see cref="ICollection{TSource}"/> and their <see cref="ICollection{TSource}.Count"/> properties are equals, otherwise false.</returns>
        public static bool CompareICollectionCount<TFirst, TSecond>
        (
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second
        )
        {
            int firstCount = Count(first);
            int secondCount = Count(second);

            if (firstCount >= 0 && secondCount >= 0 && firstCount != secondCount)
            {
                return false;
            }

            return true;
        }

        private static int Count<TSource>(IEnumerable<TSource> source)
        {
            if (source is ICollection<TSource> sourceICollectionT)
            {
                return sourceICollectionT.Count;
            }

            return -1;
        }
    }
}