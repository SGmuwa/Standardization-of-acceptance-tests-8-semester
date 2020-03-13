namespace Patterns
{
    public class Decorator<T>
    {
        public Decorator(T v)
        {
            this.v = v;
        }

        private T v;

        private (ulong Get, ulong Set) access = (0, 0);

        public T V
        {
            get
            {
                access.Get = checked(access.Get + 1);
                return v;
            }

            set
            {
                access.Set = checked(access.Set + 1);
                v = value;
            }
        }

        public (ulong Get, ulong Set) Access => access;
    }
}
