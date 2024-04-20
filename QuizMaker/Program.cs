namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayUI("Welcome to our Quiz Maker!\n" );
        char userMenuChoice = UIMethods.Menu();
        List<QuestionAndAnswers> questionsList = new List<QuestionAndAnswers>();
        
        questionsList = DataMethods.Deserialization();
        
        switch (userMenuChoice)
        {
            case Constants.ADD_QUESTION_CHOICE :
                questionsList.Add(UIMethods.AddQuestion());
                DataMethods.Serialization(questionsList);
                break;
        }
        
        
    }
}