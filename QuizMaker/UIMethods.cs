namespace QuizMaker;

public class UIMethods
{
    public static void ClearUI()
    {
        Console.Clear();
    }

    public static void DisplayUI(string text)
    {
        Console.WriteLine(text);
    }

    public static char GetChar()
    {
        return Console.ReadKey().KeyChar;
    }


    public static char Menu()
    {
        char userMenuChoice;
        do
        {
            DisplayUI("What do you want to do ?");
            foreach (var key in Constants.MENU_CHOICES.Keys)
            {
                DisplayUI($"{key} - {Constants.MENU_CHOICES[key]}");
            }

            userMenuChoice = GetChar();
            ClearUI();
            if (!Constants.MENU_CHOICES.ContainsKey(userMenuChoice))
            {
                DisplayUI($"{userMenuChoice} is not a correct selection.\n");
            }
            else
            {
                break;
            }
        } while (true);

        return userMenuChoice;
    }
}