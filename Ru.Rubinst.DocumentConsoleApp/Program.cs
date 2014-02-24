using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ru.Rubinst.Common;
using Ru.Rubinst.DocumentModel;

namespace Ru.Rubinst.DocumentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var unitOfWork = new UnitOfWork<DocumentContext>(new DocumentContext());
                var accountRepository = unitOfWork.GetRepository<Account>();
                var items = accountRepository.GetItems(o => o.Id > 0, o => o.OrderBy(a => a.UserName));
                foreach (var account in items)
                {
                    Console.WriteLine(account.UserName);
                }
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.Write(ExceptionMessage(exception));
                Console.ReadKey();
            }
        }

        private static string ExceptionMessage(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            var level = 0;
            if (!String.IsNullOrEmpty(exception.Message))
                stringBuilder.AppendLine(exception.Message);
            var exc = exception;
            while (exc.InnerException != null)
            {
                exc = exc.InnerException;
                level++;
                if (String.IsNullOrEmpty(exc.Message)) continue;
                var tabs = Enumerable.Repeat('\t', level);
                stringBuilder.AppendLine(String.Join("", tabs) + exc.Message);
            }

            return stringBuilder.ToString();
        }
    }
}
