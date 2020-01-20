using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIM.Core;

namespace AIM.GH
{
    public class Log
    {
        public static string GetLog(Model model)
        {
            StringBuilder log = new StringBuilder();

            log.AppendLine("Components count: " + model.sequence.Count.ToString());
            log.AppendLine("Obstacles count: " + model.obstacles.Count.ToString());

            return log.ToString();
        }

        public static string GetLog(Component component)
        {
            StringBuilder log = new StringBuilder();

            log.AppendLine("Components count: " + component.elements.Count.ToString());//
            //log.AppendLine("Obstacles count: " + model.obstacles.Count.ToString());

            return log.ToString();
        }

    }
}