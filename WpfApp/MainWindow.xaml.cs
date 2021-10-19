using Domain.Model;
using Domain.Repository;
using InfraSQLite.Repository;
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
using WpfApp.DItest;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ITextService textService, IRepository<Student, int> studentRepository)
        {
            //_studentRepository = new StudentRepository(new InfraSQLite.AppDbContext());
            _studentRepository = studentRepository;
            _mainViewModel = new MainViewModel();

            DataContext = _mainViewModel;

            /*            listBox1= new ListBox();
                        this.listBox1.SetBinding(ListBox.ItemBindingGroupProperty,new Binding("StudentName"));
            */
            InitializeComponent();
            Label.Content = textService.GetText();
        }

        private readonly MainViewModel _mainViewModel;

        //private readonly StudentRepository _studentRepository;
        private readonly IRepository<Student, int> _studentRepository;
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            var student = _studentRepository.GetAll().OrderByDescending(s => s.Id).FirstOrDefault();
            int? stuId = student?.Id;
            var stu = new Student()
            {
                StudentName = $"ZhangSan_{stuId + 1}",

            };
            _ = _studentRepository.Insert(stu);

            //DataContext = new MainViewModel();
            _mainViewModel.StudentViewModels.Add(new StudentViewModel()
            {
                Id = stu.Id,
                StudentName = stu.StudentName
            });
        }

        //Button click events are one of the few method signatures where async void is acceptable. 
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = listBox1.SelectedItem as StudentViewModel;
            if (item is null) { return ; }
            Student stu = _studentRepository.FirstOrDefault(s => s.Id == item.Id);

            if (stu != null)
            {
               var del= await _studentRepository.DeleteAsync(stu);
                if (del)
                {
                    _mainViewModel.StudentViewModels.Remove(item);
                }
            }
        }

    }
}
