namespace QuizMaker;

public class Constants
{
    public const char ADD_QUESTION_CHOICE = '1';
    public const char PLAY_GAME_CHOICE = '2';
    public const char ADD_CORRECT_ANSWER_CHOICE = '1';
    public const char ADD_FALSE_ANSWER_CHOICE = '2';
    public const char STOP_ADDING_ANSWER_CHOICE = '3';
    public const char QUIT_GAME_CHOICE = '3';
    
    public const string ADD_QUESTION_TEXT = "Add a question to the database";
    public const string PLAY_GAME_TEXT = "Play the game";
    public const string ADD_CORRECT_ANSWER_TEXT = "Add a correct answer";
    public const string ADD_FALSE_ANSWER_TEXT = "Add a false answer";
    public const string STOP_ADDING_ANSWER_TEXT = "Stop adding answer";
    public const string QUIT_GAME_TEXT = "Quit the game";
    public const string SEPARATOR = ",";

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

    public static Dictionary<char, string> MENU_ADD_ANSWER_CHOICES = new Dictionary<char, string>()
    {
        { ADD_CORRECT_ANSWER_CHOICE, ADD_CORRECT_ANSWER_TEXT },
        { ADD_FALSE_ANSWER_CHOICE, ADD_FALSE_ANSWER_TEXT },
        { STOP_ADDING_ANSWER_CHOICE, STOP_ADDING_ANSWER_TEXT}
    };

}