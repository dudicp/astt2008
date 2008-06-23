using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;
using System.Xml;
using System.IO;


namespace AST.Database{

    class XMLHandler : IResultHandler{

        public XMLHandler() { }

        public void Save(Result res, String reportName){
            if(!File.Exists(reportName + ".xml")) {
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

            // Write Status element
            if(res.Status)
                this.AppendChild("Status", "Success", resultNode, xmlDoc);
            else this.AppendChild("Status", "Fail", resultNode, xmlDoc);

            // Write Message element
            this.AppendChild("Message", res.Message, resultNode, xmlDoc);

            xmlDoc.DocumentElement.AppendChild(resultNode);
            xmlDoc.Save(reportName + ".xml");
        }

        private void AppendChild(String name, String value, XmlElement node, XmlDocument xmlDoc) {
            XmlElement appendedElement = xmlDoc.CreateElement(name);
            XmlText xmlText = xmlDoc.CreateTextNode(value.Trim());
            appendedElement.AppendChild(xmlText);
            node.AppendChild(appendedElement);
        }

        private String ResolveReportName(String fullPathReportName) {
            int index = fullPathReportName.LastIndexOf("\\");
            if (index >= 0) {
                return fullPathReportName.Substring(index+1);
            }
            else return fullPathReportName;
        }
    }
}
