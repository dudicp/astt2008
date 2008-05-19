using System;

namespace AST.Domain{

    public class EndStationSchedule{

        private EndStation m_endStation;
        private int m_executionOrder;
        private int m_delay;

        public EndStationSchedule(EndStation es){
            m_endStation = es;
            m_executionOrder = 0;
            m_delay = 0;
        }

        public EndStationSchedule(EndStation es, int executionOrder, int delay){
            m_endStation = es;
            m_executionOrder = executionOrder;
            m_delay = delay;
        }

        public EndStation EndStation{
            get { return m_endStation; }
            set { m_endStation = value; }
        }

        public int ExecutionOrder{
            get { return m_executionOrder; }
            set { m_executionOrder = value; }
        }

        public int Delay{
            get { return m_delay; }
            set { m_delay = value; }
        }

        public override bool Equals(Object o) {
            //if (o.GetType() != EndStationSchedule) return false;
            if (((EndStationSchedule)o).EndStation != this.EndStation) return false;
            if (((EndStationSchedule)o).ExecutionOrder != this.ExecutionOrder) return false;
            if (((EndStationSchedule)o).Delay != this.Delay) return false;
            return true;
        }
    }
}
