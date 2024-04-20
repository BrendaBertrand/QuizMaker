using System.Xml.Serialization;

namespace QuizMaker;

public class DataMethods
{
    public static void Serialization(List<QuestionAndAnswers> questionsList)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));
        using (FileStream file = File.Create(Constants.PATH_XML) )
        {
            serializer.Serialize(file, questionsList);
        }
    }
    public static List<QuestionAndAnswers> Deserialization()
    {
        
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));
        List<QuestionAndAnswers> questionsList = new List<QuestionAndAnswers>();
        try
        {
            using (FileStream file = File.OpenRead(Constants.PATH_XML))
            {
                questionsList = serializer.Deserialize(file) as List<QuestionAndAnswers>;
            }

        }
        catch (Exception e)
        {
            
        }
        return questionsList;
    }
}