// Implement the data structure linked list. Define a class
// ListItem<T> that has two fields: value (of type T) and
// NextItem (of type ListItem<T>). Define additionally a class 
// LinkedList<T> with a single field FirstElement (of type ListItem<T>).

namespace _11.Implement_Linked_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ImplementLinkedList
    {
        static void Main()
        {
            MyLinkedList<int> testLList = new MyLinkedList<int>(new ListItem<int>(3));
            testLList.AddNext(3);
            testLList.AddNewHead(2);
            testLList.AddAt(10, 1);
            testLList.RemoveAt(1);
            testLList.RemoveHead();
            testLList.RemoveLast();
        }
    }
}
