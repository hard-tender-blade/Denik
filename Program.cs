class Program {    
    static void Main(string[] args) {
        Diary diary = new Diary();

        while(true) {
            Console.Clear();
            PrintMenu();
            diary.DisplayCurrentRecord();
            
            int choice = ReadChoice();

            switch(choice) {
                case 1:
                    CreateNewRecord(diary);
                    break;
                case 2:
                    if(!DeletionConfirmation()) { break; }
                    diary.DeleteRecord();
                    diary.GoToFirstRecord();
                    break;
                case 3:
                    diary.GoToPreviousRecord();
                    break;
                case 4:
                    diary.GoToNextRecord();
                    break;
                case 5:
                    return;
                default:
                    break;
            }
        }
    }

    static void PrintMenu() {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1. Add record");
        Console.WriteLine("2. Delete record");
        Console.WriteLine("3. Go to previous record");
        Console.WriteLine("4. Go to next record");
        Console.WriteLine("5. Exit");
        Console.WriteLine("---------------------------------");
    }
    static int ReadChoice() {
        Console.Write("Enter your choice: ");
        int choice;
        if (!int.TryParse(Console.ReadLine()!, out choice)) { return -1; }
        return choice;
    }
    static void CreateNewRecord(Diary diary) {
        while(true) {
            Console.Write("Enter date: ");
            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine()!, out date)) { continue; }
            Console.WriteLine("Enter text: ");
            string text = ReadMultipleLineText();
            diary.AddRecord(new Record(date, text));
            return;
        }
    }
    static string ReadMultipleLineText()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        while (true)
        {
            string line = Console.ReadLine()!;
            if (line == "save") { break; }
            sb.AppendLine(line);
        }
        return sb.ToString();
    }
    static bool DeletionConfirmation() {
        Console.Write("Are you sure you want to delete this record? (y/n): ");
        string answer = Console.ReadLine()!;
        return answer == "y";
    }
}