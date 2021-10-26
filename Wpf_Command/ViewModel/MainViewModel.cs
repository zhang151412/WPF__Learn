using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_Command.Common.Command;
using WpfApp.ViewModel;

namespace Wpf_Command.ViewModel
{
    public class MainViewModel: ViewModelBase
    {

        bool isCanExec = true;

        /// <summary>
        /// 命令属性，供xaml的来绑定的
        /// </summary>
        public ICommand MyCommand => new MyCommand(MyAction, MyCanExec);
        
        private void MyAction(object parameter)
        {
            /*            Debug.WriteLine("命令被执行了");
                        isCanExec = false;*/

            if (bool.Parse(parameter.ToString()))
            {
                Debug.WriteLine("Hello Command!");
            }
            else
            {
                Debug.WriteLine("你好，命令！");
            }

        }
        private bool MyCanExec(object parameter)
        {
            return isCanExec;
        }
    }
}
