
public class Node<Record>
{
    public Record Data { get; set; }
    public Node<Record>? Next { get; set; }
    public Node<Record>? Previous { get; set; }
    public Node(Record data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class Diary
{
    private Node<Record>? current;
    private Node<Record>? first;
    private Node<Record>? last;

    public void AddRecord(Record data)
    {
        Node<Record> newNode = new Node<Record>(data);

        if (first == null)
        {
            current = newNode;
            first = newNode;
            last = newNode;
        }
        else
        {
            last!.Next = newNode;
            newNode.Previous = last;
            last = newNode;
            current = newNode;
        }
    }

    public void DeleteRecord()
    {
        if (current == null)
        {
            Console.WriteLine("The diary is empty");
            return;
        }

        if (current == first && current == last)
        {
            current = null;
            first = null;
            last = null;
            return;
        }

        if (current == first)
        {
            current = current.Next;
            current!.Previous = null;
            first = current;
            return;
        }

        if (current == last)
        {
            current = current.Previous;
            current!.Next = null;
            last = current;
            return;
        }

        current.Previous!.Next = current.Next;
        current.Next!.Previous = current.Previous;
        current = current.Next;
    }

    public void GoToNextRecord()
    {
        if (current == null)
        {
            Console.WriteLine("The diary is empty");
            return;
        }

        if (current == last)
        {
            Console.WriteLine("This is the last record");
            return;
        }

        current = current.Next;
    }

    public void GoToPreviousRecord()
    {
        if (current == null)
        {
            Console.WriteLine("The diary is empty");
            return;
        }

        if (current == first)
        {
            Console.WriteLine("This is the first record");
            return;
        }

        current = current.Previous;
    }

    public void GoToFirstRecord()
    {
        if (current == null)
        {
            Console.WriteLine("The diary is empty");
            return;
        }

        current = first;
    }
    public void DisplayCurrentRecord()
    {
        if (current == null)
        {
            Console.WriteLine("The diary is empty\n\n\n\n");
            return;
        }

        current.Data.Display();
    }

    public void DisplayDiary()
    {
        Node<Record>? current = first;

        while (current != null)
        {
            Console.Write(current?.Data?.ToString() + " ");
            current = current?.Next;
        }
        Console.WriteLine();
    }
}