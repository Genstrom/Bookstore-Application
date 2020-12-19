using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Bokhandel.Models;

namespace Bokhandel.Forms
{
    public partial class FormAddFörfattare : Form
    {

        public FormAddFörfattare(List<Författare> författarList, BokhandelContext context)
        {
            InitializeComponent();
            FörfattareList = författarList;
            Db = context;
        }

        public List<Författare> FörfattareList { get; set; }
        private BokhandelContext Db { get; set; }

        [Obsolete]
        private void FormAddFörfattare_Load(object sender, EventArgs e)
        {
            dataGridViewBok.Rows.Clear();
            dataGridViewFörfattare.Rows.Clear();

            dataGridViewFörfattare.Columns.Add("Info", "Författare");
            dataGridViewFörfattare.Columns.Add("Input", "");

            dataGridViewBok.Columns.Add("Info", "Bok");
            dataGridViewBok.Columns.Add("Input", "");

            var entityFörfattare = Db.Model.FindEntityType(typeof(Författare));
            var entityBöcker = Db.Model.FindEntityType(typeof(Böcker));


            foreach (var property in entityFörfattare.GetProperties())
            {
                dataGridViewFörfattare.Rows.Add(property.GetColumnName());
            }

            foreach (var property in entityBöcker.GetProperties())
            {
                dataGridViewBok.Rows.Add(property.GetColumnName());
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
