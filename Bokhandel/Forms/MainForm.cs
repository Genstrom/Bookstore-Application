using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                var kunder = db.Kunder
                    .Include(k => k.Ordrars)
                        .ThenInclude(o => o.OrderDetaljers)
                    .ToList();

                foreach (var kund in kunder)
                {
                    var customerNode = new TreeNode($"{kund.Förnamn} {kund.Efternamn}");

                    foreach (var ordrar in kund.Ordrars)
                    {
                        var orderNode = new TreeNode()
                        {
                            Text = ordrar.OrderDetaljers.
                        }
                    }

                    treeViewCustomerOrders.Nodes.Add(customerNode);
                }
            }
            else
            {
                Debug.WriteLine("Cannot connect!");
            }
        }
    }
}
