using System;
using System.Collections;
using System.Collections.Generic;

namespace Utility.Linq
{
    public partial class ProgressEnumerator<T> : Disposable, IEnumerator<T>
    {
        private IMoveNextState _moveNextState;

        public ProgressEnumerator(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            InnerEnumerator = enumerable.GetEnumerator();
            Initialize();
        }

        public IEnumerator<T> InnerEnumerator { get; }

        public bool HasEnumerationStarted => _moveNextState.HasEnumerationStarted;
        public bool HasEnumerationEnded => _moveNextState.HasEnumerationEnded;

        public T Current => InnerEnumerator.Current;

        public virtual bool MoveNext()
        {
            return _moveNextState.MoveNext();
        }

        public virtual void Reset()
        {
            InnerEnumerator.Reset();
            Initialize();
        }
        private void Initialize()
        {
            _moveNextState = new BeforeEnumerationStart(this);
        }

        object IEnumerator.Current => Current;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                InnerEnumerator.Dispose();
            }
        }
    }
}