using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NalogUser.Controls
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class SubjectDetailMapControl : UserControl
    {
        private Brush brVolga;
        private Brush br1br;
        private Brush br2br;
        //private Classes.Core cr;
        public SubjectDetailMapControl(/*Classes.Core Cr*/)
        {
            InitializeComponent();
            //this.cr = Cr;
            
        }

        private void Volga_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //brVolga = Volga.Fill;
            //Volga.Fill = Brushes.Yellow;
        }

        private void Volga_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //Volga.Fill = brVolga;
        }

        private void svg2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
        public void setToolTips(string str, string name, string uid)
        {
            //this.fint
        }

    }
}
