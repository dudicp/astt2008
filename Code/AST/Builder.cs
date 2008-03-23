using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;

namespace AST{

    class Builder{

        private Hashtable m_actions;
        private List<Parameter> m_params;
        private static Builder m_instance = null;

        private Builder(){
            this.m_actions = new Hashtable();
            this.m_params = new List<Parameter>();
            this.Init();
        }

        public static Builder GetInstance(){
            if (m_instance == null) m_instance = new Builder();
            return m_instance;
        }

        private void Init(){
            Action a1 = BuildAction("Action1");
            Action a2 = BuildAction("Action2");
            Parameter p1 = BuildParameter("param1");
            Parameter p2 = BuildParameter("param2");
            Parameter p3 = BuildParameter("param3");
            a1.AddParameter(p1);
            a1.AddParameter(p2);

            m_actions.Add(a1.Name, a1);
            m_actions.Add(a2.Name, a2);
            m_params.Add(p1);
            m_params.Add(p2);
            m_params.Add(p3);

        }

        public AbstractAction GetAction(String name, AbstractAction.AbstractActionTypeEnum type){
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION:{
                    if (m_actions.Contains(name)) return (AbstractAction)m_actions[name];
                    else return null;
                    }
                default: return null;
            }
        }

        public void Save(AbstractAction action, AbstractAction.AbstractActionTypeEnum type) {
            switch (type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION: {
                        if (m_actions.Contains(action.Name)) m_actions.Remove(action.Name);
                        m_actions.Add(action.Name, action);
                        break;
                    }
            }
        }

        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type){
            if(type != AbstractAction.AbstractActionTypeEnum.ACTION) return new Hashtable();

            Hashtable info = new Hashtable();
            ICollection names = this.m_actions.Keys;

            foreach (String name in names)
                info.Add(name, ((Action)m_actions[name]).Description);
            
            return info;
        }

        public List<Parameter> GetParameters(String name){
            if (!m_actions.Contains(name)) return null;
            return this.m_params;
        }

        private Action BuildAction(String name){
            Action a = new Action(name,
                "Description "+name,
                92,
                "CreatorName",
                new DateTime(2008, 03, 21, 17, 42, 33, 2),
                7,
                Action.ActionTypeEnum.SCRIPT,
                59);
            a.AddContent(EndStation.OSTypeEnum.WINDOWS, "WinContent");
            a.AddValidityString(EndStation.OSTypeEnum.WINDOWS, "Validity String");
            a.AddContent(EndStation.OSTypeEnum.UNIX, "UnixContent");
            a.AddValidityString(EndStation.OSTypeEnum.UNIX,"Validity String");
            return a;
        }

        private Parameter BuildParameter(String name){
            if (name.Equals("param1")) return new Parameter(name, "Description " + name, Parameter.ParameterTypeEnum.Input, "Validity Exp");
            return new Parameter(name, "Description "+name, Parameter.ParameterTypeEnum.Option, "Validity Exp");
        }
    }
}
