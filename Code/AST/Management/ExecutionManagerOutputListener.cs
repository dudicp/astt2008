using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AST.Management {

    interface ExecutionManagerOutputListener {

        /// <summary>
        /// Updating the progress bar method.
        /// </summary>
        /// <param name="progress">The value of the wanted progress.</param>
        void UpdateProgress(int progress, Queue results);

        void UpdateCurrrentAction(String currentActionName, int totalActions);

        void ExecutionFinish();
    }
}
