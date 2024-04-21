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
            foreach (char key in Constants.GLOBAL_MENU_CHOICES.Keys)
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
        bool isGameOn = false;
        do
        {
            ClearUI();
            QuestionPreview(question, isGameOn);
            AddGenericAnswer(isCorrectAnswer, question);
            if (question.AnswersList.Count == Constants.MAX_ANSWER_COUNT)
            {
                break;
            }
            addAnswerChoice = KeepEncodingAnswer(isCorrectAnswer, question);
            if (addAnswerChoice == Constants.ADD_FALSE_ANSWER_CHOICE)
            {
                isCorrectAnswer = false;
            }
            if (addAnswerChoice == Constants.ADD_CORRECT_ANSWER_CHOICE)
            {
                isCorrectAnswer = true;
            }
        } while (addAnswerChoice!= Constants.STOP_ADDING_ANSWER_CHOICE );

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

    public static void QuestionPreview(QuestionAndAnswers question,bool isGameOn =true)
    {
        DisplayUI($"Question : \n{question.Question}");
        DisplayUI($"Answers :");
        for (int i = 0; i < question.AnswersList.Count; i++)
        {
            DisplayUI($"{( isGameOn ? $"{i.ToString()} - " : "" )}{question.AnswersList[i]} {(question.CorrectAnswersIndex.Contains(i) && !isGameOn ? "(correct)" : "")} ");
        }
    }

    public static int AskQuestionGetAnswer(QuestionAndAnswers question)
    {
       
        do
        {
            QuestionPreview(question);
            DisplayUI("What's your answer ?");
            bool isParseSuccess = Int32.TryParse(UIMethods.GetChar().ToString(), out int answer);
            if (!isParseSuccess || answer < 0 || answer >= question.AnswersList.Count)
            {
                ClearUI();
                DisplayUI("Your selection is not correct.\n");
                continue;
            }
            return answer;
        } while (true);
        
    }
}