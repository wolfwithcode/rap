using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Application_RAP_v01
{
    public enum Campus { Hobart, Launceston, CradleCoast }
    public enum Level { A,B,C,D,E, Student}
    public class Researcher
    {
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public Campus Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Level _Level { get; set ; }

        //public List<Position> ThePosition { get; set; }
        //public Position ThePosition { get; set; }
        //public List<Publication> ThePublication { get; set; }

        //public Position GetCurrentJob()
        //{
        //    Position pos = new Position();
        //    return pos;
        //}
        //public string CurrentJobTitle()
        //{
        //    return "";
        //}
        //public DateTime CurrentJobStart()
        //{
        //    return DateTime.Today;
        //}
        //public Position GetEarliestJob()
        //{
        //    Position pos = new Position();
        //    return pos;
        //}
        public DateTime EarliestStart()
        {
            return DateTime.Today;
        }
        public float Tenure()
        {
            return 0;
        }
        public int PublicationsCount()
        {
            return 0;
        }

        //Test
        public override string ToString()
        {
            return String.Format("{0}, {1} ({2})", GivenName, FamilyName, Title);
        }
    }
}
