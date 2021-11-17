using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace SurveyLib
{
    public class SaveDataManager
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
            IList<Question> questionList = survey.GetQuestions();
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

        public void SaveUser(User user)
        {
            using (SqlConnection connection = new(sqlConnection))
            {
                connection.Execute("INSERT INTO [User](SSN, Role) VALUES (@SSN, @Role)", new { SSN = user.GetUserSsn(), Role = user.GetUserRole() });
            }
        }
    }
}
