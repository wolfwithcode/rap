using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Application_RAP_v01
{
    public class ResearcherController
    {
        List<Researcher> res = ERDAdapter.fetchBasicResearcherDetails();
        public List<Researcher> LoadResearchers()
        {
            //foreach (var e in res)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            return res;
        }
    }
}
