using System;
using System.Collections;
using System.Collections.Generic;

using Utility.Properties;

namespace Utility.Interop
{
    /// <summary>
    /// Automates the disposal of COM objects in the collection.
    /// When the <see cref="DisposableCollection"/> instance is disposing, it pops every COM object in it and calls it's <see cref="IDisposable.Dispose"/> method in which the COM objects frees any unmanaged resources.
    /// We use non-generic stack because if we did use a generic stack, the stack would be limited a single type of wrapped COM objects, which in turn, defeats the purpose of it.
    /// </summary>
    public class DisposableCollection : Disposable, ICollection<IDisposable>
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="DisposableCollection"/> class that is empty and has the default initial capacity.
        /// </summary>
        public DisposableCollection() : this(new Stack<IDisposable>()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableCollection"/> class that is empty and has the specified initial capacity or the default initial capacity, whichever is greater.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="DisposableCollection"/> can contain</param>
        /// <exception cref="ArgumentOutOfRangeException">capacity is less than zero.</exception>
        public DisposableCollection(int capacity) : this(new Stack<IDisposable>(capacity)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableCollection"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="disposables">The collection to copy elements from.</param>
        /// <exception cref="ArgumentNullException">dcos is null.</exception>
        public DisposableCollection(IEnumerable<IDisposable> disposables) :
            this(new Stack<IDisposable>(disposables))
        { }

        private DisposableCollection(Stack<IDisposable> disposables)
        {
            this.Disposables = disposables;
        }

        public int Count => this.Disposables.Count;

        protected Stack<IDisposable> Disposables { get; }

        public IDisposable Add(IDisposable disposable)
        {
            this.Disposables.Push(disposable);
            return disposable;
        }

        public T Add<T>(T comObject) where T : class
        {
            return this.Add(comObject, ComReleaser.DEFAULT_FINAL_RELEASE, null);
        }
        public T Add<T>(T comObject, bool finalRelease) where T : class
        {
            return this.Add(comObject, finalRelease, null);
        }
        /// <summary>
        /// Push a new <see cref="ComReleaser{T}"/> that wraps the COM object and is resposible for the mechanism of disposing of it's COM object into the stack.
        /// Potentially specifying events to be fired when this COM object is disposing and after it has been disposed.
        /// </summary>
        /// <typeparam name="T">The type of the COM object</typeparam>
        /// <param name="comObject">The COM object</param>
        /// <param name="beforeReleasing">The cleanup action to perform before completely releasing the COM object</param>
        /// <returns>For convenience, the COM object</returns>
        /// <exception cref="ArgumentNullException">comObj is null.</exception>
        /// <exception cref="ArgumentException">The specified object is not a COM object</exception>
        public T Add<T>(T comObject, EventHandler<ComReleaser<T>, ComReleasingEventArgs<T>> beforeReleasing) where T : class
        {
            return this.Add(comObject, ComReleaser.DEFAULT_FINAL_RELEASE, beforeReleasing);
        }
        public virtual T Add<T>(T comObject, bool finalRelease, EventHandler<ComReleaser<T>, ComReleasingEventArgs<T>> beforeReleasing) where T : class
        {
            this.Disposables.Push(new ComReleaser<T>(comObject, finalRelease, beforeReleasing));
            return comObject;
        }

        public void Clear()
        {
            this.Disposables.Clear();
        }

        /// <summary>
        /// Releases any unmanaged resources controlled by this stack (all of the COM objects).
        /// </summary>
        /// <param name="disposing">Indicates whether the call came from the finalizer or the dispose method</param>
        /// <exception cref="AggregateException">
        /// One or more errors occurred in the disposal of one or more of the collection's COM objects.
        /// If disposing is true, this exception will hold all the errors that occured during the disposal of every failed <see cref="IDisposable.Dispose"/> call on the wrapping object.
        /// </exception>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stack<IDisposable> disposables = this.Disposables;
                var exceptions = new List<Exception>(this.Count);
                while (disposables.Count > 0)
                {
                    IDisposable disposable = disposables.Pop();
                    try
                    {
                        disposable.Dispose();
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(ex);
                    }
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(Resources.DisposableCollection_DisposingError, exceptions);
                }
            }
            else
            {
                this.Disposables.Clear();
            }
        }

        bool ICollection<IDisposable>.IsReadOnly => false;

        void ICollection<IDisposable>.Add(IDisposable disposable)
        {
            this.Add(disposable);
        }
        bool ICollection<IDisposable>.Contains(IDisposable disposable)
        {
            return this.Disposables.Contains(disposable);
        }
        void ICollection<IDisposable>.CopyTo(IDisposable[] array, int arrayIndex)
        {
            this.Disposables.CopyTo(array, arrayIndex);
        }
        bool ICollection<IDisposable>.Remove(IDisposable disposable)
        {
            throw new NotSupportedException();
        }

        IEnumerator<IDisposable> IEnumerable<IDisposable>.GetEnumerator()
        {
            return this.Disposables.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Disposables.GetEnumerator();
        }
    }
}