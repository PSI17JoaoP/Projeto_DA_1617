using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class formMenuArbitro : Form
    {
        public formMenuArbitro()
        {
            InitializeComponent();
        }

        private void formMenuArbitro_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin Login = new formLogin();
            Login.Show();
        }
    }
}
