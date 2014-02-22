using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ru.Rubinst.DocumentCommon;
using Ru.Rubinst.DocumentModel;

namespace Ru.Rubinst.DocumentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
