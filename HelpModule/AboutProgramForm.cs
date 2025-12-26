using TAIS__Tourist_Agency_Info_System_.Data.Repositories;

namespace HelpModule
{
    public partial class AboutProgramForm : Form
    {
        public AboutProgramForm(InitRepos _initRepos)
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}