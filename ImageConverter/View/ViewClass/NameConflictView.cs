using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageConverter.View.ViewInterface;
using ImageConverter.Presenter.PresenterInterface;

namespace ImageConverter.View.ViewClass
{
    public partial class NameConflictsView : Form, INameConflictsView
    {
        private INameConflictsViewPresenter _presenter;

        public NameConflictsView()
        {
            InitializeComponent();
        }

        public void AttachPresenter(INameConflictsViewPresenter conflictViewPresenter)
        {
            this._presenter = conflictViewPresenter;
        }

        public void SetConflictsPaths(string[] paths)
        {
            this.conflictsNameListView.Items.Clear();
            this.conflictsNameListView.Items.AddRange(CreateItems(paths));
        }

        void INameConflictsView.Show()
        {
            this.ShowDialog();
        }

        void INameConflictsView.Close()
        {
            this.Close();
        }

        private ListViewItem[] CreateItems(string[] paths)
        {
            ListViewItem[] items = new ListViewItem[paths.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ListViewItem(paths[i]);
            }
            return items;
        }

        private void RenamePaths(object sender, EventArgs e)
        {
            _presenter.RenameFiles();
        }

        private void ReplacePaths(object sender, EventArgs e)
        {
            _presenter.ReplaceFiles();
        }

        private void IgnorePaths(object sender, EventArgs e)
        {
            _presenter.IgnoreFiles();
        }

        
    }
}
