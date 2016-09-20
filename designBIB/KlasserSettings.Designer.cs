using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace designBIB
{
    partial class KlasserSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Save_button = new MetroFramework.Controls.MetroButton();
            this.btnCheckKlasser = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 253);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(789, 275);
            this.dataGridView1.TabIndex = 1;
            // 
            // Save_button
            // 
            this.Save_button.Highlight = false;
            this.Save_button.Location = new System.Drawing.Point(737, 535);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(75, 23);
            this.Save_button.Style = MetroFramework.MetroColorStyle.Blue;
            this.Save_button.StyleManager = null;
            this.Save_button.TabIndex = 5;
            this.Save_button.Text = "Save";
            this.Save_button.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // btnCheckKlasser
            // 
            this.btnCheckKlasser.Highlight = false;
            this.btnCheckKlasser.Location = new System.Drawing.Point(23, 535);
            this.btnCheckKlasser.Name = "btnCheckKlasser";
            this.btnCheckKlasser.Size = new System.Drawing.Size(75, 23);
            this.btnCheckKlasser.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnCheckKlasser.StyleManager = null;
            this.btnCheckKlasser.TabIndex = 6;
            this.btnCheckKlasser.Text = "Check";
            this.btnCheckKlasser.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnCheckKlasser.Click += new System.EventHandler(this.btnCheckKlasser_Click);
            // 
            // KlasserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 581);
            this.Controls.Add(this.btnCheckKlasser);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "KlasserSettings";
            this.Text = "KlasserSettings";
            this.Load += new System.EventHandler(this.KlasserSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private MetroButton Save_button;
        private MetroButton btnCheckKlasser;
    }
}