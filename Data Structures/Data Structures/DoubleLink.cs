namespace DataStructures
{
    public class DoubleLink<T>
    {
        public T Value { get; set; }

        public DoubleLink<T> PreviousLink { get; set; }

        public DoubleLink<T> NextLink { get; set; }

        public DoubleLinkedListCollection<T> MyList;

        public DoubleLink(T value)
        {
            this.Value = value;
        }
    }
}
