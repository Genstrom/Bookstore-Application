
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewFörfattare = new System.Windows.Forms.DataGridView();
            this.dataGridViewBok = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFörfattare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBok)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.dataGridViewFörfattare, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewBok, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonCancel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonSave, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.53503F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.46497F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(772, 471);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // dataGridViewFörfattare
            // 
            this.dataGridViewFörfattare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFörfattare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFörfattare.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewFörfattare.Name = "dataGridViewFörfattare";
            this.dataGridViewFörfattare.RowTemplate.Height = 25;
            this.dataGridViewFörfattare.Size = new System.Drawing.Size(380, 411);
            this.dataGridViewFörfattare.TabIndex = 0;
            // 
            // dataGridViewBok
            // 
            this.dataGridViewBok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBok.Location = new System.Drawing.Point(389, 3);
            this.dataGridViewBok.Name = "dataGridViewBok";
            this.dataGridViewBok.RowTemplate.Height = 25;
            this.dataGridViewBok.Size = new System.Drawing.Size(380, 411);
            this.dataGridViewBok.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSave.Location = new System.Drawing.Point(155, 432);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.Location = new System.Drawing.Point(541, 432);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormAddFörfattare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 471);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FormAddFörfattare";
            this.Text = "FormAddFörfattare";
            this.Load += new System.EventHandler(this.FormAddFörfattare_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFörfattare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView dataGridViewFörfattare;
        private System.Windows.Forms.DataGridView dataGridViewBok;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}