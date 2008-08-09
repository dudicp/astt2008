using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;
using System.Xml;
using System.IO;



namespace AST.Database{
    /// <summary>
    /// this class is responsible for creating a .XML result file
    /// </summary>
    class XMLHandler : IResultHandler{
        
        /// <summary>
        /// CTor for XMLHandler class
        /// </summary>
        public XMLHandler() { }
        
        /// <summary>
        /// Method for saving a result object on the report file.
        /// </summary>
        /// <param name="res">a result object</param>
        /// <param name="reportName">the report filename</param>
        public void Save(Result res, String reportName){
            try {
                if (!File.Exists(reportName + ".xml")) {
                    XmlTextWriter textWriter = new XmlTextWriter(reportName + ".xml", null);

                    textWriter.WriteStartDocument();

                    //Write the ProcessingInstruction node.
                    String PItext = "type='text/xsl' href='Report.xsl'";
                    textWriter.WriteProcessingInstruction("xml-stylesheet", PItext);

                    // Write root element
                    textWriter.WriteStartElement("Report");
                    textWriter.WriteStartAttribute("name");
                    textWriter.WriteValue(this.ResolveReportName(reportName));
                    textWriter.WriteEndAttribute();


                    // Close root element
                    textWriter.WriteEndDocument();
                    textWriter.Close();
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reportName + ".xml");

                XmlElement resultNode = xmlDoc.CreateElement("Result");

                // Write ActionName element
                this.AppendChild("ActionName", res.GetAction().Name, resultNode, xmlDoc);

                // Write ActionType element
                this.AppendChild("ActionType", res.GetAction().ActionType.ToString(), resultNode, xmlDoc);

                // Write EndStationID element
                this.AppendChild("EndStationID", "" + res.GetEndStation().ID, resultNode, xmlDoc);

                // Write EndStationName element
                this.AppendChild("EndStationName", res.GetEndStation().Name, resultNode, xmlDoc);

                // Write EndStationIP element
                this.AppendChild("EndStationIP", res.GetEndStation().IP.ToString(), resultNode, xmlDoc);

                // Write StartTime element
                this.AppendChild("StartTime", res.StartTime.ToString(), resultNode, xmlDoc);

                // Write EndTime element
                this.AppendChild("EndTime", res.EndTime.ToString(), resultNode, xmlDoc);

                // Write ErrorCode element
                this.AppendChild("ErrorCode", ""+res.ErrorCode, resultNode, xmlDoc);

                // Write ValidityString element
                string vs = res.GetAction().GetValidityString(EndStation.OSTypeEnum.WINDOWS);
                if (vs == null || vs.Length==0) this.AppendChild("ValidityString", "-", resultNode, xmlDoc);
                else this.AppendChild("ValidityString", res.GetAction().GetValidityString(EndStation.OSTypeEnum.WINDOWS), resultNode, xmlDoc);

                // Write Status element
                if (res.Status)
                    this.AppendChild("Status", "Success", resultNode, xmlDoc);
                else this.AppendChild("Status", "Fail", resultNode, xmlDoc);

                // Write Message element
                XmlElement messageNode = xmlDoc.CreateElement("Message");
                String[] lines = res.Message.Split(new char[] { '\n' });
                foreach (String line in lines) {
                    this.AppendChild("Line", line, messageNode, xmlDoc);
                }
                resultNode.AppendChild(messageNode);

                xmlDoc.DocumentElement.AppendChild(resultNode);
                xmlDoc.Save(reportName + ".xml");
            }
            catch (System.IO.DirectoryNotFoundException e) {
                throw new SaveReportException("Directory not found: " + reportName + ".xml", e);
            }
            catch (System.Security.SecurityException e) {
                throw new SaveReportException("Insufficient security privileges to create report file.", e);
            }
            catch (System.UnauthorizedAccessException e) {
                throw new SaveReportException("Insufficient access privileges to create report file.", e);
            }
            catch (Exception e) {
                throw new SaveReportException("Failed creating report file " + reportName + ".xml", e);
            }
        }

        /// <summary>
        /// Method for showing a report.
        /// </summary>
        /// <param name="reportName">the report name</param>
        public void ShowReport(String reportName)
        {
            if (!File.Exists(reportName + ".xml")) {
                throw new OpenFileFailedException("File: " + reportName + ".xml doesn't exist.");
            }
            System.Diagnostics.ProcessStartInfo procFormsBuilderStartInfo = new System.Diagnostics.ProcessStartInfo();
            procFormsBuilderStartInfo.FileName = reportName + ".xml";
            procFormsBuilderStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            System.Diagnostics.Process procFormsBuilder = new System.Diagnostics.Process();
            try {
                procFormsBuilder.StartInfo = procFormsBuilderStartInfo;
                procFormsBuilder.Start();
            }
            catch (Exception e) {
                throw new OpenFileFailedException("Unable to open the report file " + reportName + ".xml", e);
            }
        }

        // Method for appending a child node
        private void AppendChild(String name, String value, XmlElement node, XmlDocument xmlDoc) {
            try {
                XmlElement appendedElement = xmlDoc.CreateElement(name);
                XmlText xmlText = xmlDoc.CreateTextNode(value.Trim());
                appendedElement.AppendChild(xmlText);
                node.AppendChild(appendedElement);
            }
            catch (Exception e) {
                throw e;
            }
        }

        // Method for resolving the full path filename
        private String ResolveReportName(String fullPathReportName) {
            try {
                int index = fullPathReportName.LastIndexOf("\\");
                if (index >= 0) {
                    return fullPathReportName.Substring(index + 1);
                }
                else return fullPathReportName;
            }
            catch (Exception e) {
                return fullPathReportName;
            }
        }
    }
}
