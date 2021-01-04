namespace ZhupanovVyacheslav__195__3
{
    public class ArrayDataStore : DataStore
    {
        public MutableArray<int> positions;

        public ArrayDataStore()
        {
            positions = new MutableArray<int>();
        }

        public void PushBack(int item)
        {
            positions.Push(item, -1);
        }

        private int FindPos(int num)
        {
            int a = 0;
            int s = positions.Size();
            while (a + 1 < s)
            {
                int m = (a + s) / 2;
                if (positions[m] <= num)
                    a = m;
                else
                    s = m;
            }
            return a;
        }

        public static DataStore operator &(ArrayDataStore ads, BitmapDataStore bds)
        {
            ArrayDataStore new_arr = new ArrayDataStore();
            for (int i = 0; i < ads.positions.Size(); i++)
                if (bds.Get(ads.positions[i]))
                    new_arr.PushBack(ads.positions[i]);
            return new_arr;
        }

        public static DataStore operator &(ArrayDataStore ads, ArrayDataStore ads2)
        {
            ArrayDataStore new_arr = new ArrayDataStore();
            int pos = 0;
            int pos2 = 0;
            while (pos < ads.positions.Size() && pos2 < ads2.positions.Size())
            {
                if (ads.positions[pos] == ads2.positions[pos2])
                    new_arr.PushBack(ads.positions[pos]);
                if (ads.positions[pos] < ads2.positions[pos2])
                    pos++;
                else
                    pos2++;
            }
            return new_arr;
        }

        public override bool Get(int numb)
        {
            if (positions.Size() == 0)
                return false;
            return positions[FindPos(numb)] == numb;
        }

        public override void Set(int numb, bool value)
        {
            int current_pos = FindPos(numb);
            if (value)
            {
                if (current_pos >= positions.Size() || positions[current_pos] != numb)
                    positions.Push(numb, current_pos + 1);
            }
            else
            {
                if (current_pos < positions.Size() && positions[current_pos] == numb)
                    positions.Pop(current_pos);
            }
        }

        public override int BitCount() => positions.Size();
    }
}
