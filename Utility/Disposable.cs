using System;

namespace Utility
{
    /// <summary>
    /// Provides a base class for implementing the <see cref="IDisposable"/> interface.
    /// </summary>
    public abstract class Disposable : IDisposable
    {
        /// <summary>
        /// Releases any unmanaged resources controlled by this object.
        /// </summary>
        public void Dispose()
        {
            Disposing(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get a value indicating whether this object has been disposed of.
        /// </summary>
        public bool Disposed { get; private set; }

        /// <summary>
        /// Releases any unmanaged resources controlled by this object.
        /// </summary>
        /// <param name="disposing">Indicates whether the call came from the finalizer or the dispose method</param>
        protected abstract void Dispose(bool disposing);

        protected virtual ObjectDisposedException GetDisposedException()
        {
            return new ObjectDisposedException(null);
        }

        protected void ThorwIfDisposed()
        {
            if (Disposed)
            {
                throw GetDisposedException();
            }
        }

        protected void Disposing(bool disposing)
        {
            if (Disposed)
            {
                return;
            }

            Dispose(disposing);
            Disposed = true;
        }
    }
}