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
using System.Windows.Shapes;
using Wpf_Command.ViewModel;

namespace Wpf_Command.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            //DataContext属性要设置为ViewModel实例，这样View才能跟ViewModel关联上，
            //从而使用Binding才能绑定上MyCommand命令。
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
