namespace ZhupanovVyacheslav__195__3
{
    public static class Operations
    {
        public static int CountOfBits(ulong numb)
        {
            int res = 0;
            while (numb != 0)
            {
                numb &= (numb - 1);
                res++;
            }
            return res;
        }

        private static int GetIntPosition(int pos) => (int)(64 - pos - 1);

        public static bool GetBit(ulong numb, int pos) => (numb & ((ulong)1 << GetIntPosition(pos))) > 0;


        public static ulong SetBit(ulong numb, int pos, bool value)
        {
            int intPos = GetIntPosition(pos);
            ulong res = numb;
            if (value)
                res |= ((ulong)1 << intPos);
            else
                res &= (~((ulong)1 << intPos));
            return res;
        }
    }
}
