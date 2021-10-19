using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel
{
    public class StudentViewModel : ViewModelBase
    {

        public int Id { get; set; }

        //学生名称
        public string StudentName { get; set; }

        //学生性别
        public string? Gender { get; set; }

        //学生出生年月
        public DateTime Birthday { get; set; }

        //学生地址
        public string? Address { get; set; }

        //家长电话
        public string? PatriarchTel { get; set; }

        public override string ToString()
        {
            return StudentName;
        }
    }
}
