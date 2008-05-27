using System;
using System.Collections.Generic;
using System.Text;

namespace AST.Management {

    interface ExecutionManagerOutputListener {

        /// <summary>
        /// Updating the progress bar method.
        /// </summary>
        /// <param name="progress">The value of the wanted progress.</param>
        /// <param name="currentAction">The current action name executing.</param>
        /// <param name="currentRound">The current round number.</currentRound>
        /// <param name="totalRounds">The total number of rounds.</totalRounds>
        void UpdateProgress(int progress, String currentAction, int currentRound, int totalRounds);

    }
}
