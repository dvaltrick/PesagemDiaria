using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PesagemDiaria
{
    public class App : Application
    {
        static PesagemDB database;

        public App()
        {
            // The root page of your application
            NavigationPage page = new NavigationPage(new pgMain());
            MainPage = page;
        }

        public static PesagemDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new PesagemDB();
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // always re-set when the app starts
            // users expect this (usually)
            //			Properties ["ResumeAtTodoId"] = "";
            if (Properties.ContainsKey("ResumeAtTodoId"))
            {
                var rati = Properties["ResumeAtTodoId"].ToString();
                if (!String.IsNullOrEmpty(rati))
                {
                    ResumeAtTodoId = int.Parse(rati);

                    
                }
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
