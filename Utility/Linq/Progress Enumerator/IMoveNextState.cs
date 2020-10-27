namespace Utility.Linq
{
    partial class ProgressEnumerator<T>
    {
        private interface IMoveNextState
        {
            bool MoveNext();
            bool HasEnumerationStarted { get; }
            bool HasEnumerationEnded { get; }
        }
    }
}