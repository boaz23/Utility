namespace Utility.Linq
{
    partial class ProgressEnumerator<T>
    {
        private class AfterEnumerationEnd : IMoveNextState
        {
            private AfterEnumerationEnd() { }

            public static AfterEnumerationEnd Instance { get; } = new AfterEnumerationEnd();

            public bool HasEnumerationStarted => true;
            public bool HasEnumerationEnded => true;

            public bool MoveNext()
            {
                return false;
            }
        }
    }
}