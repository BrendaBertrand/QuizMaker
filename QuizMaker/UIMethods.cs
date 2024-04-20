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

    public static string GetString()
    {
        return Console.ReadLine();
    }


    public static char Menu()
    {
        char userMenuChoice;
        do
        {
            DisplayUI("What do you want to do ?");
            foreach (var key in Constants.GLOBAL_MENU_CHOICES.Keys)
            {
                DisplayUI($"{key} - {Constants.GLOBAL_MENU_CHOICES[key]}");
            }

            userMenuChoice = GetChar();
            ClearUI();
            if (!Constants.GLOBAL_MENU_CHOICES.ContainsKey(userMenuChoice))
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
    
    
    public static QuestionAndAnswers AddQuestion()
    {
        QuestionAndAnswers question = new QuestionAndAnswers();
        DisplayUI("Please enter your question :");
        question.Question = GetString();
        bool isCorrectAnswer = true;
        char addAnswerChoice;
        do
        {
            AddGenericAnswer(isCorrectAnswer, question);
            addAnswerChoice = KeepEncodingAnswer(isCorrectAnswer, question);
            if (addAnswerChoice == Constants.ADD_FALSE_ANSWER_CHOICE)
            {
                isCorrectAnswer = false;
            }
            if (addAnswerChoice == Constants.ADD_CORRECT_ANSWER_CHOICE)
            {
                isCorrectAnswer = true;
            }
        } while (addAnswerChoice!= Constants.STOP_ADDING_ANSWER_CHOICE);

        return question;
    }

    public static QuestionAndAnswers AddGenericAnswer(bool isCorrect, QuestionAndAnswers question)
    {
        DisplayUI($"\nPlease enter {(isCorrect ? "a correct" : "an")} answer :");
        string answer = GetString();
        if (isCorrect)
        {
            question.AddCorrectAnswer(answer);
        }
        else
        {
            question.AddAnswer(answer);
        }

        return question;
    }

    public static char KeepEncodingAnswer(bool isCorrect, QuestionAndAnswers question)
    {
        char answerMenuChoice;
        do
        {
            DisplayUI($"\nDo you want to add another {(isCorrect ? "correct" : "")} answer ?");
            foreach (var key in Constants.MENU_ADD_ANSWER_CHOICES.Keys)
            {
                if (key == Constants.STOP_ADDING_ANSWER_CHOICE &&
                    question.AnswersList.Count < Constants.MIN_ANSWER_COUNT)
                {
                    continue;
                }

                DisplayUI($"{key} - {Constants.MENU_ADD_ANSWER_CHOICES[key]}");
            }

            answerMenuChoice = GetChar();
            if (!Constants.MENU_ADD_ANSWER_CHOICES.ContainsKey(answerMenuChoice))
            {
                ClearUI();
                DisplayUI($"{answerMenuChoice} is not a correct selection.\n");
            }
            else
            {
                break;
            }
        } while (true);

        return answerMenuChoice;
    }
}