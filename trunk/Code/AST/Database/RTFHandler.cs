using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;
using System.IO;


namespace AST.Database{

    class RTFHandler : IResultHandler{

        public RTFHandler() { }

        public void Save(Result res, String reportName){
            TextWriter tw = new StreamWriter("test.rtf",false);
            tw.Write("{\\rtf1\\fbidis\\ansi\\ansicpg1255\\deff0\\deflang1037");
            tw.Write("{\\fonttbl{\\f0\\fswiss\\fprq2\\fcharset0 Verdana;}");
            tw.Write("{\\f1\\fswiss\\fcharset177{\\*\\fname Arial;}Arial (Hebrew);}}");
            tw.Write("{\\colortbl ;\\red0\\green255\\blue0;}");
            tw.Write("{\\*\\generator Msftedit 5.41.21.2507;}");
            tw.Write("\\viewkind4\\uc1\\pard\\rtlpar\\lang1033\\b\\f0\\fs20 Action Name:\\b0  action1\\par");
            tw.Write("\\b End-Station:\\b0  name(IP)\\lang1037\\f1\\rtlch\\par");
            tw.Write("\\lang1033\\b\\f0\\ltrch Execution Time:\\b0  20:00:00\\par");
            tw.Write("\\b Message:\\b0  msg\\par");
            tw.Write("\\b Status:\\b0  \\cf1\\b Success\\cf0\\lang1037\\b0\\f1\\rtlch\\par");
            tw.Write("}");
            tw.Close();
        }
    }
}
