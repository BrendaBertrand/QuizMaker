namespace QuizMaker;

public class LogicMethods
{
    public static List<int> QuestionSelection(List<QuestionAndAnswers> questionsList, List<int> questionsAsked,
        out QuestionAndAnswers question)
    {
        Random rng = new Random();
        do
        {
            int questionIndex = rng.Next(questionsList.Count);
            if (!questionsAsked.Contains(questionIndex))
            {
                questionsAsked.Add(questionIndex);
                question = questionsList[questionIndex];
                return questionsAsked;
            }
        } while (true);
    }

    public static int CheckAnswer(QuestionAndAnswers question,int score, int answer, int numberQuestionsAsked)
    {
        UIMethods.ClearUI();
        if (question.CorrectAnswersIndex.Contains(answer))
        {
            score++;
            UIMethods.DisplayUI("Your answer is correct!");
        }
        else
        {
            UIMethods.DisplayUI("Wrong answer");
        }

        UIMethods.DisplayUI($"Your score is {score}/{numberQuestionsAsked}.\n");
        return score;
    }
}