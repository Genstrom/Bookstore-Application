using Bokhandel.EntityHelperClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
namespace Bokhandel.Forms
{
    public partial class FormAddFörfattare : Form
    {
        private string[] bokRowNames = new string[] { "ISBN", "Titel", "Språk", "Pris", "Utgivningsdatum" };
        private string[] författareRowNames = new string[] { "Förnamn", "Efternamn", "Födelsedatum" };
        private List<string> författareFörnamn = new List<string>();
        private List<string> författareEfternamn = new List<string>();
        public FormAddFörfattare(List<Författare> författarList, List<Förlag> förlagsList, BokhandelContext context, MainForm mainForm)
        {
            InitializeComponent();
            FörfattareList = författarList;
            FörlagsList = förlagsList;
            Db = context;
            MainForm = mainForm;

            foreach (var författare in FörfattareList)
            {
                författareFörnamn.Add(författare.Förnamn.ToLower());
                författareEfternamn.Add(författare.Efternamn.ToLower());
            }
        }
        private List<Författare> FörfattareList { get; set; }
        private List<Förlag> FörlagsList { get; set; }
        private BokhandelContext Db { get; set; }
        private MainForm MainForm { get; set; }
        private void FormAddFörfattare_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;

            dataGridViewBok.Rows.Clear();
            dataGridViewFörfattare.Rows.Clear();

            dataGridViewFörfattare.Columns.Add("Info", "Författare");
            dataGridViewFörfattare.Columns.Add("Input", "");

            dataGridViewBok.Columns.Add("Info", "Bok");
            dataGridViewBok.Columns.Add("Input", "");

            //dataGridViewFörfattare.RowTemplate.MinimumHeight = 40;
            dataGridViewBok.RowTemplate.MinimumHeight = 40;

            foreach (var name in författareRowNames)
            {

                dataGridViewFörfattare.Rows.Add(name);
            }

            var indexOfRow = dataGridViewFörfattare.Rows.Add("Förlag");

            dataGridViewFörfattare.Rows[indexOfRow].Cells["Input"] = new DataGridViewComboBoxCell();
            var comboBoxCell = PopulateFörfattareComboBoxCell(indexOfRow);
            comboBoxCell.Value = comboBoxCell.Items[0];


            foreach (var name in bokRowNames)
            {
                dataGridViewBok.Rows.Add(name);
            }

        }

        #region Button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var userInputFörfattareInfo = new string[dataGridViewFörfattare.Rows.Count];
            var userInputBokInfo = new string[dataGridViewBok.Rows.Count];

            for (var i = 1; i < dataGridViewFörfattare.Rows.Count; i++)
            {
                userInputFörfattareInfo[i - 1] = dataGridViewFörfattare.Rows[i - 1].Cells["Input"].Value.ToString();
            }

            for (var i = 0; i < dataGridViewBok.Rows.Count; i++)
            {
                userInputBokInfo[i] = dataGridViewBok.Rows[i].Cells["Input"].Value.ToString();
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

        #endregion

        #region DataGrid

        private void dataGridViewFörfattare_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            buttonSave.Enabled = false;

            switch (e.RowIndex)
            {
                case 0:
                    if (författareFörnamn.Contains(dataGridViewFörfattare.Rows[0].Cells["Input"].Value?.ToString().ToLower().Trim()) &&
                        författareEfternamn.Contains(dataGridViewFörfattare.Rows[1].Cells["Input"].Value?.ToString().ToLower().Trim()))
                    {
                        MessageBox.Show("Författare already exists.", "Error");
                        dataGridViewFörfattare.Rows[0].Cells["Input"].Value = "";
                        dataGridViewFörfattare.Rows[1].Cells["Input"].Value = "";
                    }
                    break;
                case 1:
                    if (författareFörnamn.Contains(dataGridViewFörfattare.Rows[0].Cells["Input"].Value?.ToString().ToLower().Trim()) &&
                        författareEfternamn.Contains(dataGridViewFörfattare.Rows[1].Cells["Input"].Value?.ToString().ToLower().Trim()))
                    {
                        MessageBox.Show("Författare already exists.", "Error");
                        dataGridViewFörfattare.Rows[0].Cells["Input"].Value = "";
                        dataGridViewFörfattare.Rows[1].Cells["Input"].Value = "";
                    }
                    break;
                case 2:
                    if (!DateTime.TryParse(dataGridViewFörfattare.Rows[2].Cells["Input"].Value?.ToString(), out DateTime dateTimeResult))
                    {
                        MessageBox.Show("Date format is not correct, use yy-mm-dd.", "Error");
                        dataGridViewFörfattare.Rows[2].Cells["Input"].Value = "";
                    }
                    break;
                default:
                    break;
            }

            if (e.RowIndex == 2)
            {
            }

            EnableSaveButton();
        }
        private void dataGridViewBok_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            buttonSave.Enabled = false;

            switch (e.RowIndex)
            {
                case 0: // isbn
                    if (dataGridViewBok.Rows[0].Cells["Input"].Value == null ||
                        dataGridViewBok.Rows[0].Cells["Input"].Value?.ToString().Length != 13 ||
                        !EntityAdder.ISBNConstraint.IsMatch(dataGridViewBok.Rows[0].Cells["Input"].Value?.ToString()))
                    {
                        MessageBox.Show("ISBN format is not correct, must be 13 numbers.", "Error");
                        dataGridViewBok.Rows[0].Cells["Input"].Value = null;
                    }
                    else if (!EntityAdder.IsISBNUnique(dataGridViewBok.Rows[0].Cells["Input"].Value?.ToString(), MainForm.GetISBNList))
                    {
                        MessageBox.Show("A book with that ISBN already exists!", "Error");
                        dataGridViewBok.Rows[0].Cells["Input"].Value = null;
                    }
                    break;
                case 3: // pris
                    if (!decimal.TryParse(dataGridViewBok.Rows[3].Cells["Input"].Value?.ToString(), out decimal priceResult))
                    {
                        MessageBox.Show("Price format is not correct, can only be numbers", "Error");
                        dataGridViewBok.Rows[3].Cells["Input"].Value = "";
                    }
                    break;
                case 4: // utgivningsdatum
                    if (!DateTime.TryParse(dataGridViewBok.Rows[4].Cells["Input"].Value?.ToString(), out DateTime dateTimeResult))
                    {
                        MessageBox.Show("Date format is not correct, use yy-mm-dd", "Error");
                        dataGridViewBok.Rows[4].Cells["Input"].Value = "";
                    }
                    break;

                default:
                    break;
            }

            if (!DateTime.TryParse(dataGridViewBok.Rows[4].Cells["Input"].Value?.ToString(), out DateTime dateTimeResult2)) return; //if last cell isn't populated, R E T U R N

            EnableSaveButton();
        }

        #endregion

        #region Methods

        private void EnableSaveButton()
        {
            for (int i = 0; i < dataGridViewBok.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dataGridViewBok.Rows[i].Cells["Input"].Value as string))
                {
                    return;
                }
                else
                {
                    continue;
                }
            }

            for (int i = 0; i < dataGridViewFörfattare.Rows.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(dataGridViewFörfattare.Rows[i].Cells["Input"].Value as string))
                {
                    return;
                }
                else
                {
                    continue;
                }
            }
            buttonSave.Enabled = true;
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

        #endregion
    }
}
