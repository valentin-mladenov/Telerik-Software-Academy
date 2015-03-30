namespace _11.Implement_Linked_List
{
    public class ListItem<T>
    {
        public T Data { get; set; }

        public ListItem<T> NextItem { get; set; }

        public ListItem(T data)
        {
            this.Data = data;
        } 
    }
}
