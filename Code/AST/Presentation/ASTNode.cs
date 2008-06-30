using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Presentation{
    /// <summary>
    /// 
    /// </summary>
    class ASTNode  : System.Windows.Forms.TreeNode{

        private AbstractAction m_abstractAction;
        private AbstractAction.AbstractActionTypeEnum m_type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="type"></param>
        public ASTNode(AbstractAction a, AbstractAction.AbstractActionTypeEnum type)
            :base(a.Name) {
            m_abstractAction = a;
            m_type = type;
            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) this.SetTSCNode();
            else if (m_type == AbstractAction.AbstractActionTypeEnum.TP) this.SetTPNode();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetTSCNode() {
            List<Action> actions = ((TSC)(m_abstractAction)).GetActions();
            foreach (Action a in actions)
                this.Nodes.Add(new ASTNode(a, AbstractAction.AbstractActionTypeEnum.ACTION));
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetTPNode() {
            List<TSC> tscs = ((TP)(m_abstractAction)).GetTSCs();
            foreach (TSC tsc in tscs)
                this.Nodes.Add(new ASTNode(tsc, AbstractAction.AbstractActionTypeEnum.TSC));
        }

        /// <summary>
        /// 
        /// </summary>
        public AbstractAction Value {
            get { return m_abstractAction; }
            set { m_abstractAction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AbstractAction.AbstractActionTypeEnum Type {
            get { return m_type; }
            set { m_type = value; }
        }

    }
}
