using System.Linq;

namespace ZhupanovVyacheslav__195__3
{
    public abstract class DimLine
    {
        public string this[string key]
        {
            get
            {
                var prop = GetType().GetProperties();
                var p = prop.FirstOrDefault(x => x.Name == key);
                return p.GetValue(this, null).ToString();
            }
        }

        public abstract string GetName { get; }
        public abstract int GetKey { get; }
    }
}
