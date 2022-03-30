using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.BuisnessObjects;

namespace AutomationFramework.Utils
{
    static class GpuFactory
    {
        public static GPU GetNVIDIAV100Gpu(int amount = 8) => new GPU() {Amount = amount, GpuType = "NVIDIA Tesla V100" };
    }
}
