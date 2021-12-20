using System;
using System.Windows.Forms;
using XAI_BIBLE.AdminForms;

namespace XAI_BIBLE
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BookAuthor());
        }
    }
}
