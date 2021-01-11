using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata;
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


            dataGridViewFörfattare.RowTemplate.MinimumHeight = 66;
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
            var userInput = new string[dataGridViewFörfattare.Rows.Count];

            for (int i = 0; i < dataGridViewFörfattare.Rows.Count; i++)
            {
                userInput[i] = dataGridViewFörfattare.Rows[i].Cells["Input"].Value.ToString();
            }

            DateTime.TryParse(userInput[2], out DateTime result);

            var nyFörfattare = new Författare()
            {
                Förnamn = userInput[0],
                Efternamn = userInput[1],
                Födelsedatum = result
            };

            Db.Författare.Add(nyFörfattare);
            //Db.SaveChanges();
            Close();
        }
    }
}
