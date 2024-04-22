namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayUI("Welcome to our Quiz Maker!\n");
        List<QuestionAndAnswers> questionsList = new List<QuestionAndAnswers>();
        do
        {
            char userMenuChoice = UIMethods.DisplayMenu();
            if (userMenuChoice == Constants.QUIT_GAME_CHOICE)
            {
                break;
            }

            switch (userMenuChoice)
            {
                case Constants.ADD_QUESTION_CHOICE:
                    if (UIMethods.UseExistingQuestionFile())
                    {
                        questionsList = DataMethods.ReadFromFile();
                    }
                    else
                    {
                        questionsList = new List<QuestionAndAnswers>();
                    }
                    questionsList.Add(UIMethods.AddQuestion());
                    DataMethods.SaveToFile(questionsList);
                    UIMethods.ClearUI();
                    bool isGameOn = false;
                    UIMethods.DisplayQuestion(questionsList.Last(), isGameOn);
                    UIMethods.DisplayUI("The question has been added to the database.\n");
                    break;
                case Constants.PLAY_GAME_CHOICE:
                    questionsList = DataMethods.ReadFromFile();
                    int score = 0;
                    List<int> questionsAsked = new List<int>();
                    UIMethods.ClearUI();
                    do
                    {
                        questionsAsked = LogicMethods.PickQuestion(questionsList, questionsAsked,
                            out QuestionAndAnswers question);

                        int answer = UIMethods.AskQuestionGetAnswer(question);

                        score = UIMethods.DisplayCorrection(question, score, answer, questionsAsked.Count);
                    } while (questionsAsked.Count < Math.Min(Constants.NUMBER_OF_QUESTIONS_BY_GAME, questionsList.Count));

                    UIMethods.DisplayUI("This is the end of the game.\n");
                    break;
            }
        } while (true);
    }
}