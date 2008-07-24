using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AST.Management
{

    interface ExecutionManagerOutputListener
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress">The value of the wanted progress.</param>
        /// <param name="results"></param>


        void UpdateProgress(int progress, Queue results);

        void UpdateCurrrentAction(String currentActionName, int totalActions);

        void ExecutionFinish();

        void DisplayMessage(String message);
    }
}
