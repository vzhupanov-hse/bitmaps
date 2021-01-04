using System;

namespace ZhupanovVyacheslav__195__3
{
    public class RoaringBitmap : Bitmap
    {
        private const int chunkSize = 1 << 16;

        public RoaringBitmap()
        {
            arr = new MutableArray<DataStore>();
            IsEmpty = true;
        }

        public override void And(Bitmap other)
        {
            while (arr.Size() < other.arr.Size())
                arr.Push(new ArrayDataStore(), -1);
            while (arr.Size() > other.arr.Size())
                other.arr.Push(new ArrayDataStore(), -1);
            for (int i = 0; i < Math.Min(arr.Size(), other.arr.Size()); i++)
                arr[i] = arr[i] & other.arr[i];
        }

        public override bool Get(int numb)
        {
            while (arr.Size() <= numb / chunkSize)
                arr.Push(new ArrayDataStore(), -1);
            return arr[numb / chunkSize].Get(numb % chunkSize);
        }

        public override void Set(int numb, bool value)
        {
            while (arr.Size() <= numb / chunkSize)
                arr.Push(new ArrayDataStore(), -1);
            arr[numb / chunkSize].Set(numb % chunkSize, value);
            IsEmpty = false;
        }
    }
}
