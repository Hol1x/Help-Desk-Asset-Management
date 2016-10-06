using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace designBIB
{
    partial class FrmProdukter
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
            this.chkHasHeader = new MetroFramework.Controls.MetroCheckBox();
            this.checker = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtLediaDatorer = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
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
            this.btnCheckKlasser.Location = new System.Drawing.Point(107, 535);
            this.btnCheckKlasser.Name = "btnCheckKlasser";
            this.btnCheckKlasser.Size = new System.Drawing.Size(75, 23);
            this.btnCheckKlasser.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnCheckKlasser.StyleManager = null;
            this.btnCheckKlasser.TabIndex = 6;
            this.btnCheckKlasser.Text = "Import";
            this.btnCheckKlasser.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnCheckKlasser.Click += new System.EventHandler(this.btnCheckKlasser_Click);
            // 
            // chkHasHeader
            // 
            this.chkHasHeader.AutoSize = true;
            this.chkHasHeader.CustomBackground = false;
            this.chkHasHeader.CustomForeColor = false;
            this.chkHasHeader.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkHasHeader.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkHasHeader.Location = new System.Drawing.Point(21, 539);
            this.chkHasHeader.Name = "chkHasHeader";
            this.chkHasHeader.Size = new System.Drawing.Size(80, 15);
            this.chkHasHeader.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkHasHeader.StyleManager = null;
            this.chkHasHeader.TabIndex = 7;
            this.chkHasHeader.Text = "has header";
            this.chkHasHeader.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkHasHeader.UseStyleColors = false;
            this.chkHasHeader.UseVisualStyleBackColor = true;
            this.chkHasHeader.CheckedChanged += new System.EventHandler(this.chkHasHeader_CheckedChanged);
            // 
            // checker
            // 
            this.checker.Highlight = false;
            this.checker.Location = new System.Drawing.Point(132, 112);
            this.checker.Name = "checker";
            this.checker.Size = new System.Drawing.Size(75, 23);
            this.checker.Style = MetroFramework.MetroColorStyle.Blue;
            this.checker.StyleManager = null;
            this.checker.TabIndex = 8;
            this.checker.Text = "Kolla";
            this.checker.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checker.Click += new System.EventHandler(this.checker_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(23, 89);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(97, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Lediga Datorer";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = false;
            // 
            // txtLediaDatorer
            // 
            this.txtLediaDatorer.CustomBackground = false;
            this.txtLediaDatorer.CustomForeColor = false;
            this.txtLediaDatorer.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txtLediaDatorer.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txtLediaDatorer.Location = new System.Drawing.Point(24, 112);
            this.txtLediaDatorer.Multiline = false;
            this.txtLediaDatorer.Name = "txtLediaDatorer";
            this.txtLediaDatorer.SelectedText = "";
            this.txtLediaDatorer.Size = new System.Drawing.Size(96, 23);
            this.txtLediaDatorer.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLediaDatorer.StyleManager = null;
            this.txtLediaDatorer.TabIndex = 10;
            this.txtLediaDatorer.Text = "Lediga datorer...";
            this.txtLediaDatorer.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLediaDatorer.UseStyleColors = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.CustomBackground = false;
            this.metroLabel2.CustomForeColor = false;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel2.Location = new System.Drawing.Point(21, 231);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.StyleManager = null;
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Sök dator";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = false;
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 230);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.CustomForeColor = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(21, 205);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(57, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Sök elev";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = false;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 204);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // FrmProdukter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 581);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtLediaDatorer);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.checker);
            this.Controls.Add(this.chkHasHeader);
            this.Controls.Add(this.btnCheckKlasser);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmProdukter";
            this.Text = "frmProdukter";
            this.Load += new System.EventHandler(this.frmProdukter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private MetroButton Save_button;
        private MetroButton btnCheckKlasser;
        private MetroCheckBox chkHasHeader;
        private MetroButton checker;
        private MetroLabel metroLabel1;
        private MetroTextBox txtLediaDatorer;
        private MetroLabel metroLabel2;
        private TextBox textBox1;
        private MetroLabel metroLabel3;
        private TextBox textBox2;
    }
}