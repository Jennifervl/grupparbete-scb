using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace SurveyLib
{
    public class LoadDataManager
    {
        string sqlConnection = "Server = 40.85.84.155; Database=OOP_BLÅ;User=Student27;Password=big-bada-boom!";


        private Survey LoadSurvey(int pKey)
        {
            int primaryKey = pKey;
            string title;
            List<int> questionKeys = new();
            string questionText;

            using (SqlConnection connection = new(sqlConnection))
            {
                title = connection.QueryFirstOrDefault<string>("SELECT Title FROM Survey WHERE ID = @ID", new { ID = primaryKey });
                Survey loadedSurvey = new(title);
                questionKeys = connection.Query<int>("SELECT ID FROM Question WHERE Survey_ID = @Survey_ID;", new { Survey_ID = primaryKey }).ToList();

                foreach (int key in questionKeys)
                {
                    int questionType;

                    questionType = connection.QueryFirstOrDefault<int>("SELECT Type FROM Question WHERE ID = @ID;", new { ID = key });
                    questionText = connection.QueryFirstOrDefault<string>("SELECT QuestionText FROM QUESTION WHERE ID = @ID;", new { ID = key });

                    if (questionType == 1) //Multiple Choice
                    {
                        List<string> alternatives = new();

                        alternatives = connection.Query<string>("SELECT Alternative FROM Multiple_Choice_Question WHERE Question_ID = @Question_ID", new { Question_ID = key }).ToList();

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
                        YesOrNoQuestion yesOrNoQuestion = new(questionText);

                        loadedSurvey.AddQuestion(yesOrNoQuestion);
                    }

                    else if (questionType == 4)//ScaleQuestion
                    {
                        string value1 = connection.QueryFirstOrDefault<string>("SELECT Value_1 FROM Scale_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key });
                        string value10 = connection.QueryFirstOrDefault<string>("SELECT Value_10 FROM Scale_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key });

                        _1_to_10 scaleQuestion = new(questionText, value1, value10);

                        loadedSurvey.AddQuestion(scaleQuestion);
                    }
                }
                return loadedSurvey;
            }
        }

        public List<Survey> LoadAllSurveys()
        {
            List<Survey> allLoadedSurveys = new();
            List<int> surveyKeys = new();

            using (SqlConnection connection = new(sqlConnection))
            {
                surveyKeys = connection.Query<int>("SELECT ID FROM Survey;").ToList();
            }

            foreach (int key in surveyKeys)
            {
                allLoadedSurveys.Add(LoadSurvey(key));
            }

            return allLoadedSurveys;
        }

        public List<User> LoadAllUsers()
        {
            List<User> userList = new();
            List<int> userKeyList = new();

            using (SqlConnection connection = new(sqlConnection))
            {
                userKeyList = connection.Query<int>("SELECT ID FROM [User];").ToList();


                foreach (int key in userKeyList)
                {

                    string ssn = connection.QueryFirstOrDefault<string>("SELECT SSN FROM [User] WHERE ID = @ID;", new { ID = key });
                    string pw = "";
                    pw = connection.QueryFirstOrDefault<string>("SELECT [User].PW FROM [User] WHERE ID = @ID;", new { ID = key });
                    string salt = connection.QueryFirstOrDefault<string>("SELECT [User].Salt FROM [User] WHERE ID = @ID;", new { ID = key });
                    if (pw is null)
                    {
                        Participant p = new(ssn);
                        userList.Add(p);
                    }

                    else if (pw is not null)
                    {
                        Password hashedPass = new();
                        hashedPass.HashedPassword = pw;
                        hashedPass.Salt = salt;
                        Admin a = new(ssn, "p");
                        a.Pw = hashedPass;
                        userList.Add(a);
                    }
                }
            }

            return userList;
        }

        public List<User_Survey> LoadAllUser_Surveys()
        {
            using (SqlConnection connection = new(sqlConnection))
            {
                List<User_Survey> loadedUser_SurveyList = new();
                List<int> User_SurveyKeys = new();

                User_SurveyKeys = connection.Query<int>("SELECT ID FROM User_Survey;").ToList();


                foreach (int key in User_SurveyKeys)
                {

                    string ssn = connection.QueryFirstOrDefault<string>("SELECT [User].Ssn FROM [User] INNER JOIN User_Survey ON [User].ID = User_Survey.User_ID WHERE User_Survey.ID = @ID", new { ID = key });
                    string pw = connection.QueryFirstOrDefault<string>("SELECT [User].PW FROM [User] INNER JOIN User_Survey ON [User].ID = User_Survey.User_ID WHERE User_Survey.ID = @ID", new { ID = key });

                    if (pw is null)
                    {
                        Participant p = new(ssn);
                        int surveyKey = connection.QuerySingleOrDefault<int>("SELECT Survey_ID FROM User_Survey WHERE ID = @ID", new { ID = key });
                        Survey survey = LoadSurvey(surveyKey);
                        bool isSubmitted = connection.QuerySingleOrDefault<bool>("SELECT IsSubmitted FROM User_Survey WHERE ID = @ID", new { ID = key });
                        string code = connection.QuerySingleOrDefault<string>("SELECT User_Specific_Code FROM User_Survey WHERE ID = @ID", new { ID = key });

                        User_Survey user_Survey = new(p, survey, code, isSubmitted);
                        loadedUser_SurveyList.Add(user_Survey);
                    }

                    else if (pw is not null)
                    {
                        Admin admin = new(ssn, pw);
                        int surveyKey = connection.QuerySingleOrDefault<int>("SELECT Survey_ID FROM User_Survey WHERE ID = @ID", new { ID = key });
                        Survey survey = LoadSurvey(surveyKey);
                        bool isSubmitted = connection.QuerySingleOrDefault<bool>("SELECT IsSubmitted FROM User_Survey WHERE ID = @ID", new { ID = key });
                        string code = connection.QuerySingleOrDefault<string>("SELECT User_Specific_Code FROM User_Survey WHERE ID = @ID", new { ID = key });

                        User_Survey user_Survey = new(admin, survey, code, isSubmitted);
                        loadedUser_SurveyList.Add(user_Survey);
                    }


                }

                return loadedUser_SurveyList;
            }
        }

        public Survey LoadSurveyAnswers(Survey survey)
        {
            using (SqlConnection connection = new(sqlConnection))
            {
                int surveyKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM Survey WHERE Title = @Title;", new { Title = survey.Title });
                string surveyTitle = connection.QueryFirstOrDefault<string>("SELECT Title FROM Survey WHERE ID = @ID;", new { ID = surveyKey });

                Survey loadedSurvey = new(surveyTitle);

                List<int> questionKeys = connection.Query<int>("SELECT ID FROM Question WHERE Survey_ID = @Survey_ID;", new { Survey_ID = surveyKey }).ToList();

                foreach (int key in questionKeys)
                {
                    int type = connection.QueryFirstOrDefault<int>("SELECT Type FROM Question WHERE ID = @ID;", new { ID = key });

                    if (type == 1)//Multiple Choice Question
                    {
                        string questionText = connection.QueryFirstOrDefault<string>("SELECT QuestionText FROM Question WHERE ID = @ID;", new { ID = key });
                        List<string> alternatives = connection.Query<string>("SELECT Alternative FROM Multiple_Choice_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key }).ToList();
                        List<int> alternativeKeys = connection.Query<int>("SELECT ID FROM Multiple_Choice_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key }).ToList();
                        List<List<bool>> mcqAnswerList = new();

                        foreach (int altKey in alternativeKeys)
                        {
                            List<bool> mcqAnswer = connection.Query<bool>("SELECT Answer FROM Multiple_Choice_Answer WHERE Multiple_Choice_Question_ID = @Multiple_Choice_Question_ID;", new { Multiple_Choice_Question_ID = altKey }).ToList();
                            mcqAnswerList.Add(mcqAnswer);
                        }

                        MultipleChoiseQuestion mcq = new(questionText, alternatives);
                        foreach (List<bool> answer in mcqAnswerList)
                        {
                            mcq.SetAnswerFromDB(answer);
                        }

                        loadedSurvey.AddQuestion(mcq);
                    }

                    else if (type == 2)//FreeText
                    {
                        string questionText = connection.QueryFirstOrDefault<string>("SELECT QuestionText FROM Question WHERE ID = @ID;", new { ID = key });
                        List<string> freeTextAnswers = connection.Query<string>("SELECT Answer FROM Free_Text_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key }).ToList();

                        FreetextQuestion ftq = new(questionText);

                        foreach (string answer in freeTextAnswers)
                        {
                            ftq.SetAnswerFromDB(answer);
                        }

                        loadedSurvey.AddQuestion(ftq);
                    }

                    else if (type == 3)//YesOrNo
                    {
                        string questionText = connection.QueryFirstOrDefault<string>("SELECT QuestionText FROM Question WHERE ID = @ID;", new { ID = key });
                        List<bool> yesOrNoAnswers = connection.Query<bool>("SELECT Answer FROM True_False_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key }).ToList();

                        YesOrNoQuestion yonq = new(questionText);

                        foreach (bool answer in yesOrNoAnswers)
                        {
                            yonq.SetAnswerFromDB(answer);
                        }

                        loadedSurvey.AddQuestion(yonq);
                    }

                    else if (type == 4)//Scale question
                    {
                        string questionText = connection.QueryFirstOrDefault<string>("SELECT QuestionText FROM Question WHERE ID = @ID;", new { ID = key });
                        string value10 = connection.QueryFirstOrDefault<string>("SELECT Value_10 FROM Scale_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key });
                        string value1 = connection.QueryFirstOrDefault<string>("SELECT Value_1 FROM Scale_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key });
                        int scaleKey = connection.QueryFirstOrDefault<int>("SELECT ID FROM Scale_Question WHERE Question_ID = @Question_ID;", new { Question_ID = key });
                        List<int> scaleAnswers = connection.Query<int>("SELECT Answer FROM Scale_Question_Answer WHERE Scale_Question_ID = @Scale_Question_ID;", new { Scale_Question_ID = scaleKey }).ToList();


                        _1_to_10 scaleQuestion = new(questionText, value1, value10);

                        foreach (int answer in scaleAnswers)
                        {
                            scaleQuestion.SetAnswerFromDB(answer);
                        }

                        loadedSurvey.AddQuestion(scaleQuestion);
                    }
                }

                return loadedSurvey;
            }
        }
    }
}
