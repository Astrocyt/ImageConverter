using System;
using ImageConverter.Presenter.PresenterInterface;
using ImageConverter.Presenter.PresenterClass;
using ImageConverter.View.ViewInterface;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageConverter.Model;

namespace ImageConverter
{
    static class ProgramStart
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainView view = new MainView();
            IMainViewPresenter presenter = new MainViewPresenter(view);
            view.AttachPresenter(presenter);

            Application.Run((view as Form));
        }  
    }
}
