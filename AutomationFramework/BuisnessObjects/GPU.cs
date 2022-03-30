using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.BuisnessObjects
{
    internal class GPU
    {
        public string GpuType { get; set; }
        public int Amount { get; set;}

        public GPU(){}

        public GPU(string gpuType, int amount)
        {
            GpuType = gpuType;
            Amount = amount;
        }
    }
}
