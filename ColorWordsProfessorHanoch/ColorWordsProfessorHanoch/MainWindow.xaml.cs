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
using FindTheVaul;

namespace ColorWordsProfessorHanoch
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

        private void change_Text_Click(object sender, RoutedEventArgs e)
        {
            
            var parsedText = HebrewParser.GetListOfLetterWithColorFromCharArry(textBox_Original_Text.Text.ToCharArray());
            foreach (var letterWithColor in parsedText)
            {
                
                textBox_Resalut_Text.Text = textBox_Resalut_Text.Text + letterWithColor.Letter
            }
        }
    }
}
