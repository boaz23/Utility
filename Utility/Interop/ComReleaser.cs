using System;
using System.Runtime.InteropServices;

namespace Utility.Interop
{
    internal class ComReleaser
    {
        internal const bool DEFAULT_FINAL_RELEASE = false;
    }

    /// <summary>
    /// Automates the disposal of a referenced COM object.
    /// When the <see cref="ComReleaser{T}"/> instance is disposing, it fires an event in which the developer should close the connection of the COM object to any unmanaged resources,
    /// and then, this <see cref="ComReleaser{T}"/> instance releases all references to the COM object by calling <see cref="Marshal.FinalReleaseComObject(object)"/> on the COM object.
    /// </summary>
    /// <typeparam name="T">The type of the COM object</typeparam>
    public class ComReleaser<T> : Disposable, IComReleaser<T> where T : class
    {
        protected T comObj;

        public ComReleaser(T comObj) : this(comObj, ComReleaser.DEFAULT_FINAL_RELEASE, null) { }
        public ComReleaser(T comObj, bool finalRelease) : this(comObj, finalRelease, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ComReleaser{T}"/> class, wrapping the specified COM object and automatically disposing of it.
        /// Potentially specifying events to be fired when this instance is disposing and after it has been disposed.
        /// </summary>
        /// <param name="comObj">The COM object</param>
        /// <param name="beforeReleasing">The cleanup action to perform before completely releasing the COM object</param>
        /// <exception cref="ArgumentNullException">comObj is null.</exception>
        /// <exception cref="ArgumentException">The specified object is not a COM object</exception>
        public ComReleaser
        (
            T comObj,
            EventHandler<ComReleaser<T>, ComReleasingEventArgs<T>> beforeReleasing
        ) : this(comObj, ComReleaser.DEFAULT_FINAL_RELEASE, beforeReleasing) { }
        public ComReleaser
        (
            T comObj,
            bool finalRelease,
            EventHandler<ComReleaser<T>, ComReleasingEventArgs<T>> beforeReleasing
        )
        {
            if (comObj == null)
            {
                throw new ArgumentNullException(nameof(comObj));
            }
            if (!Marshal.IsComObject(comObj))
            {
                throw new ArgumentException("Object must be a COM RCW.", nameof(comObj));
            }

            this.comObj = comObj;
            this.FinalRelease = finalRelease;
            this.BeforeReleasing = beforeReleasing;
        }

        /// <summary>
        /// Returns the wrapped COM obejct
        /// </summary>
        public T ComObject
        {
            get
            {
                this.ThorwIfDisposed();
                return this.comObj;
            }
        }
        public bool FinalRelease { get; protected set; }

        protected event EventHandler<ComReleaser<T>, ComReleasingEventArgs<T>> BeforeReleasing;

        protected override void Dispose(bool disposing)
        {
            T comObject = this.comObj;
            var eventArgs = new ComReleasingEventArgs<T>(comObject);
            this.BeforeReleasing?.Invoke(this, eventArgs);
            if (this.FinalRelease)
            {
                Marshal.FinalReleaseComObject(comObject);
            }
            else
            {
                Marshal.ReleaseComObject(comObject);
            }

            eventArgs.ComObject = null;
            this.BeforeReleasing = null;
            this.comObj = null;
        }

        public static implicit operator T(ComReleaser<T> comReleaser)
        {
            return comReleaser.comObj;
        }

        object IComReleaser.ComObject => this.comObj;
    }
}