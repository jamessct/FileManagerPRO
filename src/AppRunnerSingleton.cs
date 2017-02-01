using System;
using System.Threading;

namespace ConsoleApplication
{
    public class AppRunnerSingleton
    {
        private static AppRunnerSingleton instance;

        private AppRunnerSingleton()
        {
            
        }

        public static AppRunnerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppRunnerSingleton();
                }
                return instance;
            }
        }
    }
}