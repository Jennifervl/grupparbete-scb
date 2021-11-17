using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {
        static Menu menu = new();
        static UserList userList = new();
        static SurveyLibrary surveyLibrary = new();

        static User_Survey_Repository usr = new();

        static void Main(string[] args)
        {
            userList.LoadUsers();
            surveyLibrary.LoadSurveys();

            menu.MyMenu(userList, surveyLibrary, usr);
            // Survey survey = Admin.BuildSurvey();
            // AnswerSurvey(survey);
        }
    }
}
