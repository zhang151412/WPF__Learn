using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_Command.Common.Command
{
    internal class MyCommand : ICommand
    {
        private readonly Action<object> _execAction;
        private readonly Func<object, bool> _changeFunc;

        /// <summary>
        /// 外部传入【执行的方法(execAction)】以及 能否继续执行的【判断方法(changeFunc)】
        /// </summary>
        /// <param name="execAction"></param>
        /// <param name="changeFunc"></param>
        public MyCommand(Action<object> execAction, Func<object, bool> changeFunc)
        {
            _execAction = execAction;
            _changeFunc = changeFunc;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _changeFunc.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {

            _execAction.Invoke(parameter);
        }
    }
}
