using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;
using System.IO;


namespace AST.Database
{
    /// <summary>
    /// this class is responsible for creating a .TXT result file
    /// </summary>
    class TXTHandler : IResultHandler
    {

        /// <summary>
        /// CTor for TXTHandler class
        /// </summary>
        public TXTHandler() { }

        /// <summary>
        /// Method for saving a result object on the report file.
        /// </summary>
        /// <param name="res">a result object</param>
        /// <param name="reportName">the report filename</param>
        public void Save(Result res, String reportName)
        {
            TextWriter tw = new StreamWriter(reportName + ".txt", true);

            tw.WriteLine("-------------------------------------------------");
            tw.WriteLine("Action: " + res.GetAction().Name);
            tw.WriteLine("End-Station: " + res.GetEndStation().Name + "(" + res.GetEndStation().IP.ToString() + ")");
            tw.WriteLine("Start Time: " + res.StartTime.ToString());
            tw.WriteLine("End Time: " + res.EndTime.ToString());
            if (res.Status)
                tw.WriteLine("Status: Success");
            else
                tw.WriteLine("Status: Failed");
            tw.WriteLine("Message: \n" + res.Message);
            tw.WriteLine("-------------------------------------------------");
            tw.Close();
        }

        /// <summary>
        /// Method for showing a report.
        /// </summary>
        /// <param name="reportName">the report name</param>
        public void ShowReport(String reportName)
        {
            if (!File.Exists(reportName + ".txt"))
            {
                throw new OpenFileFailedException("File: " + reportName + ".txt doesn't exist.");
            }
            System.Diagnostics.ProcessStartInfo procFormsBuilderStartInfo = new System.Diagnostics.ProcessStartInfo();
            procFormsBuilderStartInfo.FileName = reportName + ".txt";
            procFormsBuilderStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            System.Diagnostics.Process procFormsBuilder = new System.Diagnostics.Process();
            try
            {
                procFormsBuilder.StartInfo = procFormsBuilderStartInfo;
                procFormsBuilder.Start();
            }
            catch (Exception e)
            {
                throw new OpenFileFailedException("Unable to open the report file: " + reportName + ".txt", e);
            }
        }
    }
}
