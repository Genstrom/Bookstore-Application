using Bokhandel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bokhandel.Forms
{
    public partial class MainForm : Form
    {
        private BokhandelContext db = new BokhandelContext();
        private List<Böcker> böcker;
        private Butiker activeButik = null;
        private LagerSaldo LagerSaldos = null;
        private int indexOfRow = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (db.Database.CanConnect())
            {
                böcker = db.Böcker.OrderBy(b => b.Titel).ToList();
                var lagerSaldo = db.LagerSaldo.ToList();
                var kunder = db.Kunder.ToList();
                var orders = db.Orders.Include(od => od.Orderdetaljers).ToList();
                var butiker = db.Butiker.Include(l => l.LagerSaldos).ToList();
                var författare = db.Författare.ToList();
                var förlag = db.Förlag.ToList();
                var tableNames = db.Model.GetEntityTypes();
                var tableList = tableNames.ToList();
                tableList.Remove(tableList[1]);
                tableList.Remove(tableList[2]);
                tableList.Remove(tableList[4]);
                tableList.Remove(tableList[5]);
                tableList.Remove(tableList[5]);
                tableList.Remove(tableList[5]);


                foreach (var table in tableList)
                {
                    var datum = "";
                    var tableNodes = new TreeNode(table.DisplayName());
                    treeViewCustomerOrders.Nodes.Add(tableNodes);

                    switch (tableNodes.Text)
                    {
                        case "Butiker":
                            foreach (var butik in butiker)
                            {
                                var butikNode = new TreeNode
                                {
                                    Text = $"{butik.Namn}, {butik.Adress}",
                                    Tag = butik
                                };
                                tableNodes.Nodes.Add(butikNode);
                            }

                            break;

                        case "Författare":
                            foreach (var person in författare)
                            {
                                var författarNode = new TreeNode
                                {
                                    Text = $"{person.Förnamn}, {person.Efternamn}",
                                    Tag = person
                                };
                                tableNodes.Nodes.Add(författarNode);
                            }

                            break;

                        case "Förlag":
                            foreach (var förlaget in förlag)
                            {
                                var förlagsNode = new TreeNode
                                {
                                    Text = $"{förlaget.Namn}",
                                    Tag = förlaget
                                };
                                tableNodes.Nodes.Add(förlagsNode);
                            }

                            break;

                        case "Kunder":
                            foreach (var kund in kunder)
                            {
                                var customerNode = new TreeNode
                                {
                                    Text = $"{kund.Förnamn} {kund.Efternamn}",
                                    Tag = kund
                                };

                                foreach (var ordrar in kund.Orders)
                                {
                                    if (ordrar.Orderdatum.ToString() == datum) continue;
                                    datum = ordrar.Orderdatum.ToString();
                                    var orderNode = new TreeNode
                                    {
                                        Text = ordrar.Orderdatum.ToString(),
                                        Tag = ordrar
                                    };
                                    customerNode.Nodes.Add(orderNode);
                                }

                                tableNodes.Nodes.Add(customerNode);
                            }

                            break;

                        case "Order":
                            foreach (var order in orders)
                            {
                                var orderNode = new TreeNode
                                {
                                    Text = $"{order.OrderId}",
                                    Tag = order
                                };
                                tableNodes.Nodes.Add(orderNode);
                            }

                            break;
                    }
                }
            }
            else
            {
                Debug.WriteLine("Failed to Connect");
            }
        }

        private void treeViewCustomerOrders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (LagerSaldos != null)
            {
                LagerSaldos.Isbn = dataGridView.Rows[indexOfRow].Cells["ISBN"].Value.ToString();
                activeButik.LagerSaldos.Add(LagerSaldos);
            }
            
            db.SaveChanges();
            if (e.Node.Index < 0) return;
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            var lagerSaldo = db.LagerSaldo.ToList();
            var kunder = db.Kunder.ToList();
            var böcker = db.Böcker.ToList();
            var orders = db.Orders.ToList();
            var butiker = db.Butiker.Include( b => b.LagerSaldos).ToList();
            var författare = db.Författare.ToList();
            var förlag = db.Förlag.ToList();
            var författarePerBok = db.FörfattareBöckerFörlags;
            var orderDetaljer = db.Orderdetaljer.ToList();

            switch (e.Node.Tag)
            {
                case Butiker butik:
                    {
                        activeButik = butik;
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        dataGridView.Columns.Add("ISBN", "ISBN");
                        var titelColumn = new DataGridViewComboBoxColumn
                        {
                            Name = "Titel",
                            HeaderText = "Titel",
                        };
                        dataGridView.Columns.Add(titelColumn);
                        dataGridView.Columns.Add("Lagersaldo", "Lagersaldo");
                        dataGridView.Columns.Add("Pris", "Pris");
                        foreach (var bok in böcker)
                            foreach (var saldo in lagerSaldo)
                                if (saldo.ButiksId == butik.Id)
                                    if (bok.Isbn == saldo.Isbn)
                                    {
                                        int rowIndex = dataGridView.Rows.Add(bok.Isbn, bok, saldo.Antal, bok.Pris.ToString("0.##"));
                                        dataGridView.Rows[rowIndex].Tag = saldo;
                                        var comboBoxCell = PopulaComboBoxCell(rowIndex);
                                        dataGridView.Rows[rowIndex].Cells["ISBN"].Value = bok.Isbn;
                                        dataGridView.Rows[rowIndex].Cells["Titel"].Value = bok;
                                        dataGridView.Rows[rowIndex].Cells["Lagersaldo"].Value = saldo.Antal;
                                        dataGridView.Rows[rowIndex].Cells["Pris"].Value = bok.Pris.ToString("0.##");

                                    }

                        break;
                    }
                case Författare person:
                    {
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        dataGridView.Columns.Add("ISBN", "ISBN");
                        dataGridView.Columns.Add("Titel", "Titel");
                        dataGridView.Columns.Add("Språk", "Språk");
                        dataGridView.Columns.Add("Utgivningsdatum", "Utgivningsdatum");
                        foreach (var bokFörfattare in författarePerBok)
                            foreach (var bok in böcker)
                                if (person.FörfattareId == bokFörfattare.FörfattareId)
                                    if (bok.Isbn == bokFörfattare.Isbn)
                                        dataGridView.Rows.Add(bok.Isbn, bok.Titel, bok.Språk, bok.Utgivningsdatum);

                        break;
                    }
                case Order order:
                    {
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        dataGridView.Columns.Add("KundID", "KundID");
                        dataGridView.Columns.Add("ISBN", "ISBN");
                        dataGridView.Columns.Add("Titel", "Titel");
                        dataGridView.Columns.Add("Pris", "Pris");
                        dataGridView.Columns.Add("Antal", "Antal");

                        foreach (var ordrar in orders)
                            foreach (var detalj in ordrar.Orderdetaljers)
                                foreach (var bok in böcker)
                                    if (detalj.Isbn == bok.Isbn)
                                        if (order.OrderId == detalj.OrderId)
                                            dataGridView.Rows.Add(ordrar.KundId, detalj.Isbn, bok.Titel, detalj.Pris, detalj.Antal);

                        break;
                    }
                case Förlag förlags:
                    {
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        dataGridView.Columns.Add("FörlagsID", "FörlagsID");
                        dataGridView.Columns.Add("Kontaktperson", "Kontaktperson");
                        dataGridView.Columns.Add("Telefonnummer", "Telefonnummer");
                        dataGridView.Columns.Add("Titlar", "Titlar");
                        foreach (var bokFörfattare in författarePerBok)
                            foreach (var bok in böcker)
                                if (bokFörfattare.FörlagsId == förlags.FörlagsId)
                                    if (bokFörfattare.Isbn == bok.Isbn)
                                        dataGridView.Rows.Add(förlags.FörlagsId, förlags.Kontaktperson, förlags.Telefonnummer,
                                            bok.Titel);

                        break;
                    }
                case Kunder kund:
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                    dataGridView.Columns.Add("Id", "Id");
                    dataGridView.Columns.Add("Namn", "Namn");
                    dataGridView.Columns.Add("Adress", "Adress");
                    dataGridView.Columns.Add("Email", "Email");
                    dataGridView.Columns.Add("Telefonnummer", "Telefonnummer");
                    dataGridView.Rows.Add(kund.Id, kund.Förnamn + " " + kund.Efternamn, kund.Adress, kund.Epostadress,
                        kund.Telefonnummer);
                    break;
            }
        }

        private void treeViewCustomerOrders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = treeViewCustomerOrders.GetNodeAt(e.X, e.Y);
                treeViewCustomerOrders.SelectedNode = node;

                // TODO: Gör en switchcase med respektive funtion ex; Add order till kunder, add book till författare
                if (node.Tag == null || node.Tag is Kunder)
                {
                    toolStripMenuItemDelete.Visible = false;
                }
                else
                {
                    toolStripMenuItemDelete.Visible = true;
                }
                contextMenuStrip.Show(treeViewCustomerOrders.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //Jag har inte testat koden. Jag tycker inte du ska testa koden innan du lägger till för att skapa nya rows
            // så slipper du ändra i databasen. Eller om du har breeakpoint på save som jag har ju så du inte går förbi det.
            if (cell is DataGridViewComboBoxCell comboBoxCell)
            {
                var bok = comboBoxCell.Value as Böcker;
                dataGridView.Rows[e.RowIndex].Cells["Pris"].Value = bok.Pris.ToString("0.##");
                dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value = bok.Isbn;
                dataGridView.Rows[e.RowIndex].Cells["Lagersaldo"].Value = 1;
            }


            if (e.ColumnIndex == dataGridView.Columns["Lagersaldo"].DisplayIndex)
            {
                var lagerSaldo = dataGridView.Rows[e.RowIndex].Tag as LagerSaldo;

                if (Int32.TryParse(cell.Value.ToString(), out int result))
                {
                    lagerSaldo.Antal = result;
                   
                }
            }
            
        }

        private void toolStripMenuItemAddRow_Click(object sender, EventArgs e)
        {
            if (activeButik == null)
                return;

            var node = treeViewCustomerOrders.SelectedNode;
             LagerSaldos= new LagerSaldo()
            {
                ButiksId = activeButik.Id
                
            };
            

            if (node.Tag is Butiker butik)
            {
                 indexOfRow = dataGridView.Rows.Add();
                dataGridView.Rows[indexOfRow].Tag = LagerSaldos;

                var comboBoxCell = PopulaComboBoxCell(indexOfRow);
                comboBoxCell.ValueMember = "This";
                foreach (var bok in böcker)
                {
                    comboBoxCell.Items.Add(bok.This);
                }
                comboBoxCell.Value = böcker[0];

            }
            
            
            
        }

        private DataGridViewComboBoxCell PopulaComboBoxCell(int rowIndex)
        {
            var comboBoxCell = dataGridView.Rows[rowIndex].Cells["Titel"] as DataGridViewComboBoxCell;
            comboBoxCell.ValueType = typeof(Bokhandel.Böcker);
            comboBoxCell.DisplayMember = "Titel";
            comboBoxCell.ValueMember = "This";
            foreach (var bok in böcker)
            {
                comboBoxCell.Items.Add(bok.This);
            }

            return comboBoxCell;
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (treeViewCustomerOrders.SelectedNode.Tag is Böcker)
            {

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection selectedCellItems = null;
            
           
            
            if (dataGridView.SelectedCells != null)
            {
                selectedCellItems = dataGridView.SelectedCells;
              

            }
            foreach (DataGridViewCell cell in selectedCellItems)
            {
                var selectedRow = dataGridView.Rows[cell.RowIndex];
                if (dataGridView.Rows[cell.RowIndex].Tag is LagerSaldo saldo)
                {
                    var result = MessageBox.Show($"Do you want to delete book {saldo.IsbnNavigation.Titel}?", "Delete book", 
                        MessageBoxButtons.YesNo
                        );



                    if (result == DialogResult.Yes)
                    {
                        db.Remove(saldo);
                        
                     dataGridView.Rows.Remove(selectedRow);
                    }

                }
                
            }
        }

    }
}