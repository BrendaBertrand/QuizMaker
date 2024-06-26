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
            if (!Constants.GLOBAL_MENU_CHOICES.ContainsKey(userMenuChoice) ||
                (userMenuChoice == Constants.PLAY_GAME_CHOICE && !isFileAvailable))
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
            if (!isAnswerQuantityOk)
            {
                DisplayUI("The amount of answers is not correct\n");
            }
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
            question = LogicMethods.CheckCorrectAnswerIndex(rawCorrectAnswerIndex, question, out isAnswerIndexCorrect);
            if (!isAnswerIndexCorrect)
            {
                ClearUI();
                DisplayUI("Index(es) are not correct. Please try again\n");
            }
        } while (!isAnswerIndexCorrect);

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

    public static int DisplayCorrection(QuestionAndAnswers question, int score, int answer, int numberQuestionsAsked)
    {
        ClearUI();
        if (question.CorrectAnswersIndex.Contains(answer))
        {
            score++;
            DisplayUI("Your answer is correct!");
        }
        else
        {
            DisplayUI("Wrong answer");
        }

        DisplayUI($"Your score is {score}/{numberQuestionsAsked}.\n");
        return score;
    }

    public static bool UseExistingQuestionFile()
    {
        bool isFileAvailable = DataMethods.CheckFileExistence();
        if (isFileAvailable)
        {
            char userFileChoice;
            do
            {
                DisplayUI("Do you want to use the existing file or start from scratch ?");
                foreach (var key in Constants.FILE_MENU_CHOICES.Keys)
                {
                    DisplayUI($"{key} - {Constants.FILE_MENU_CHOICES[key]}");
                }

                userFileChoice = GetChar();
                ClearUI();
                if (!Constants.FILE_MENU_CHOICES.ContainsKey(userFileChoice))
                {
                    DisplayUI($"{userFileChoice} is not a correct selection.\n");
                }
                else
                {
                    break;
                }
            } while (true);

            if (userFileChoice == Constants.EXISTING_FILE_CHOICE)
            {
                return true;
            }

            return false;
        }

        return false;
    }
}