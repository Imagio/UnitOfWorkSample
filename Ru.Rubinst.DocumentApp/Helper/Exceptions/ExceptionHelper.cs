using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ru.Rubinst.DesignPatterns;

namespace Ru.Rubinst.Document.Main.WPF.Helper.Exceptions
{
    internal sealed class ExceptionHelper : Singleton<ExceptionHelper>
    {
        private ExceptionHelper() { }

        public bool? ShowException(Exception exception)
        {
            var model = new ExceptionModel(exception);
            var exceptionWindow = new ExceptionWindow
            {
                DataContext = model
            };
            return exceptionWindow.ShowDialog();
        }
    }
}
