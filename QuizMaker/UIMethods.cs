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


    public static char DisplayMenu()
    {
        char userMenuChoice;
        do
        {
            DisplayUI("What do you want to do ?");
            bool isFileAvailable = DataMethods.CheckFileExistence();
            foreach (char key in Constants.GLOBAL_MENU_CHOICES.Keys)
            {
                if (key == Constants.PLAY_GAME_CHOICE && !isFileAvailable)
                {
                    continue;
                }
                DisplayUI($"{key} - {Constants.GLOBAL_MENU_CHOICES[key]}");
            }

            userMenuChoice = GetChar();
            ClearUI();
            if (!Constants.GLOBAL_MENU_CHOICES.ContainsKey(userMenuChoice) || (userMenuChoice == Constants.PLAY_GAME_CHOICE && !isFileAvailable))
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
        bool isAnswerQuantityOk;
        List<string> answersList;
        do
        {
            DisplayUI($"Please type the answers separated by \"{Constants.SEPARATOR}\".");
            DisplayUI(
                $"There should be minimum {Constants.MIN_ANSWER_COUNT} answers and maximum {Constants.MAX_ANSWER_COUNT}.");
            string rawAnswers = GetString();
            isAnswerQuantityOk = LogicMethods.CheckAnswersQuantity(rawAnswers, out answersList);
        } while (!isAnswerQuantityOk);

        question.AnswersList = answersList;
        question = ChooseCorrectAnswer(question);

        return question;
    }

    public static QuestionAndAnswers ChooseCorrectAnswer(QuestionAndAnswers question)
    {
        bool isAnswerIndexCorrect;
        ClearUI();
        do
        {
            DisplayQuestion(question);
            DisplayUI($"\nType the correct answer(s) index(es) separated by a {Constants.SEPARATOR}.");
            string rawCorrectAnswerIndex = GetString();
            question = CheckCorrectAnswerIndex(rawCorrectAnswerIndex, question, out isAnswerIndexCorrect);
            if (!isAnswerIndexCorrect)
            {
                ClearUI();
                DisplayUI("Index(es) are not correct. Please try again\n");
            }
        } while (!isAnswerIndexCorrect);

        return question;
    }

    public static QuestionAndAnswers CheckCorrectAnswerIndex( string rawIndexes, QuestionAndAnswers question, out bool isAnswerIndexCorrect )
    {
        string[] indexArray = rawIndexes.Split(Constants.SEPARATOR,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        List<int> indexList = new List<int>();
        foreach (var stringIndex in indexArray)
        {
            if (!Int32.TryParse(stringIndex, out int localIndex))
            {
                continue;
            }
            if (localIndex >= 0 && localIndex < question.AnswersList.Count())
            {
                indexList.Add(localIndex);
            }
        }
       
        isAnswerIndexCorrect = false;
        if (indexList.Count != 0)
        {
            question.CorrectAnswersIndex = indexList;
            isAnswerIndexCorrect = true;
        }
        return question;
    }
    

    
    public static void DisplayQuestion(QuestionAndAnswers question,bool isGameOn =true)
    {
        DisplayUI($"Question : \n{question.Question}");
        DisplayUI($"Answers :");
        for (int i = 0; i < question.AnswersList.Count; i++)
        {
            DisplayUI(
                $"{i.ToString()} - {question.AnswersList[i]} {(question.CorrectAnswersIndex.Contains(i) && !isGameOn ? "(correct)" : "")}");
        }
    }

    public static int AskQuestionGetAnswer(QuestionAndAnswers question)
    {
        do
        {
            DisplayQuestion(question);
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