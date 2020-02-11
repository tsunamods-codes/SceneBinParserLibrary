using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneParser.Interface
{
    interface ByteHandle<T>
    {
        T Parse(byte[] raw);
        byte[] Encode(T obj);
    }

    abstract public class ByteHandler<T> : ByteHandle<T>
    {
        abstract public T Parse(byte[] raw);
        abstract public byte[] Encode(T obj);

    }
}
