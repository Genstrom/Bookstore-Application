
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddBook = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddFörfattare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNyBok = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteBok = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteFörfattare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddButik = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddKund = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1099, 627);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(364, 627);
            this.treeView.TabIndex = 0;
            this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewCustomerOrders_BeforeSelect);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCustomerOrders_AfterSelect);
            this.treeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewCustomerOrders_MouseClick);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(730, 627);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddBook,
            this.toolStripMenuItemAddFörfattare,
            this.toolStripMenuItemNyBok,
            this.toolStripMenuItemDeleteBok,
            this.toolStripMenuItemDeleteFörfattare,
            this.toolStripMenuItemAddButik,
            this.toolStripMenuItemAddKund});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(151, 158);
            // 
            // toolStripMenuItemAddBook
            // 
            this.toolStripMenuItemAddBook.Name = "toolStripMenuItemAddBook";
            this.toolStripMenuItemAddBook.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemAddBook.Text = "Add Book";
            this.toolStripMenuItemAddBook.Visible = false;
            this.toolStripMenuItemAddBook.Click += new System.EventHandler(this.toolStripMenuItemAddBook_Click);
            // 
            // toolStripMenuItemAddFörfattare
            // 
            this.toolStripMenuItemAddFörfattare.Name = "toolStripMenuItemAddFörfattare";
            this.toolStripMenuItemAddFörfattare.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemAddFörfattare.Text = "Add Författare";
            this.toolStripMenuItemAddFörfattare.Visible = false;
            this.toolStripMenuItemAddFörfattare.Click += new System.EventHandler(this.toolStripMenuItemAddFörfattare_Click);
            // 
            // toolStripMenuItemNyBok
            // 
            this.toolStripMenuItemNyBok.Name = "toolStripMenuItemNyBok";
            this.toolStripMenuItemNyBok.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemNyBok.Text = "Ny Bok";
            this.toolStripMenuItemNyBok.Visible = false;
            this.toolStripMenuItemNyBok.Click += new System.EventHandler(this.toolStripMenuItemNyBok_Click);
            // 
            // toolStripMenuItemDeleteBok
            // 
            this.toolStripMenuItemDeleteBok.Name = "toolStripMenuItemDeleteBok";
            this.toolStripMenuItemDeleteBok.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemDeleteBok.Text = "Delete";
            this.toolStripMenuItemDeleteBok.Click += new System.EventHandler(this.toolStripMenuItemDeleteBok_Click);
            // 
            // toolStripMenuItemDeleteFörfattare
            // 
            this.toolStripMenuItemDeleteFörfattare.Name = "toolStripMenuItemDeleteFörfattare";
            this.toolStripMenuItemDeleteFörfattare.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemDeleteFörfattare.Text = "Delete";
            this.toolStripMenuItemDeleteFörfattare.Visible = false;
            this.toolStripMenuItemDeleteFörfattare.Click += new System.EventHandler(this.toolStripMenuItemDeleteFörfattare_Click);
            // 
            // toolStripMenuItemAddButik
            // 
            this.toolStripMenuItemAddButik.Name = "toolStripMenuItemAddButik";
            this.toolStripMenuItemAddButik.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemAddButik.Text = "Add Butik";
            this.toolStripMenuItemAddButik.Visible = false;
            // 
            // toolStripMenuItemAddKund
            // 
            this.toolStripMenuItemAddKund.Name = "toolStripMenuItemAddKund";
            this.toolStripMenuItemAddKund.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemAddKund.Text = "Add Kund";
            this.toolStripMenuItemAddKund.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 627);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteBok;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddBook;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddFörfattare;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddButik;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddKund;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNyBok;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteFörfattare;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}