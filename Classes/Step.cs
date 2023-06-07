using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROGPOE.Classes
{
    public class Step
    {
        public string stepDescription;

        /// <summary>
        /// step object
        /// </summary>
        /// <param name="stepDescription"></param>
        public Step(string stepDescription)
        {
            this.stepDescription = stepDescription;
        }

        /// <summary>
        /// Sets step description
        /// </summary>
        /// <param stepDescription="new_stepDescription"> description entered </param>
        public void setStepDescription(string new_stepDescription)
        {
            stepDescription = new_stepDescription;
        }

        /// <summary>
        /// Gets step description
        /// </summary>
        /// <returns> step description </returns>
        public string getStepDescription()
        {
            return stepDescription;
        }
    }
}
//______________________________0---------------------------> End of File <---------------------------0______________________________

