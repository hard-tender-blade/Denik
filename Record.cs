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