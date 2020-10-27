namespace Utility.Linq
{
    partial class ProgressEnumerator<T>
    {
        private class BeforeEnumerationStart : IMoveNextState
        {
            private readonly ProgressEnumerator<T> enumerator;

            public BeforeEnumerationStart(ProgressEnumerator<T> enumerator)
            {
                this.enumerator = enumerator;
            }

            public bool HasEnumerationStarted => false;
            public bool HasEnumerationEnded => false;

            public bool MoveNext()
            {
                ProgressEnumerator<T> enumerator = this.enumerator;

                bool hasNext = enumerator.InnerEnumerator.MoveNext();
                if (hasNext)
                {
                    enumerator._moveNextState = new MidEnumeration(enumerator);
                }
                else
                {
                    enumerator._moveNextState = AfterEnumerationEnd.Instance;
                }

                return hasNext;
            }
        }
    }
}