namespace ZhupanovVyacheslav__195__3
{
    public abstract class DataStore
    {
        public const int maxValue = 4096;

        public static DataStore operator &(DataStore ds, DataStore ds2)
        {
            if (ds is BitmapDataStore && ds2 is BitmapDataStore)
                return (BitmapDataStore)ds & (BitmapDataStore)ds2;
            else if (ds is BitmapDataStore && ds2 is ArrayDataStore)
                return (BitmapDataStore)ds & (ArrayDataStore)ds2;
            else if (ds is ArrayDataStore && ds2 is BitmapDataStore)
                return (ArrayDataStore)ds & (BitmapDataStore)ds2;
            else
                return (ArrayDataStore)ds & (ArrayDataStore)ds2;
        }

        public abstract int BitCount();
        public abstract bool Get(int num);
        public abstract void Set(int num, bool value);
    }
}
