using Bokhandel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bokhandel.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            using var db = new BokhandelContext();

            if (db.Database.CanConnect())
            {
                var kunder = db.Kunder.ToList();
                var böcker = db.Böcker.ToList();
                var orders = db.Orders.Include(od => od.Orderdetaljers).ToList();
                var butiker = db.Butiker.ToList();
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
            if (e.Node.Index < 0) return;
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            using var db = new BokhandelContext();
            var lagerSaldo = db.LagerSaldo.ToList();
            var kunder = db.Kunder.ToList();
            var böcker = db.Böcker.ToList();
            var orders = db.Orders.ToList();
            var butiker = db.Butiker.ToList();
            var författare = db.Författare.ToList();
            var förlag = db.Förlag.ToList();
            var författarePerBok = db.FörfattareBöckerFörlags;
            var orderDetaljer = db.Orderdetaljer.ToList();
            var tableNames = db.Model.GetEntityTypes();

            switch (e.Node.Tag)
            {
                case Butiker butik:
                    {
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
                                        dataGridView.Rows.Add(bok.Isbn, bok.Titel, saldo.Antal, bok.Pris.ToString("0.##"));

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

                if (node.Tag is Order)
                {
                    contextMenuStrip.Show(treeViewCustomerOrders.PointToScreen(new Point(e.X, e.Y)));
                }

            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == dataGridView.Columns["Lagersaldo"].DisplayIndex)
            {
                var lagerSaldo = dataGridView.Rows[e.RowIndex].Tag as LagerSaldo;

                int result;

                if (Int32.TryParse(cell.Value.ToString(), out result))
                {
                    //lagerSaldo.Antal = result;
                }
            }
        }
    }
}