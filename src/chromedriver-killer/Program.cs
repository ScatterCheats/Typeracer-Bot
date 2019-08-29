using System.Diagnostics;
using System.Linq;

namespace chromedriver_killer
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.GetProcessesByName("chromedriver").ToList().ForEach(proc => proc.Kill());
        }
    }
}
