
public class Record {
    public DateTime Date { get; set; }
    public string Text { get; set; }
    public Record(DateTime date, string text) {
        Date = date;
        Text = text;
    }
    public void Display() {
        Console.WriteLine($"Date: {Date.ToShortDateString()}\n");
        Console.WriteLine($"Text: {Text}\n\n");
    }
}

public class Node
{
    public Record Data { get; set; }
    public Node? Next { get; set; }
    public Node? Previous { get; set; }
    public Node(Record data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class Diary
{
    private Node? current;
    private Node? first;
    private Node? last;

    public void AddRecord(Record data)
    {
        Node newNode = new Node(data);

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
        Node? current = first;

        while (current != null)
        {
            Console.Write(current?.Data?.ToString() + " ");
            current = current?.Next;
        }
        Console.WriteLine();
    }
}