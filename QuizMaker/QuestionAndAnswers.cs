namespace QuizMaker;

public class QuestionAndAnswers
{
    public string Question;
    public List<string> AnswersList = new List<string>();
    public List<int> CorrectAnswersIndex = new List<int>();

    public void AddCorrectAnswer(string correctAnswer)
    {
        CorrectAnswersIndex.Add(AnswersList.Count);
        AnswersList.Add(correctAnswer);
    }  
    public void AddAnswer(string answer)
    {
        AnswersList.Add(answer);
    }
}