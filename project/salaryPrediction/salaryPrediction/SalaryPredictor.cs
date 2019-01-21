using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDotNet;
using System.IO;

namespace salaryPrediction
{
    class SalaryPredictor
    {
        private string path;
        private REngine engine;

        public SalaryPredictor(string pathToDate)
        {
            SetupPath();
            path = pathToDate;
            engine = REngine.GetInstance();
            engine.Initialize();
        }
        public void GetModel()
        {
            var command0 = @"install.packages('ggplot2')
                             install.packages('caret', dependencies = TRUE)
                             install.packages('e1071');
                             install.packages('dplyr')
                             library(ggplot2)
                             library(caret)
                             library(dplyr)";
            //engine.Evaluate(command0);
            var command1 = @"data <- read.csv('C:\\mdda/nj_teachers_salaries_2016.csv', header=TRUE, sep=',')";
            engine.Evaluate(command1);
            var command2 = @"data<-na.omit(data)
                            data<-data[data$salary<=200000&data$salary>25000,]";
            engine.Evaluate(command2);
            var command3 = @"lmh1 <- lm (salary ~ experience_total + subcategory + highly_qualified + fte , data = data)";
            engine.Evaluate(command3);
            int test = 4;
        }
        public string Predict(int exp, string county, string subcategory, string qualified, int fte)
        {
            string command0 = @" params <- data.frame('experience_total' =" +exp+ ", 'county' = '" +county+ "', 'subcategory' = '" +subcategory+ "', 'highly_qualified' = '" +qualified+ "', 'fte' =" +fte+ ")";
            engine.Evaluate(command0);
            string command1 = @"predictions <- predict(lmh1, params)";
            engine.Evaluate(command1);
            return engine.Evaluate("as.character(predictions)").AsCharacter().ToArray()[0];
        }
        public static void SetupPath()
        {
            var oldPath = Environment.GetEnvironmentVariable("PATH");
            var rPath1 = @"C:\Program Files\R\R-3.4.4\bin\x64";
            var rPath2 = @"C:\Users\igorb\Documents\R\win-library\3.4\caret\R";
            if (!Directory.Exists(rPath1))
                throw new DirectoryNotFoundException(string.Format(" R.dll not found in : {0}", rPath1));
            var newPath = string.Format("{0}{1}{2}", rPath1, Path.PathSeparator, oldPath);
            newPath = string.Format("{0}{1}{2}", rPath2, Path.PathSeparator, newPath);
            Environment.SetEnvironmentVariable("PATH", newPath);
        }
        public void Dispose() => engine.Dispose();
    }
}
