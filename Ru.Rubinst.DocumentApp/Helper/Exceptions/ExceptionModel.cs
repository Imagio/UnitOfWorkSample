using System;

namespace Ru.Rubinst.Document.Main.WPF.Helper.Exceptions
{
    internal sealed class ExceptionModel
    {
        private readonly Exception _exception;

        public ExceptionModel(Exception exception)
        {
            _exception = exception;
        }

        public Exception Exception
        {
            get { return _exception; }
        }
    }
}
