namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using System.Collections;


public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    //public ListNode<T> Previous = null;

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }


    public int Count()
    {
        //TODO #1: return the number of elements on the list
        return m_numItems;
    }


    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
          if(index>= m_numItems)
        {
            return default(T);
        }
        else
        {
            int con = 0;
            ListNode<T> node = First;
            while (con < index)
            {
                node = node.Next;
                con++;
            }
            return node.Value;  
        }
    }


    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list

    ListNode<T> nuevo = new ListNode<T>(value);

        if (First == null)
        {

            First = nuevo;
            Last = First;
            m_numItems++;

        }
        else if (Last == null)
        {
            Last = nuevo;
            m_numItems++;
        }
        else
        {
            Last.Next = nuevo;
            Last = nuevo;
            m_numItems++;
        }
    }


    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        ListNode<T> Aborrar = null;
        
        if (index < 0||index == m_numItems)
        {
            return default(T);
        }
        if (index == 0)
        {
            Aborrar = First;
            First = First.Next;
        }
        else if (index == m_numItems -1)
        {
            Aborrar = Last;
            //Last = Last.Previous;
        }
        if (index < m_numItems / 2)
        {
            for (int i = 0; i < index; i++)
            {
                Aborrar = First;
                First = First.Next;
            }
        }
        else if (index > m_numItems / 2)
        {
            for (int i = 0; i < index; i++)
            {
                Aborrar = Last;
                //Last = Last.Previous;
            }
        }
        m_numItems--;
        return Aborrar.Value;
    }


    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        m_numItems = 0;
        First = null;
        Last = null;
    }


    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list


       ListNode<T> node = First;
        while(node != null)
        {
            yield return node.Value;
            node = node.Next;
        }


    }
}
