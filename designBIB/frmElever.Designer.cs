using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace designBIB
{
    partial class FrmElever
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
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
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
            this.checker.Location = new System.Drawing.Point(593, 535);
            this.checker.Name = "checker";
            this.checker.Size = new System.Drawing.Size(75, 23);
            this.checker.Style = MetroFramework.MetroColorStyle.Blue;
            this.checker.StyleManager = null;
            this.checker.TabIndex = 8;
            this.checker.Text = "check";
            this.checker.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checker.Click += new System.EventHandler(this.checker_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.FontSize = MetroFramework.MetroProgressBarSize.Medium;
            this.metroProgressBar1.FontWeight = MetroFramework.MetroProgressBarWeight.Light;
            this.metroProgressBar1.HideProgressText = true;
            this.metroProgressBar1.Location = new System.Drawing.Point(24, 224);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.metroProgressBar1.Size = new System.Drawing.Size(788, 23);
            this.metroProgressBar1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressBar1.StyleManager = null;
            this.metroProgressBar1.TabIndex = 9;
            this.metroProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(23, 199);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(30, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Sök";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FrmElever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 581);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.checker);
            this.Controls.Add(this.chkHasHeader);
            this.Controls.Add(this.btnCheckKlasser);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmElever";
            this.Text = "Elever";
            this.Load += new System.EventHandler(this.frmElever_Load);
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
        private MetroProgressBar metroProgressBar1;
        private MetroLabel metroLabel1;
        private TextBox textBox1;
    }
}