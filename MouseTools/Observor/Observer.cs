namespace MouseTools.Observor
{
    public abstract class Observer
    {
        protected Subject subject;

        public abstract void Write(string message);

    }
}