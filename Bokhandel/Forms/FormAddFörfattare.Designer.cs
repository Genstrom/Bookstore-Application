
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewFörfattare = new System.Windows.Forms.DataGridView();
            this.dataGridViewBok = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel.Size = new System.Drawing.Size(684, 261);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // dataGridViewFörfattare
            // 
            this.dataGridViewFörfattare.AllowUserToAddRows = false;
            this.dataGridViewFörfattare.AllowUserToDeleteRows = false;
            this.dataGridViewFörfattare.AllowUserToResizeColumns = false;
            this.dataGridViewFörfattare.AllowUserToResizeRows = false;
            this.dataGridViewFörfattare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFörfattare.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewFörfattare.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFörfattare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFörfattare.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFörfattare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFörfattare.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewFörfattare.Name = "dataGridViewFörfattare";
            this.dataGridViewFörfattare.RowHeadersVisible = false;
            this.dataGridViewFörfattare.RowTemplate.Height = 50;
            this.dataGridViewFörfattare.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFörfattare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewFörfattare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewFörfattare.Size = new System.Drawing.Size(336, 225);
            this.dataGridViewFörfattare.TabIndex = 0;
            // 
            // dataGridViewBok
            // 
            this.dataGridViewBok.AllowUserToAddRows = false;
            this.dataGridViewBok.AllowUserToDeleteRows = false;
            this.dataGridViewBok.AllowUserToResizeRows = false;
            this.dataGridViewBok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBok.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewBok.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBok.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBok.Location = new System.Drawing.Point(345, 3);
            this.dataGridViewBok.Name = "dataGridViewBok";
            this.dataGridViewBok.RowHeadersVisible = false;
            this.dataGridViewBok.RowTemplate.Height = 50;
            this.dataGridViewBok.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewBok.Size = new System.Drawing.Size(336, 225);
            this.dataGridViewBok.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonCancel.Location = new System.Drawing.Point(475, 231);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 30);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonSave.Location = new System.Drawing.Point(133, 231);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 30);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormAddFörfattare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddFörfattare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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