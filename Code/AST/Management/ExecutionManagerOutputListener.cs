using System;
using System.Collections.Generic;
using System.Text;

namespace AST.Management {

    interface ExecutionManagerOutputListener {

        void UpdateProgress(int progress, String currentAction, int roundNumber);

    }
}
