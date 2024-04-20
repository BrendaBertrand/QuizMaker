namespace QuizMaker;

public class Constants
{
    public static char ADD_QUESTION_CHOICE = '1';
    public static char PLAY_GAME_CHOICE = '2';
    
    public static string ADD_QUESTION_TEXT = "Add a question to the database";
    public static string PLAY_GAME_TEXT = "Play the game";
    
    
    public static Dictionary<char, string> MENU_CHOICES = new Dictionary<char, string>()
    {
        { ADD_QUESTION_CHOICE, ADD_QUESTION_TEXT },
        { PLAY_GAME_CHOICE, PLAY_GAME_TEXT },
    };

}