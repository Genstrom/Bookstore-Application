using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bokhandel.Forms
{
    public partial class FormAddFörfattare : Form
    {

        public FormAddFörfattare(List<Författare> författarList)
        {
            InitializeComponent();
            Författare = författarList;
        }

        public List<Författare> Författare { get; set; }

        private void FormAddFörfattare_Load(object sender, EventArgs e)
        {

        }
    }
}
