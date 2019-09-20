using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Application_RAP_v01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Researcher> researchers;
        public MainWindow()
        {
            InitializeComponent();
            //researchersListBox.ItemsSource = new Record[]
            //{
            //    new Record {Researcher="Anh" },
            //    new Record {Researcher="Banh" },
            //    new Record {Researcher="Ben" },
            //    new Record {Researcher="Doraemon" },
            //    new Record {Researcher="Who" },
            //    new Record {Researcher="Anh" },
            //    new Record {Researcher="Banh" },
            //    new Record {Researcher="Ben" },
            //    new Record {Researcher="Doraemon" },
            //    new Record {Researcher="Who" },
            //    new Record {Researcher="Anh" },
            //    new Record {Researcher="Banh" },
            //    new Record {Researcher="Ben" },
            //    new Record {Researcher="Doraemon" },
            //    new Record {Researcher="Who" }
            //};
            //load researcher table
            ResearcherController rc = new ResearcherController();            
            researchers = rc.LoadResearchers();
            //select first name
            //IEnumerable<string> researcherNames = from re in researchers select re.FamilyName;
            //IEnumerable<string> researcherNames = researchers.Select(re => String.Format("{0}, {1} ({2})", re.GivenName, re.FamilyName, re.Title));
            IEnumerable<string> researcherNames = researchers.Select(re => String.Format("{0}, {1} ({2}) Position is {3}", re.GivenName, re.FamilyName, re.Title, re._Level));
            //researchersListBox.ItemsSource = new string[] { "Anh", "Banh" };
            researchersListBox.ItemsSource = researcherNames;
            levelComboBox.ItemsSource = new string[] { "A", "B", "C", "D", "E", "Students only" };
        }
        public class Record
        {
            public string Researcher { get; set; }
        }

        private void txtNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txtOrig = txtNameToSearch.Text;            
            string lower = txtOrig.ToLower();
            IEnumerable<string> filteredResearches =    researchers
                                                        .Where(re => (re.FamilyName + re.GivenName).ToLower().Contains(lower))
                                                        .Select(re => String.Format("{0}, {1} ({2}) Position is {3}", re.GivenName, re.FamilyName, re.Title, re._Level));
            researchersListBox.ItemsSource = filteredResearches;
        }

        private void levelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string levelString = levelComboBox.SelectedItem.ToString();
            if (levelString == "Students only") levelString = "Student";
            Level selectedLevel = ERDAdapter.ParseEnum<Level>(levelString);
            IEnumerable<string> filteredResearches = researchers
                                                       .Where(re => re._Level == selectedLevel)
                                                       .Select(re => String.Format("{0}, {1} ({2}) Position is {3}", re.GivenName, re.FamilyName, re.Title, re._Level));
            researchersListBox.ItemsSource = filteredResearches;
        }
    }
}
