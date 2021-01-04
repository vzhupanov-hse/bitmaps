namespace ZhupanovVyacheslav__195__3
{
    public class MutableArray<T>
    {
        T[] arr;
        int current;

        public int Size() => current;

        public MutableArray(int size = 0)
        {
            arr = new T[size];
            current = 0;
        }

        public void Push(T item, int pos)
        {
            if (pos >= current - 1 || pos == -1)
            {
                Resize();
                arr[current++] = item;
            }
            else
            {
                Resize();
                T[] new_arr = new T[arr.GetLength(0)];
                for (int i = 0; i < pos; i++)
                    new_arr[i] = arr[i];
                new_arr[pos] = item;
                for (int i = pos; i < arr.GetLength(0) - 1; i++)
                    new_arr[i + 1] = arr[i];
                arr = new_arr;
                current++;
            }
        }

        public T Pop(int pos)
        {
            if (pos < 0)
                pos = 0;
            T res = arr[pos];
            Resize();
            T[] new_arr = new T[arr.GetLength(0)];
            for (int i = 0; i < pos; i++)
                new_arr[i] = arr[i];
            for (int i = pos + 1; i < arr.GetLength(0); i++)
                new_arr[i - 1] = arr[i];
            current--;
            arr = new_arr;
            return res;
        }

        private void Resize()
        {
            T[] new_arr = null;
            if (current == arr.GetLength(0))
            {
                if (current == 0)
                    new_arr = new T[1];
                else
                {
                    new_arr = new T[2 * arr.GetLength(0)];
                    for (int i = 0; i < arr.GetLength(0); i++)
                        new_arr[i] = arr[i];
                }
                arr = new_arr;
            }
            else if (arr.GetLength(0) > 1 && current < arr.GetLength(0) / 2)
            {
                new_arr = new T[arr.GetLength(0) / 2];
                for (int i = 0; i < new_arr.GetLength(0); i++)
                    new_arr[i] = arr[i];
                arr = new_arr;
            }
        }

        public T this[int pos]
        {
            get => arr[pos];
            set
            {
                arr[pos] = value;
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < current; i++)
                res += arr[i] + " ";
            return res;
        }
    }
}
