using System.Xml.Serialization;

namespace QuizMaker;

public class DataMethods
{
    static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));

    public static void SaveToFile(List<QuestionAndAnswers> questionsList)
    {
        using (FileStream file = File.Create(Constants.PATH_XML))
        {
            serializer.Serialize(file, questionsList);
        }
    }

    public static List<QuestionAndAnswers> ReadFromFile()
    {
        List<QuestionAndAnswers> questionsList = new List<QuestionAndAnswers>();
        using (FileStream file = File.OpenRead(Constants.PATH_XML))
        {
            questionsList = serializer.Deserialize(file) as List<QuestionAndAnswers>;
        }

        return questionsList;
    }

    public static bool CheckFileExistence()
    {
        if (File.Exists(Constants.PATH_XML))
        {
            return true;
        }

        return false;
    }
}