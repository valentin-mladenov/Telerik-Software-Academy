namespace _11.Implement_Linked_List
{
    using System;

    public class MyLinkedList<T> 
    {
        public ListItem<T> Head { get; set; }

        public MyLinkedList(ListItem<T> head = null)
        {
            this.Head = head;

            if (head == null)
            {
                this.Count = 0;
            }
            else
            {
                this.Count = 1;
            }
           
        } 

        public void AddAt(T data, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Incorrect index position!");
            }

            ListItem<T> current = this.Head;

            while (index > 0)
            {
                current = current.NextItem;
                index--;
            }

            ListItem<T> addItem = new ListItem<T>(data);
            addItem.NextItem = current.NextItem;
            current.NextItem = addItem;
            this.Count++;
        }

        public void AddNext(T item)
        {
           ListItem<T> newItem = new ListItem<T>(item);

            if (this.Head == null)
            {
                this.Head = newItem;
            }
            else
            {
                ListItem<T> current = this.Head;
                while (current.NextItem != null)
                {
                    current = current.NextItem;
                }
                current.NextItem = newItem;
            }
        }

        public void Clear()
        {
            this.Head = null;
        }

        public void AddNewHead(T item)
        {
            ListItem<T> newHead = new ListItem<T>(item);
            if (this.Head == null)
            {
                this.Head = newHead;
            }
            else
            {
                newHead.NextItem = this.Head;
                this.Head = newHead;
            }

            this.Count++;
        }

        public int Count { get; private set; }

        public bool RemoveLast()
        {
            if (this.Head == null)
            {
                return false;
            }
            else
            {
                if (this.Head.NextItem == null)
                {
                    this.Head = null;
                }
                else
                {

                    ListItem<T> current = this.Head;
                    ListItem<T> last = current.NextItem;
                    while (last.NextItem != null)
                    {
                        current = current.NextItem;
                        last = last.NextItem;
                    }
                    last = null;
                    current.NextItem = null;
                }
                this.Count--;
                return true;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Incorrect index position!");
            }

            if (this.Head == null)
            {
                return false;
            }

            ListItem<T> current = this.Head;
            while (index > 1)
            {
                current = current.NextItem;
                index--;
            }

            ListItem<T> toRemove = current.NextItem;
            current.NextItem = toRemove.NextItem;
            this.Count--;
            return true;
        }

        public bool RemoveHead()
        {
            if (this.Head == null)
            {
                return false;
            }
            else
            {
                if (this.Head.NextItem == null)
                {
                    this.Head = null;
                }
                else
                {
                    this.Head = this.Head.NextItem;
                }
                this.Count--;
                return true;
            }
        }
    }
}