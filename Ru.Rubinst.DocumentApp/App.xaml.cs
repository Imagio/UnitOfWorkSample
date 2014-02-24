using System;
using System.Linq;
using System.Windows;
using Ru.Rubinst.Common;
using Ru.Rubinst.Document.Main.WPF.Helper.Exceptions;
using Ru.Rubinst.DocumentModel;

namespace Ru.Rubinst.Document.Main.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                var unitOfWork = new UnitOfWork<DocumentContext>(new DocumentContext());
                var accountRepository = unitOfWork.GetRepository<Account>();
                var items = accountRepository.GetItems(o => o.Id > 0, o => o.OrderBy(a => a.UserName));
            }
            catch (Exception exception)
            {
                ExceptionHelper.Instance.ShowException(exception);
            }
        }
    }
}
