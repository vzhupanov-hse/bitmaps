namespace ZhupanovVyacheslav__195__3
{
    public abstract class Bitmap
    {
        public MutableArray<DataStore> arr;
        public abstract void And(Bitmap other);
        public abstract void Set(int i, bool value);
        public abstract bool Get(int i);
        public bool IsEmpty { get; set; }
    }
}
