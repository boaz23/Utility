using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utility.Linq
{
    public abstract class YieldEnumerator<T> : Disposable, IEnumerator<T>, IEnumerable<T>
    {
        protected readonly int _initialThreadId;

        public YieldEnumerator()
        {
            _initialThreadId = Environment.CurrentManagedThreadId;
        }

        protected abstract IEnumerator<T> ProvideNewEnumerator();
        public abstract bool MoveNext();

        protected override void Dispose(bool disposing) { }

        public virtual void Reset() => throw new NotSupportedException();

        public virtual IEnumerator<T> GetEnumerator()
        {
            IEnumerator<T> enumerator;
            if (_initialThreadId == Environment.CurrentManagedThreadId)
            {
                enumerator = this;
            }
            else
            {
                enumerator = ProvideNewEnumerator();
            }

            return enumerator;
        }

        public T Current { get; protected set; }

        [DebuggerHidden]
        object IEnumerator.Current => Current;

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}