using System;

namespace Utility.Interop
{
    /// <summary>
    /// The sole reason for this interface is that we use a non-generic stack because if we did use a generic stack, the stack would be limited a single type of wrapped COM objects, which in turn, defeats the purpose of it.
    /// </summary>
    public interface IComReleaser : IDisposable
    {
        object ComObject { get; }
    }

    /// <summary>
    /// This interface exists for clarification.
    /// </summary>
    /// <typeparam name="T">The type of the COM object</typeparam>
    public interface IComReleaser<T> : IComReleaser
    {
        new T ComObject { get; }
    }
}