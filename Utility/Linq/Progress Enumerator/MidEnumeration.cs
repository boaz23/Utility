namespace Utility.Linq
{
    partial class ProgressEnumerator<T>
    {
        private class MidEnumeration : IMoveNextState
        {
            private readonly ProgressEnumerator<T> enumerator;

            public MidEnumeration(ProgressEnumerator<T> enumerator)
            {
                this.enumerator = enumerator;
            }

            public bool HasEnumerationStarted => true;
            public bool HasEnumerationEnded => false;

            public bool MoveNext()
            {
                ProgressEnumerator<T> enumerator = this.enumerator;

                bool hasNext = enumerator.InnerEnumerator.MoveNext();
                if (!hasNext)
                {
                    enumerator._moveNextState = AfterEnumerationEnd.Instance;
                }

                return hasNext;
            }
        }
    }
}