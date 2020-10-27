using System;

namespace Utility.Interop
{
    public class ComReleasingEventArgs<T> : EventArgs where T : class
    {
        public ComReleasingEventArgs(T comObject)
        {
            this.ComObject = comObject;
        }

        public T ComObject { get; protected internal set; }
    }
}