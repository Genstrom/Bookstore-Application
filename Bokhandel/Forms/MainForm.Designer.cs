﻿
namespace Bokhandel.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewCustomerOrders = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddBook = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddFörfattare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNyBok = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddButik = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddKund = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewCustomerOrders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1570, 1045);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewCustomerOrders
            // 
            this.treeViewCustomerOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCustomerOrders.Location = new System.Drawing.Point(0, 0);
            this.treeViewCustomerOrders.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.treeViewCustomerOrders.Name = "treeViewCustomerOrders";
            this.treeViewCustomerOrders.Size = new System.Drawing.Size(520, 1045);
            this.treeViewCustomerOrders.TabIndex = 0;
            this.treeViewCustomerOrders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCustomerOrders_AfterSelect);
            this.treeViewCustomerOrders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewCustomerOrders_MouseClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonDelete);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1044, 1045);
            this.splitContainer2.SplitterDistance = 405;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(890, 333);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(107, 38);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(1044, 635);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddBook,
            this.toolStripMenuItemAddFörfattare,
            this.toolStripMenuItemNyBok,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemAddButik,
            this.toolStripMenuItemAddKund});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(201, 196);
            // 
            // toolStripMenuItemAddBook
            // 
            this.toolStripMenuItemAddBook.Name = "toolStripMenuItemAddBook";
            this.toolStripMenuItemAddBook.Size = new System.Drawing.Size(200, 32);
            this.toolStripMenuItemAddBook.Text = "Add Book";
            this.toolStripMenuItemAddBook.Click += new System.EventHandler(this.toolStripMenuItemAddBook_Click);
            // 
            // toolStripMenuItemAddFörfattare
            // 
            this.toolStripMenuItemAddFörfattare.Name = "toolStripMenuItemAddFörfattare";
            this.toolStripMenuItemAddFörfattare.Size = new System.Drawing.Size(200, 32);
            this.toolStripMenuItemAddFörfattare.Text = "Add Författare";
            this.toolStripMenuItemAddFörfattare.Visible = false;
            this.toolStripMenuItemAddFörfattare.Click += new System.EventHandler(this.toolStripMenuItemAddFörfattare_Click);
            // 
            // toolStripMenuItemNyBok
            // 
            this.toolStripMenuItemNyBok.Name = "toolStripMenuItemNyBok";
            this.toolStripMenuItemNyBok.Size = new System.Drawing.Size(200, 32);
            this.toolStripMenuItemNyBok.Text = "Ny Bok";
            this.toolStripMenuItemNyBok.Click += new System.EventHandler(this.toolStripMenuItemNyBok_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(200, 32);
            this.toolStripMenuItemDelete.Text = "Delete";
            this.toolStripMenuItemDelete.Visible = false;
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripMenuItemAddButik
            // 
            this.toolStripMenuItemAddButik.Name = "toolStripMenuItemAddButik";
            this.toolStripMenuItemAddButik.Size = new System.Drawing.Size(200, 32);
            this.toolStripMenuItemAddButik.Text = "Add Butik";
            // 
            // toolStripMenuItemAddKund
            // 
            this.toolStripMenuItemAddKund.Name = "toolStripMenuItemAddKund";
            this.toolStripMenuItemAddKund.Size = new System.Drawing.Size(200, 32);
            this.toolStripMenuItemAddKund.Text = "Add Kund";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 1045);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridView;

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewCustomerOrders;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddBook;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddFörfattare;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddButik;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddKund;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNyBok;
    }
}