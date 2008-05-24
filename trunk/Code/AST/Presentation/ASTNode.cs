using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Presentation{

    class ASTNode  : System.Windows.Forms.TreeNode{

        private AbstractAction m_abstractAction;
        private AbstractAction.AbstractActionTypeEnum m_type;

        public ASTNode(AbstractAction a, AbstractAction.AbstractActionTypeEnum type)
            :base(a.Name) {
            m_abstractAction = a;
            m_type = type;
            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) this.SetTSCNode();
        }

        private void SetTSCNode() {
            List<Action> actions = ((TSC)(m_abstractAction)).GetActions();
            foreach (Action a in actions)
                this.Nodes.Add(new ASTNode(a, AbstractAction.AbstractActionTypeEnum.ACTION));
        }

        public AbstractAction Value {
            get { return m_abstractAction; }
            set { m_abstractAction = value; }
        }

        public AbstractAction.AbstractActionTypeEnum Type {
            get { return m_type; }
            set { m_type = value; }
        }

    }
}
