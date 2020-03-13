namespace Patterns
{
    public class Decorator<T>
    {
        public Decorator(T target)
        {
            this.target = target;
        }

        private T target;

        private (ulong Get, ulong Set) access = (0, 0);

        public T Target
        {
            get
            {
                access.Get = checked(access.Get + 1);
                return target;
            }

            private set
            {
                access.Set = checked(access.Set + 1);
                target = value;
            }
        }

        public (ulong Get, ulong Set) Access => access;
    }
}
