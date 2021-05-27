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

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String nice = "nice";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("You have selected " + e.AddedItems[0]);
        }

        private void ResearcherListView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /*
         * Assumption: A selectedResearcher variable is present, initiated/initalized and
         * stores a bool(?) value defining what type of Researcher is selected (staff or
         * student).
         * 
         * if (selectedResearcher == staff)
         * {
         *      display following labels, i.e. set to non-collapsed
         *      
         *      Name
         *      Title
         *      School/Unit
         *      Campus
         *      Email
         *      Photo
         *      Current Job Title
         *      Commenced w/ Institution
         *      Commenced current position
         *      Tenure
         *      Publications
         *      3-year Average
         *      Performance
         *      Supervisions
         * } else {
         *      set 3-year, Performance, Supervisions to collapsed
         *      
         *      display following labels, i.e. set to non-collapsed
         *      
         *      Degree
         *      Supervisor
         * }
         */
        
    }
}
