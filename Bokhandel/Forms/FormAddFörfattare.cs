using Bokhandel.EntityHelperClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Bokhandel.Forms
{
    public partial class FormAddFörfattare : Form
    {

        public FormAddFörfattare(List<Författare> författarList, List<Förlag> förlagsList, BokhandelContext context)
        {
            InitializeComponent();
            FörfattareList = författarList;
            FörlagsList = förlagsList;
            Db = context;
        }

        public List<Författare> FörfattareList { get; set; }

        public List<Förlag> FörlagsList { get; set; }
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


            //dataGridViewFörfattare.RowTemplate.MinimumHeight = 66;
            dataGridViewBok.RowTemplate.MinimumHeight = 40;

            IProperty förnamn = null;
            IProperty efternamn = null;
            IProperty födelsedatum = null;

            foreach (var property in entityFörfattare.GetProperties()) //Fulfix för att få kolumnerna i rätt ordning
            {
                if (property.GetColumnName() == "Förnamn")
                {
                    förnamn = property;
                }
                else if (property.GetColumnName() == "Efternamn")
                {
                    efternamn = property;
                }
                else if (property.GetColumnName() == "Födelsedatum")
                {
                    födelsedatum = property;
                }
            }

            dataGridViewFörfattare.Rows.Add(förnamn.Name);
            dataGridViewFörfattare.Rows.Add(efternamn.Name);
            dataGridViewFörfattare.Rows.Add(födelsedatum.Name);
            var indexOfRow = dataGridViewFörfattare.Rows.Add("Förlag");

            dataGridViewFörfattare.Rows[indexOfRow].Cells["Input"] = new DataGridViewComboBoxCell();
            var comboBoxCell = PopulateFörfattareComboBoxCell(indexOfRow);


            foreach (var property in entityBöcker.GetProperties())
            {
                dataGridViewBok.Rows.Add(property.GetColumnName());
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var userInputFörfattareInfo = new string[dataGridViewFörfattare.Rows.Count];
            var userInputBokInfo = new string[dataGridViewBok.Rows.Count];

            for (int i = 1; i < dataGridViewFörfattare.Rows.Count; i++)
            {
                userInputFörfattareInfo[i - 1] = dataGridViewFörfattare.Rows[i - 1].Cells["Input"].Value.ToString();
            }

            for (int i = 0; i < dataGridViewBok.Rows.Count; i++)
            {
                userInputBokInfo[i] = dataGridViewBok.Rows[i].Cells["Input"].Value.ToString(); //Money blir decimal samt 
            }


            var inputFörlag = dataGridViewFörfattare.Rows[3].Cells["Input"].Value as Förlag;

            var nyFörfattare = EntityAdder.AddNyFörfattare(userInputFörfattareInfo);

            Db.Författare.Add(nyFörfattare);
            Db.Böcker.Add(EntityAdder.AddNyBok(userInputBokInfo));
            Db.SaveChanges();

            Db.FörfattareBöckerFörlags.Add(EntityAdder.AddNyFörfattareBöckerFörlag(userInputBokInfo, inputFörlag, nyFörfattare));
            Db.SaveChanges();

            Close();
        }

        
        private DataGridViewComboBoxCell PopulateFörfattareComboBoxCell(int rowIndex)
        {
            var comboBoxCell = dataGridViewFörfattare.Rows[rowIndex].Cells["Input"] as DataGridViewComboBoxCell;
            comboBoxCell.ValueType = typeof(Förlag);
            comboBoxCell.DisplayMember = "Namn";
            comboBoxCell.ValueMember = "This";

            foreach (var förlag in FörlagsList)
            {
                comboBoxCell.Items.Add(förlag.This);
            }

            return comboBoxCell;
        }
    }
}
