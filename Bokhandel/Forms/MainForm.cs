using Bokhandel.EntityHelperClasses;
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
        private List<Butiker> butiker;
        private Butiker activeButik = null;
        private LagerSaldo lagerSaldos = null;
        private List<String> ISBNList = new List<String>();
        private int indexOfRow = 0;
        private bool isButik = false;
        private bool isFörfattare;
        private Författare activeFörfattare;
        private int amountOfRows { get; set; }
        private int rowToDelete;

        public MainForm()
        {
            InitializeComponent();
        }
        public List<string> GetISBNList { get { return ISBNList; } }
        private List<Författare> Författare { get; set; }
        private List<Förlag> Förlag { get; set; }
        private List<Kunder> Kunder { get; set; }
        private List<Order> Orders { get; set; }
        private List<string> TableNameList => new List<string>() { "Butiker", "Författare", "Förlag", "Kunder", "Ordrar" };

        #region MainForm Events
        private void MainForm_Load(object sender, EventArgs e)
        {


        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();

            if (db.Database.CanConnect())
            {
                böcker = db.Böcker.OrderBy(b => b.Titel).ToList();
                Kunder = db.Kunder.ToList();
                Orders = db.Orders.Include(od => od.Orderdetaljers).ToList();
                butiker = db.Butiker.Include(l => l.LagerSaldos).ToList();
                Författare = db.Författare.ToList();
                Förlag = db.Förlag.ToList();

                ISBNList.Clear();

                foreach (var bok in böcker)
                {
                    ISBNList.Add(bok.Isbn);
                }

                TreeViewRootPopulator(TableNameList, Författare, Kunder, Orders);
            }
            else
            {
                Debug.WriteLine("Failed to Connect");
            }
        }

        #endregion

        #region TreeView Events
        private void treeViewCustomerOrders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lagerSaldos = null;
            db.SaveChanges();
            if (e.Node.Index < 0) return;
            var lagerSaldo = db.LagerSaldo.ToList();
            böcker = db.Böcker.ToList();
            var orders = db.Orders.ToList();
            Författare = db.Författare.ToList();
            var författarePerBok = db.FörfattareBöckerFörlags;
            isButik = false;
            isFörfattare = false;

            PopulateTreeNode(e, lagerSaldo, författarePerBok, orders);
        }
        private void treeViewCustomerOrders_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (isFörfattare)
            {
                Förlag förlag = null;
                var userInputBokInfo = new string[5];

                if ((dataGridView.Rows.Count - amountOfRows) < 1) return;


                for (var j = amountOfRows; j < dataGridView.Rows.Count; j++)
                {
                    for (var x = 0; x < 5; x++)
                    {
                        if (string.IsNullOrEmpty(dataGridView.Rows[j].Cells[x].Value as string)) return;

                        userInputBokInfo[x] = dataGridView.Rows[j].Cells[x].Value.ToString();
                    }
                    förlag = dataGridView.Rows[j].Cells["Förlag"].Value as Förlag;
                    db.Böcker.Add(EntityAdder.AddNyBok(userInputBokInfo));
                    db.SaveChanges();

                    db.FörfattareBöckerFörlags.Add(EntityAdder.AddNyFörfattareBöckerFörlag(userInputBokInfo, förlag, activeFörfattare));
                    db.SaveChanges();

                }
            }
        }
        private void treeViewCustomerOrders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = treeView.GetNodeAt(e.X, e.Y);
                treeView.SelectedNode = node;

                toolStripMenuItemAddBook.Visible = false;
                toolStripMenuItemDelete.Visible = false;
                toolStripMenuItemAddFörfattare.Visible = false;
                toolStripMenuItemAddButik.Visible = false;
                toolStripMenuItemAddKund.Visible = false;
                toolStripMenuItemNyBok.Visible = false;


                // TODO: Gör en switchcase med respektive funtion ex; Add order till kunder, add book till författare
                switch (node.Tag)
                {
                    case Kunder _:
                        break;
                    case Butiker butik:
                        if (butik.LagerSaldos.Count != böcker.Count)
                        {
                            toolStripMenuItemAddBook.Visible = true;
                        }
                        break;
                    case Författare person:
                        toolStripMenuItemNyBok.Visible = true;
                        toolStripMenuItemDelete.Visible = true;
                        break;
                    case "TableNode":
                        if (node.Text == "Författare")
                        {
                            toolStripMenuItemAddFörfattare.Visible = true;
                        }
                        else if (node.Text == "Butiker")
                        {
                            toolStripMenuItemAddButik.Visible = true;
                        }
                        else if (node.Text == "Kunder")
                        {
                            toolStripMenuItemAddKund.Visible = true;
                        }
                        break;
                    default:
                        break;
                }

                contextMenuStrip.Show(treeView.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        #endregion

        #region ToolStripMenuItem Events
        private void toolStripMenuItemAddBook_Click(object sender, EventArgs e)
        {
            if (activeButik == null)
                return;

            var node = treeView.SelectedNode;
            lagerSaldos = new LagerSaldo()
            {
                ButiksId = activeButik.Id
            };


            if (node.Tag is Butiker butik)
            {
                indexOfRow = dataGridView.Rows.Add();

                dataGridView.Rows[indexOfRow].Tag = lagerSaldos;
                dataGridView.Rows[indexOfRow].Cells[1] = new DataGridViewComboBoxCell();
                var comboBoxCell = PopulateComboBoxCell(indexOfRow, butik);
                comboBoxCell.Value = comboBoxCell.Items[0];

                var bok = comboBoxCell.Value as Böcker;
                dataGridView.Rows[indexOfRow].Cells["ISBN"].Value = bok.Isbn;
                dataGridView.Rows[indexOfRow].Cells["Pris"].Value = bok.Pris.ToString("0.##");
                dataGridView.Rows[indexOfRow].Cells["Lagersaldo"].Value = 1;
            }
        }
        private void toolStripMenuItemNyBok_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            if (!(node.Tag is Författare författare)) return;
            activeFörfattare = författare;



            indexOfRow = dataGridView.Rows.Add();
            dataGridView.Rows[indexOfRow].Cells["Förlag"] = new DataGridViewComboBoxCell();
            var comboBoxCell = dataGridView.Rows[indexOfRow].Cells["Förlag"] as DataGridViewComboBoxCell;
            comboBoxCell.ValueType = typeof(Förlag);
            comboBoxCell.DisplayMember = "Namn";
            comboBoxCell.ValueMember = "This";
            foreach (var förlag in Förlag)
            {
                comboBoxCell.Items.Add(förlag.This);
            }
            comboBoxCell.Value = comboBoxCell.Items[0];
        }
        private void toolStripMenuItemAddFörfattare_Click(object sender, EventArgs e)
        {
            var form = new FormAddFörfattare(Författare, Förlag, db, this);
            form.ShowDialog();
        }
        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = null;
            bool isFörfattareSelected = false;

            foreach (TreeNode child in treeView.Nodes[1].Nodes)
            {
                if (!child.IsSelected) continue;

                isFörfattareSelected = true;
            }

            if (dataGridView.SelectedCells.Count == 0 || isFörfattareSelected)
            {
                if (treeView.SelectedNode?.Tag is Författare författare)
                {
                    TreeNode selectedNode = null;

                    if (selectedNode == null)
                    {
                        selectedNode = treeView.SelectedNode;
                    }
                    var result = MessageBox.Show($"Do you want to delete författare {författare.Förnamn} {författare.Efternamn}? " +
                        $"\nAll the corresponding books will also be deleted.", "Delete författare",
                           MessageBoxButtons.YesNo
                           );
                    if (result == DialogResult.Yes)
                    {
                        foreach (var fbf in författare.FörfattareBöckerFörlags)
                        {
                            foreach (var bok in böcker)
                            {
                                if (bok.Isbn == fbf.Isbn)
                                {
                                    db.Böcker.Remove(bok);
                                    ISBNList.Remove(bok.Isbn);
                                }
                            }
                        }
                        treeView.Nodes.Remove(selectedNode);
                        treeView.Nodes.Clear();

                        Författare.Remove(författare);
                        db.Författare.Remove(författare);
                        db.SaveChanges();
                        TreeViewRootPopulator(TableNameList, Författare, Kunder, Orders);
                    }
                }
                return;
            }

            selectedCell = dataGridView.SelectedCells[0];
            if (selectedCell.OwningRow.Tag is LagerSaldo saldo)
            {
                var result = MessageBox.Show($"Do you want to delete book {saldo.IsbnNavigation.Titel}?",
                    "Delete book",
                    MessageBoxButtons.YesNo
                    );

                if (result == DialogResult.Yes)
                {

                    saldo.Butiks.LagerSaldos.Remove(saldo);

                    dataGridView.Rows.Remove(selectedCell.OwningRow);

                    if (db.LagerSaldo.Any(ls => ls.ButiksId == saldo.ButiksId && ls.Isbn == saldo.Isbn)) //Checks the database if row exists before trying to save to avoid UpdateConcurrencyException
                    {
                        ISBNList.Remove(saldo.Isbn);
                        db.Remove(saldo);
                        db.SaveChanges();
                    }
                }
            }
            else if (selectedCell.OwningRow.Tag is Böcker b)
            {
                var result = MessageBox.Show($"Do you want to delete book {b.Titel}?", "Delete book",
                    MessageBoxButtons.YesNo
                );
                if (result == DialogResult.Yes)
                {
                    db.Böcker.Remove(b);
                    dataGridView.Rows.Remove(selectedCell.OwningRow);
                    db.SaveChanges();
                    amountOfRows--;
                }
            }
            else
            {
                dataGridView.Rows.Remove(selectedCell.OwningRow);
            }
        }

        #endregion
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedCell = dataGridView.SelectedCells[0];
            if (selectedCell.OwningRow.Tag is LagerSaldo saldo)
            {
                var result = MessageBox.Show($"Do you want to delete book {saldo.IsbnNavigation.Titel}?",
                    "Delete book",
                    MessageBoxButtons.YesNo
                    );



                if (result == DialogResult.Yes)
                {

                    saldo.Butiks.LagerSaldos.Remove(saldo);

                    dataGridView.Rows.Remove(selectedCell.OwningRow);

                    if (db.LagerSaldo.Any(ls => ls.ButiksId == saldo.ButiksId && ls.Isbn == saldo.Isbn)) //Checks the database if row exists before trying to save to avoid UpdateConcurrencyException
                    {
                        ISBNList.Remove(saldo.Isbn);
                        db.Remove(saldo);
                        db.SaveChanges();
                    }
                }

            }
            else if (selectedCell.Tag is Böcker bok)
            {
                var result = MessageBox.Show($"Do you want to delete book {bok.Titel}?", "Delete book",
                    MessageBoxButtons.YesNo
                );
                if (result == DialogResult.Yes)
                {
                    db.Böcker.Remove(bok);
                    dataGridView.Rows.Remove(selectedCell.OwningRow);
                    db.SaveChanges();
                    amountOfRows--;
                }


            }
            else
            {
                dataGridView.Rows.Remove(selectedCell.OwningRow);
            }

        }

        #region DataGrid Events

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (isButik)
            {
                AddBookToStore(e);
            }
            else if (isFörfattare)
            {
                switch (e.ColumnIndex)
                {
                    case 0: // isbn
                        if (dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value == null ||
                            dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value?.ToString().Length != 13 ||
                            !EntityAdder.ISBNConstraint.IsMatch(dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value?.ToString()))
                        {
                            MessageBox.Show("ISBN format is not correct, must be 13 numbers.", "Error");
                            dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value = null;
                        }
                        else if (!EntityAdder.IsISBNUnique(dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value?.ToString(), GetISBNList) &&
                            e.RowIndex >= amountOfRows)
                        {
                            MessageBox.Show("A book with that ISBN already exists!", "Error");
                            dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value = null;
                        }
                        break;
                    case 3: // pris
                        if (!decimal.TryParse(dataGridView.Rows[e.RowIndex].Cells["Pris"].Value?.ToString(), out decimal priceResult))
                        {
                            MessageBox.Show("Price format is not correct, can only be numbers", "Error");
                            dataGridView.Rows[e.RowIndex].Cells["Pris"].Value = "";
                        }
                        break;
                    case 4: // utgivningsdatum
                        if (!DateTime.TryParse(dataGridView.Rows[e.RowIndex].Cells["Utgivningsdatum"].Value?.ToString(), out DateTime dateTimeResult))
                        {
                            MessageBox.Show("Date format is not correct, use yy-mm-dd", "Error");
                            dataGridView.Rows[e.RowIndex].Cells["Utgivningsdatum"].Value = "";
                        }
                        break;

                    default:
                        break;
                }

                if (e.RowIndex < amountOfRows) return;
                {
                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        var currentISBN = dataGridView.Rows[i].Cells["ISBN"].Value?.ToString();
                        var nextISBN = dataGridView.Rows[i + 1].Cells["ISBN"].Value?.ToString();
                        if (currentISBN != nextISBN)
                        {
                            continue;
                        }
                        else if (string.IsNullOrEmpty(dataGridView.Rows[i].Cells["ISBN"].Value as string))
                        {
                            return;
                        }
                        else
                        {
                            MessageBox.Show("A book with that ISBN already exists!", "Error");
                            dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value = null;
                        }
                    }
                }
            }


        }
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var lagerSaldo = dataGridView.Rows[e.RowIndex].Tag as LagerSaldo;
            if (isFörfattare) return;

            if (cell is DataGridViewComboBoxCell comboBoxCell)
            {
                var bok = comboBoxCell.Value as Böcker;
                dataGridView.Rows[e.RowIndex].Cells["Pris"].Value = bok.Pris.ToString("0.##");
                dataGridView.Rows[e.RowIndex].Cells["Lagersaldo"].Value = 1;
                dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value = bok.Isbn;

                lagerSaldo.Isbn = bok.Isbn;
                lagerSaldo.IsbnNavigation = bok;
                lagerSaldo.Antal = 1;
                lagerSaldo.Butiks = activeButik;
                if (!activeButik.LagerSaldos.Contains(lagerSaldo))
                {
                    activeButik.LagerSaldos.Add(lagerSaldo);
                }
            }
        }
        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            toolStripMenuItemAddBook.Visible = false;
            toolStripMenuItemDelete.Visible = false;
            toolStripMenuItemAddFörfattare.Visible = false;
            toolStripMenuItemAddButik.Visible = false;
            toolStripMenuItemAddKund.Visible = false;
            toolStripMenuItemNyBok.Visible = false;
            toolStripMenuItemDelete.Visible = true;

            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            rowToDelete = e.RowIndex;

        }

        #endregion

        #region Methods
        private void AddBookToStore(DataGridViewCellEventArgs e)
        {
            var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var thisRow = dataGridView.Rows[e.RowIndex];
            var lagerSaldo = dataGridView.Rows[e.RowIndex].Tag as LagerSaldo;
            var rows = dataGridView.Rows;

            if (cell is DataGridViewComboBoxCell comboBoxCell)
            {
                var bok = comboBoxCell.Value as Böcker;
                dataGridView.Rows[e.RowIndex].Cells["Pris"].Value = bok?.Pris.ToString("0.##");
                dataGridView.Rows[e.RowIndex].Cells["Lagersaldo"].Value = 1;
                dataGridView.Rows[e.RowIndex].Cells["ISBN"].Value = bok?.Isbn;

                lagerSaldo.Isbn = bok.Isbn;
                lagerSaldo.IsbnNavigation = bok;
                if (!activeButik.LagerSaldos.Contains(lagerSaldo))
                {
                    activeButik.LagerSaldos.Add(lagerSaldo);
                }

                foreach (DataGridViewRow row in rows)
                {
                    if (comboBoxCell.Value == row.Cells[1].Value && comboBoxCell.RowIndex != row.Index) //Compare the value from the combobox with the rest of the rows.
                    {
                        comboBoxCell.Value = comboBoxCell.Items[0];
                    }
                }
            }

            if (e.ColumnIndex != dataGridView.Columns["Lagersaldo"]?.DisplayIndex) return;


            if (Int32.TryParse(cell.Value.ToString(), out var result))
            {
                lagerSaldo.Antal = result;
            }
        }
        private DataGridViewComboBoxCell PopulateComboBoxCell(int rowIndex, Butiker butik)
        {
            var comboBoxCell = dataGridView.Rows[rowIndex].Cells["Titel"] as DataGridViewComboBoxCell;
            comboBoxCell.ValueType = typeof(Böcker);
            comboBoxCell.DisplayMember = "Titel";
            comboBoxCell.ValueMember = "This";

            var lagerSaldoLista = butik.LagerSaldos.ToList();
            ISBNList.Clear();

            foreach (var lagerSaldo in lagerSaldoLista)
            {
                ISBNList.Add(lagerSaldo.Isbn);
            }


            foreach (var bok in böcker)
            {
                if (!ISBNList.Contains(bok.Isbn))
                {
                    comboBoxCell.Items.Add(bok.This);
                }
            }

            return comboBoxCell;
        }
        private void PopulateTreeNode(TreeViewEventArgs e, List<LagerSaldo> lagerSaldo, DbSet<FörfattareBöckerFörlag> författarePerBok, List<Order> orders)
        {
            switch (e.Node.Tag)
            {
                case Butiker butik:
                    {
                        isButik = true;
                        activeButik = butik;
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        dataGridView.Columns.Add("ISBN", "ISBN");
                        dataGridView.Columns.Add("Titel", "Titel");
                        dataGridView.Columns.Add("Lagersaldo", "Lagersaldo");
                        dataGridView.Columns.Add("Pris", "Pris");
                        foreach (var bok in böcker)
                            foreach (var saldo in lagerSaldo)
                                if (saldo.ButiksId == butik.Id)
                                    if (bok.Isbn == saldo.Isbn)
                                    {
                                        var rowIndex = dataGridView.Rows.Add(bok.Isbn, bok, saldo.Antal, bok.Pris.ToString("0.##"));
                                        dataGridView.Rows[rowIndex].Tag = saldo;
                                        dataGridView.Rows[rowIndex].Cells["ISBN"].Value = bok.Isbn;
                                        dataGridView.Rows[rowIndex].Cells["Titel"].Value = bok.Titel;
                                        dataGridView.Rows[rowIndex].Cells["Lagersaldo"].Value = saldo.Antal;
                                        dataGridView.Rows[rowIndex].Cells["Pris"].Value = bok.Pris.ToString("0.##");
                                    }

                        break;
                    }
                case Författare person:
                    {
                        isFörfattare = true;
                        activeButik = null;
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        dataGridView.Columns.Add("ISBN", "ISBN");
                        dataGridView.Columns.Add("Titel", "Titel");
                        dataGridView.Columns.Add("Språk", "Språk");
                        dataGridView.Columns.Add("Pris", "Pris");
                        dataGridView.Columns.Add("Utgivningsdatum", "Utgivningsdatum");
                        dataGridView.Columns.Add("Förlag", "Förlag");
                        foreach (var bokFörfattare in författarePerBok)
                            foreach (var bok in böcker)
                                if (person.FörfattareId == bokFörfattare.FörfattareId)
                                    if (bok.Isbn == bokFörfattare.Isbn)
                                    {
                                        var rowIndex = dataGridView.Rows.Add(bok.Isbn, bok.Titel, bok.Språk, bok.Pris.ToString("0.##"),
                                            bok.Utgivningsdatum.ToShortDateString(), bokFörfattare.Förlags.Namn);
                                        dataGridView.Rows[rowIndex].Tag = bok;
                                    }

                        amountOfRows = dataGridView.Rows.Count;

                        break;
                    }
                case Order order:
                    {
                        activeButik = null;
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
                        activeButik = null;
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
                    activeButik = null;
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
        private void TreeViewRootPopulator(List<string> tableList, List<Författare> författare, List<Kunder> kunder, List<Order> orders)
        {
            foreach (var name in tableList)
            {
                var datum = "";
                var tableNodes = new TreeNode()
                {
                    Text = name,
                    Tag = "TableNode"
                };
                treeView.Nodes.Add(tableNodes);

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
                        foreach (var förlaget in Förlag)
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

                    case "Ordrar":
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

        #endregion

    }
}