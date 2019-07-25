using System.Collections;
using System.Collections.Generic;

namespace Example2
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        void Write(T value);
        T Read();
    }
}
