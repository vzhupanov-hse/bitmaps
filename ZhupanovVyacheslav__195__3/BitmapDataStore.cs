namespace ZhupanovVyacheslav__195__3
{
    public class BitmapDataStore : DataStore
    {
        private MutableArray<ulong> arr;
        private int bit_count;
        private const int unitSize = 64;
        public const int bitmapSize = 1024;

        public BitmapDataStore()
        {
            arr = new MutableArray<ulong>(bitmapSize);
            bit_count = 0;
        }

        public static DataStore operator &(BitmapDataStore ds, BitmapDataStore ds2)
        {
            int k = 0;
            for (int i = 0; i < BitmapDataStore.bitmapSize; i++)
                k += Operations.CountOfBits(ds.arr[i] & ds2.arr[i]);
            if (k > maxValue)
            {
                BitmapDataStore new_bitmap = new BitmapDataStore()
                {
                    bit_count = k
                };
                for (int i = 0; i < BitmapDataStore.bitmapSize; i++)
                    new_bitmap.arr[i] = ds.arr[i] & ds2.arr[i];
                return new_bitmap;
            }
            else
            {
                ArrayDataStore new_bitmap = new ArrayDataStore();
                for (int i = 0; i < BitmapDataStore.bitmapSize; i++)
                {
                    ulong numb = ds.arr[i] & ds2.arr[i];
                    while (numb != 0)
                    {
                        ulong t = numb & ((~numb) + 1);
                        new_bitmap.PushBack(Operations.CountOfBits(t - 1));
                        numb &= (numb - 1);
                    }
                }
                return new_bitmap;
            }
        }

        public static DataStore operator &(BitmapDataStore bds, ArrayDataStore ads)
        {
            ArrayDataStore new_ads = new ArrayDataStore();
            for (int i = 0; i < ads.positions.Size(); i++)
                if (bds.Get(ads.positions[i]))
                    new_ads.PushBack(ads.positions[i]);
            return new_ads;
        }

        public override bool Get(int num)
        {
            int pos = num / unitSize;
            int pos2 = num % unitSize;
            return Operations.GetBit(arr[pos], pos2);
        }

        public override void Set(int numb, bool value)
        {
            int pos = numb / unitSize;
            int pos2 = numb % unitSize;
            if ((!Get(pos)) && value)
                bit_count++;
            if (Get(pos) && (!value))
                bit_count--;
            arr[pos] = Operations.SetBit(arr[pos], pos2, value);
        }

        public override int BitCount() => bit_count;
    }
}
