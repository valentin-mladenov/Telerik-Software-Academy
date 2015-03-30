namespace _13.LinkedQueue
{
     public class QueueItem<T>
    {
        public QueueItem(T data)
        {
            this.Data = data;
        }

        public T Data { get; private set; }

        public QueueItem<T> Next { get; set; }
    }
}