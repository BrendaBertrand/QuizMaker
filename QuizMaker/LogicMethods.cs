namespace QuizMaker;

public class LogicMethods

{
    static readonly Random rng = new Random();

    public static List<int> PickQuestion(List<QuestionAndAnswers> questionsList, List<int> questionsAsked,
        out QuestionAndAnswers question)
    {
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

    public static QuestionAndAnswers CheckCorrectAnswerIndex(string rawIndexes, QuestionAndAnswers question,
        out bool isAnswerIndexCorrect)
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


    public static bool CheckAnswersQuantity(string rawAnwsers, out List<string> answersList)
    {
        answersList = rawAnwsers.Split(Constants.SEPARATOR, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
        if (answersList.Count < Constants.MIN_ANSWER_COUNT || answersList.Count > Constants.MAX_ANSWER_COUNT)
        {
            return false;
        }

        return true;
    }
}