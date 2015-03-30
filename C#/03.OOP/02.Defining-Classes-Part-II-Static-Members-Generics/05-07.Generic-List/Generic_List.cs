using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GenericList<T>
        
{
    private int listCount = 0;
    private T[] listMembers;
    

    public GenericList(int capacity)
    {
        this.listMembers = new T[capacity];
    }

    private void ListResize()
    {
        T[] tempArray = new T[listMembers.Length * 2];
        Array.Copy(listMembers, 0, tempArray, 0, listMembers.Length);
        listMembers = tempArray;
    }

    public void Add(T element)
    {
        if (listCount == listMembers.Length)
        {
            ListResize();
        }
        listMembers[listCount] = element;
        listCount++;
    }

    public void AddAtIndex(int index, T element)
    {
        if (index >= listMembers.Length)
        {
            ListResize();
            listMembers[index] = element;
            listCount = index + 1;
        }
        else
        {
            listMembers[index] = element;
        }
    }

    public void InsertAtIndex(int index, T element)
    {
        if (index >= listMembers.Length)
        {
            ListResize();
            listMembers[index] = element;
            listCount = index + 1;
        }
        else
        {
            Array.Copy(listMembers, index, listMembers, index + 1, listMembers.Length - index - 1);
            listMembers[index] = element;
            listCount++;
        }
    }

    public void RemoveAtIndex(int index)
    {
        if (index>=listMembers.Length)
        {
            throw new IndexOutOfRangeException("Index is outside the List capacity.");
        }
        else
        {
            Array.Clear(listMembers, index, 1);
        }
    }

    public T AccessAtIndex(int index)
    {
        if (index >= listMembers.Length)
        {
            throw new IndexOutOfRangeException("Index is outside the List capacity.");
        }
        else
        {
            T element = listMembers[index];
            return element;
        }
    }

    public int FindByValue(T element)
    {
        int index;
        return index = Array.IndexOf(listMembers, element);
    }

    public void ClearAll()
    {
        this.listMembers = new T[listCount];
    }

    public T Max<T>() where T : IComparable<T>
    {
        dynamic max = this.listMembers[0];
        for (int i = 1; i < this.listMembers.Length; i++)
        {
            T listItem = (dynamic)this.listMembers[i];
            if (listItem.CompareTo(max) > 0)
            {
                max = this.listMembers[i];
            }
        }
        return max;
    }

    public T Min<T>() where T : IComparable<T>
    {
        dynamic min = this.listMembers[0];
        for (int i = 1; i < this.listMembers.Length; i++)
        {
            T listItem = (dynamic)this.listMembers[i];
            if (listItem.CompareTo(min) < 0)
            {
                min = this.listMembers[i];
            }
        }
        return min;
    }

    public override string ToString()
    {
        string str = string.Join<T>(", ", listMembers);

 	    return str.ToString();
    }
}