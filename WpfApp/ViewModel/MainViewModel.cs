using InfraSQLite.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _studentRepository = new StudentRepository(new InfraSQLite.AppDbContext());
            var students = _studentRepository.GetAllList();
            StudentViewModels = new ObservableCollection<StudentViewModel>();
            foreach (var student in students)
            {
                StudentViewModels.Add(new StudentViewModel()
                {
                    Id = student.Id,
                    Address = student.Address,
                    StudentName = student.StudentName,
                });
            }

        }

        private StudentRepository _studentRepository;

        public ObservableCollection<StudentViewModel> StudentViewModels { get; set; }
    }
}
