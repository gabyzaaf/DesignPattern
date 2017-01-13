using System.Collections.Generic;

namespace MetroLib.Factory
{
    public abstract class ManagerPlanFactory
    {

        public static ManagerPlan createManager(string strPlan, string[] tabS, string[] tabL)
        {
            return new ManagerPlan(strPlan, tabS, tabL);
        }
    }
}
