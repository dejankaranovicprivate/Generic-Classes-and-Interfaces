using System;
using System.Collections;
using System.Collections.Generic;

namespace Example2
{
    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
            {
                var discard = _queue.Dequeue();
                OnItemDiscarded(discard, value);
            }
        }

        private void OnItemDiscarded(T discard, T value)
        {
            if(ItemDiscarded != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);
                ItemDiscarded(this, args);
            }
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

        public bool IsFull
        {
            get
            {
                return _queue.Count == _capacity;
            }
        }
    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T discard, T newitem)
        {
            ItemDiscarded = discard;
            NewItem = newitem;
        }

        public T ItemDiscarded { get; set; }
        public T NewItem { get; set; }
    }



    //public class CircularBuffer<T> : Buffer<T>
    //{
    //    private T[] _buffer;
    //    private int _start;
    //    private int _end;

    //    public CircularBuffer() : this(capacity: 10)
    //    {
    //    }

    //    public CircularBuffer(int capacity)
    //    {
    //        _buffer = new T[capacity + 1];
    //        _start = 0;
    //        _end = 0;
    //    }

    //    public void Write(T value)
    //    {
    //        _buffer[_end] = value;
    //        _end = (_end + 1) % _buffer.Length;
    //        if(_end == _start)
    //        {
    //            _start = (_start + 1) % _buffer.Length;
    //        }
    //    }

    //    public T Read()
    //    {
    //        T result = _buffer[_start];
    //        _start = (_start + 1) % _buffer.Length;
    //        return result;
    //    }

    //    public int Capacity
    //    {
    //        get { return _buffer.Length; }
    //    }

    //    public bool IsEmpty
    //    {
    //        get { return _end == _start; }
    //    }

    //    public bool IsFull
    //    {
    //        get { return (_end + 1) % _buffer.Length == _start; }
    //    }

    //}
}
