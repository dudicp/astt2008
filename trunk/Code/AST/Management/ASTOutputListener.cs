using System;
using System.Collections.Generic;
using System.Text;

namespace AST.Management {

    interface  ASTOutputListener{

        void DisplayWelcomeScreen();
        void DisplayErrorMessage(String message);
        void DisplayInfoMessage(String message);
    }
}
