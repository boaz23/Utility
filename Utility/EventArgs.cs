using System;

namespace Utility
{
    public interface IEventArgs<T>
    {
        T Data { get; }
    }

    /// <summary>
    /// Event args which contain data
    /// </summary>
    /// <typeparam name="T">The type of the data object to be stored</typeparam>
    public class EventArgs<T> : EventArgs, IEventArgs<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs{T}"/> class
        /// </summary>
        /// <param name="data">The data of the event args</param>
        public EventArgs(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the data object associated with this event args.
        /// </summary>
        public T Data { get; }
    }
}