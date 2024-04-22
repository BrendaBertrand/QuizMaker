namespace QuizMaker;

public class Constants
{
    public const char ADD_QUESTION_CHOICE = '1';
    public const char PLAY_GAME_CHOICE = '2';
    public const char QUIT_GAME_CHOICE = '3';

    public const char NEW_FILE_CHOICE = '1';
    public const char EXISTING_FILE_CHOICE = '2';
    
    public const string ADD_QUESTION_TEXT = "Add a question to the database";
    public const string PLAY_GAME_TEXT = "Play the game";
    public const string QUIT_GAME_TEXT = "Quit the game";
    public const string SEPARATOR = ",";
    
    public const string NEW_FILE_TEXT = "Start from scratch";
    public const string EXISTING_FILE_TEXT = "Use the existing file";
    

    public const int MIN_ANSWER_COUNT = 3;
    public const int MAX_ANSWER_COUNT = 4;
    public const int NUMBER_OF_QUESTIONS_BY_GAME = 3;

    public const string PATH_XML = @"../../../QuestionsList.xml";
    
    public static Dictionary<char, string> GLOBAL_MENU_CHOICES = new Dictionary<char, string>()
    {
        { ADD_QUESTION_CHOICE, ADD_QUESTION_TEXT },
        { PLAY_GAME_CHOICE, PLAY_GAME_TEXT },
        { QUIT_GAME_CHOICE, QUIT_GAME_TEXT },
    };
    
    public static Dictionary<char, string> FILE_MENU_CHOICES = new Dictionary<char, string>()
    {
        { NEW_FILE_CHOICE, NEW_FILE_TEXT },
        { EXISTING_FILE_CHOICE, EXISTING_FILE_TEXT },
    };
}