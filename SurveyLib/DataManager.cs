using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace SurveyLib
{
    public class DataManager
    {
        string sqlConnection = "Server = 40.85.84.155; Database=OOP_BLÅ;User=Student27;Password=big-bada-boom!";

        private int SaveQuestion(int primaryKey, int type, string title)
        {
            using (SqlConnection connection = new(sqlConnection))
            {
                connection.Execute("INSERT INTO Question(Survey_ID, Type, QuestionText) VALUES (@Survey_ID, @Type, @QuestionText);", new { Survey_ID = primaryKey, Type = type, QuestionText = title });
                List<int> qList = connection.Query<int>("SELECT IDENT_CURRENT('Question');").ToList();
                return qList[0];
            }
        }

        public void SaveSurvey(Survey survey)
        {
            List<Question> questionList = survey.GetQuestions();
            int primaryKey;
            int questionPrimaryKey;
            //int multiChoiceID;

            using (SqlConnection connection = new(sqlConnection))
            {
                connection.Execute("INSERT INTO Survey (Title) VALUES (@Title);", new { Title = survey.Title });
                primaryKey = connection.QueryFirstOrDefault<int>("SELECT IDENT_CURRENT('Survey');");
            }


            foreach (Question question in questionList)
            {
                if (question is MultipleChoiseQuestion)
                {
                    MultipleChoiseQuestion q = question as MultipleChoiseQuestion;
                    int type = 1;

                    questionPrimaryKey = SaveQuestion(primaryKey, type, q.Title);

                    for (int i = 0; i < q.GetOptions().Count; i++)
                    {
                        string alternative = q.GetOptions()[i];
                        //bool answer = q.GetAnswer()[i];

                        using (SqlConnection connection = new(sqlConnection))
                        {
                            connection.Execute("INSERT INTO Multiple_Choice_Question(Question_ID, Alternative) VALUES (@Question_ID, @Alternative)", new { Question_ID = questionPrimaryKey, Alternative = alternative });
                        }
                    }

                }

                else if (question is FreetextQuestion)
                {
                    FreetextQuestion f = question as FreetextQuestion;
                    int type = 2;

                    questionPrimaryKey = SaveQuestion(primaryKey, type, f.Title);
                }

                else if (question is YesOrNoQuestion)
                {
                    YesOrNoQuestion y = question as YesOrNoQuestion;
                    int type = 3;

                    questionPrimaryKey = SaveQuestion(primaryKey, type, y.Title);
                }

                else if (question is _1_to_10)
                {
                    _1_to_10 scale = question as _1_to_10;
                    int type = 4;

                    questionPrimaryKey = SaveQuestion(primaryKey, type, scale.Title);

                    using (SqlConnection connection = new(sqlConnection))
                    {
                        connection.Execute("INSERT INTO Scale_Question(Question_ID, Value_1, VALUE_10) VALUES (@Question_ID, @Value_1, @Value_10);", new { Question_ID = questionPrimaryKey, Value_1 = scale.Value1, Value_10 = scale.Value10 });
                    }
                }
            }

        }

        public Survey UserLoadSurvey(int pKey) //string userCode ska vara här
        {
            int primaryKey = pKey;
            string title;
            List<int> questionKeys = new();
            string questionText;

            using (SqlConnection connection = new(sqlConnection))
            {
                //primaryKey = connection.QueryFirstOrDefault<int>("SELECT Survey_ID FROM User_Survey WHERE User_Specific_Code = @User_Specific_Code;", new { User_Specific_Code = UserCode });

                title = connection.QueryFirstOrDefault<string>("SELECT Title FROM Survey WHERE ID = @ID", new { ID = primaryKey });
            }

            Survey loadedSurvey = new(title);

            using (SqlConnection connection = new(sqlConnection))
            {
                questionKeys = connection.Query<int>("SELECT ID FROM Question WHERE Survey_ID = @Survey_ID;", new { Survey_ID = primaryKey }).ToList();
            }

            foreach (int key in questionKeys)
            {
                int questionType;

                using (SqlConnection connection = new(sqlConnection))
                {
                    questionType = connection.QueryFirstOrDefault<int>("SELECT Type FROM Question WHERE ID = @ID;", new { ID = key });
                    //questionType = qKeyList[0];
                    questionText = connection.QueryFirstOrDefault<string>("SELECT QuestionText FROM QUESTION WHERE ID = @ID;", new { ID = key });
                }

                if (questionType == 1) //Multiple Choice
                {
                    List<string> alternatives = new();

                    using (SqlConnection connection = new(sqlConnection))
                    {
                        alternatives = connection.Query<string>("SELECT Alternative FROM Multiple_Choice_Question WHERE Question_ID = @Question_ID", new { Question_ID = key }).ToList();
                    }

                    MultipleChoiseQuestion multipleChoiseQuestion = new(questionText, alternatives);

                    loadedSurvey.AddQuestion(multipleChoiseQuestion);
                }
                else if (questionType == 2) //FreeTextQuestion
                {
                    FreetextQuestion freetextQuestion = new(questionText);

                    loadedSurvey.AddQuestion(freetextQuestion);
                }

                else if (questionType == 3) //YesOrNoQuestion
                {
                    YesOrNoQuestion yesOrNoQuestion = new(title);

                    loadedSurvey.AddQuestion(yesOrNoQuestion);
                }

                else if (questionType == 4)//ScaleQuestion
                {
                    string value1;
                    string value10;

                    using (SqlConnection connection = new(sqlConnection))
                    {
                        value1 = connection.QueryFirstOrDefault<string>("SELECT Value_1 FROM Scale_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key });
                        value10 = connection.QueryFirstOrDefault<string>("SELECT Value_10 FROM Scale_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key });
                    }

                    _1_to_10 scaleQuestion = new(questionText, value1, value10);

                    loadedSurvey.AddQuestion(scaleQuestion);
                }
            }
            return loadedSurvey;
        }
    }
}
