using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Utils
{
    internal class Wait
    {
        public static void For(Func<bool> condition, double timeOut = 5000)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeOut)
            {
                try
                {
                    if (condition())
                    {
                        return;
                    }
                }
                catch (Exception)
                {
                    // skip
                }
                Thread.Sleep(50);
            }
        }

        public static void ABit(int timeout = 1500)
        {
            Thread.Sleep(timeout);
        }
    }
}
