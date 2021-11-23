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
            if (user is Admin)
            {
                Admin admin = user as Admin;

                using (SqlConnection connection = new(sqlConnection))
                {
                    connection.Execute("INSERT INTO [User](SSN, PW, Salt) VALUES (@SSN, @PW, @Salt)", new { SSN = admin.Ssn, PW = admin.Pw.HashedPassword, Salt = admin.Pw.Salt });
                }
            }

            else if (user is Participant)
            {
                Participant part = user as Participant;

                using (SqlConnection connection = new(sqlConnection))
                {
                    connection.Execute("INSERT INTO [User](SSN) VALUES (@SSN);", new { SSN = part.Ssn });
                }
            }
        }

        public void SaveUser_Survey(User_Survey us)
        {
            using (SqlConnection connection = new(sqlConnection))
            {
                int userKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM [User] WHERE Ssn = @Ssn;", new { Ssn = us.GetUserSsn() });
                int surveyKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM Survey WHERE Title = @Title;", new { Title = us.GetSurvey().Title });

                connection.Execute("INSERT INTO User_Survey(Survey_ID, User_ID, IsSubmitted, User_Specific_Code) VALUES (@Survey_ID, @User_ID, @IsSubmitted, @User_Specific_Code);", new { Survey_ID = surveyKey, User_ID = userKey, IsSubmitted = us.IsSubmitted, User_Specific_Code = us.GetUserCode() });
            }
        }

        public void SaveSurveyAnswers(Survey survey)
        {
            using (SqlConnection connection = new(sqlConnection))
            {
                int surveyKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM Survey WHERE Title = @Title;", new { Title = survey.Title });
                List<int> questionKeyList = connection.Query<int>("SELECT ID FROM Question WHERE Survey_ID = @Survey_ID;", new { Survey_ID = surveyKey }).ToList();

                int indexCheck = 0;

                foreach (int key in questionKeyList)
                {
                    int type = connection.QueryFirstOrDefault<int>("SELECT Type FROM Question WHERE ID = @ID;", new { ID = key });

                    if (type == 1) //MultipleChoice
                    {
                        Question q = survey.GetQuestions()[indexCheck];
                        MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;

                        List<int> mcqKeyList = connection.Query<int>("SELECT ID FROM Multiple_Choice_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key }).ToList();
                        int mcqIndex = 0;
                        foreach (int mcqKey in mcqKeyList)
                        {
                            connection.Execute("INSERT INTO Multiple_Choice_Answer(Multiple_Choice_Question_ID, Answer) VALUES (@Multiple_Choice_Question_ID, @Answer)", new { Multiple_Choice_Question_ID = mcqKey, Answer = mcq.GetAnswer()[mcqIndex] });
                            mcqIndex++;
                        }
                    }

                    else if (type == 2)//FreeTextQuestion
                    {
                        Question q = survey.GetQuestions()[indexCheck];
                        FreetextQuestion ftq = q as FreetextQuestion;

                        connection.Execute("INSERT INTO Free_Text_Question(Question_ID, Answer) VALUES (@Question_ID, @Answer);", new { Question_ID = key, Answer = ftq.GetAnswer() });
                    }

                    else if (type == 3)//YesOrNoQuestion
                    {
                        Question q = survey.GetQuestions()[indexCheck];
                        YesOrNoQuestion yorq = q as YesOrNoQuestion;

                        connection.Execute("INSERT INTO True_False_Question(Question_ID, Answer) VALUES (@Question_ID, @Answer);", new { Question_ID = key, Answer = yorq.GetAnswer() });
                    }

                    else if (type == 4)//ScaleQuestion
                    {
                        Question q = survey.GetQuestions()[indexCheck];
                        _1_to_10 scaleQ = q as _1_to_10;

                        int scaleKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM Scale_Question WHERE Question_ID = @Question_ID", new { Question_ID = key });
                        connection.Execute("INSERT INTO Scale_Question_Answer(Scale_Question_ID, Answer) VALUES (@Scale_Question_ID, @Answer);", new { Scale_Question_ID = scaleKey, Answer = scaleQ.Answer });
                    }

                    indexCheck++;
                }
            }
        }

        public void UpdateUser_Survey(User_Survey user_Survey)
        {
            using (SqlConnection connection = new(sqlConnection))
            {
                int surveyKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM Survey WHERE Title = @Title;", new { Title = user_Survey.GetSurvey().Title });
                int userKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM [User] WHERE SSN = @SSN;", new { SSN = user_Survey.GetUserSsn() });

                connection.Execute("UPDATE User_Survey SET IsSubmitted = 1 WHERE User_ID = @User_ID AND Survey_ID = @Survey_ID;", new { User_ID = userKey, Survey_ID = surveyKey });
            }
        }
    }
}
