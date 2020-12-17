
namespace Bokhandel.Forms
{
    partial class FormAddFörfattare
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewFörfattare = new System.Windows.Forms.DataGridView();
            this.dataGridViewBok = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFörfattare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBok)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewFörfattare);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewBok);
            this.splitContainer1.Size = new System.Drawing.Size(772, 471);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewFörfattare
            // 
            this.dataGridViewFörfattare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFörfattare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFörfattare.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFörfattare.Name = "dataGridViewFörfattare";
            this.dataGridViewFörfattare.RowTemplate.Height = 25;
            this.dataGridViewFörfattare.Size = new System.Drawing.Size(380, 471);
            this.dataGridViewFörfattare.TabIndex = 0;
            // 
            // dataGridViewBok
            // 
            this.dataGridViewBok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBok.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBok.Name = "dataGridViewBok";
            this.dataGridViewBok.RowTemplate.Height = 25;
            this.dataGridViewBok.Size = new System.Drawing.Size(388, 471);
            this.dataGridViewBok.TabIndex = 0;
            // 
            // FormAddFörfattare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 471);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormAddFörfattare";
            this.Text = "FormAddFörfattare";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFörfattare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewFörfattare;
        private System.Windows.Forms.DataGridView dataGridViewBok;
    }
}