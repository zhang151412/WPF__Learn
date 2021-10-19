using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DItest
{
    class TextService : ITextService
    {
        private string _text;

        public TextService(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }
}
