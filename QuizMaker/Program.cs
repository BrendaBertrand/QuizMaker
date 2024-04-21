﻿namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayUI("Welcome to our Quiz Maker!\n");
        List<QuestionAndAnswers> questionsList = DataMethods.Deserialization();
        do
        {
            char userMenuChoice = UIMethods.Menu();
            if (userMenuChoice == Constants.QUIT_GAME_CHOICE)
            {
                break;
            }

            switch (userMenuChoice)
            {
                case Constants.ADD_QUESTION_CHOICE:
                    questionsList.Add(UIMethods.AddQuestion());
                    DataMethods.Serialization(questionsList);
                    UIMethods.ClearUI();
                    UIMethods.DisplayUI("The question has been added to the database.");
                    break;
                case Constants.PLAY_GAME_CHOICE:
                    int score = 0;
                    List<int> questionsAsked = new List<int>();
                    UIMethods.ClearUI();
                    do
                    {
                        questionsAsked = LogicMethods.QuestionSelection(questionsList, questionsAsked,
                            out QuestionAndAnswers question);

                        int answer = UIMethods.AskQuestionGetAnswer(question);

                        score = LogicMethods.CheckAnswer(question, score, answer, questionsAsked.Count);
                    } while (questionsAsked.Count < Constants.NUMBER_OF_QUESTIONS_BY_GAME);

                    UIMethods.DisplayUI("This is the end of the game.\n");
                    break;
            }
        } while (true);
    }
}