using System;

namespace AST.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class EndStationSchedule
    {

        private EndStation m_endStation;
        private int m_executionOrder;
        private int m_delay;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="es"></param>
        public EndStationSchedule(EndStation es)
        {
            m_endStation = es;
            m_executionOrder = 0;
            m_delay = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="es"></param>
        /// <param name="executionOrder"></param>
        /// <param name="delay"></param>
        public EndStationSchedule(EndStation es, int executionOrder, int delay)
        {
            m_endStation = es;
            m_executionOrder = executionOrder;
            m_delay = delay;
        }
        /// <summary>
        /// 
        /// </summary>
        public EndStation EndStation
        {
            get { return m_endStation; }
            set { m_endStation = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ExecutionOrder
        {
            get { return m_executionOrder; }
            set { m_executionOrder = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Delay
        {
            get { return m_delay; }
            set { m_delay = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            //if (o.GetType() != EndStationSchedule) return false;
            if (((EndStationSchedule)o).EndStation != this.EndStation) return false;
            if (((EndStationSchedule)o).ExecutionOrder != this.ExecutionOrder) return false;
            if (((EndStationSchedule)o).Delay != this.Delay) return false;
            return true;
        }
    }
}
