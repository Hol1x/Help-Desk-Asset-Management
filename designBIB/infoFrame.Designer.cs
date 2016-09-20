using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace designBIB
{
    partial class InfoFrame
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Save_button = new MetroFramework.Controls.MetroButton();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.ManualAdd_ID = new MetroFramework.Controls.MetroTextBox();
            this.ManualAdd_Titel = new MetroFramework.Controls.MetroTextBox();
            this.ManualAdd_Tid = new MetroFramework.Controls.MetroTextBox();
            this.ManualAdd_Klass = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.ManualAdd_AddButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.ManualAdd_Namn = new MetroFramework.Controls.MetroTextBox();
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
            this.dataGridView1.Location = new System.Drawing.Point(24, 155);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(706, 269);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // metroButton1
            // 
            this.metroButton1.Highlight = false;
            this.metroButton1.Location = new System.Drawing.Point(24, 430);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(88, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.StyleManager = null;
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Delete";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 132);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(24, 133);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(30, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Sök";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = false;
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // Save_button
            // 
            this.Save_button.Highlight = false;
            this.Save_button.Location = new System.Drawing.Point(655, 430);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(75, 23);
            this.Save_button.Style = MetroFramework.MetroColorStyle.Blue;
            this.Save_button.StyleManager = null;
            this.Save_button.TabIndex = 4;
            this.Save_button.Text = "Save";
            this.Save_button.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.CustomBackground = false;
            this.metroToggle1.DisplayStatus = true;
            this.metroToggle1.FontSize = MetroFramework.MetroLinkSize.Small;
            this.metroToggle1.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.metroToggle1.Location = new System.Drawing.Point(650, 63);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToggle1.StyleManager = null;
            this.metroToggle1.TabIndex = 5;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToggle1.UseStyleColors = false;
            this.metroToggle1.UseVisualStyleBackColor = true;
            this.metroToggle1.CheckedChanged += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.CustomBackground = false;
            this.metroLabel2.CustomForeColor = false;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel2.Location = new System.Drawing.Point(160, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(21, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.StyleManager = null;
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "ID";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.CustomForeColor = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(157, 89);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(33, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Titel";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.CustomBackground = false;
            this.metroLabel4.CustomForeColor = false;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel4.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel4.Location = new System.Drawing.Point(435, 60);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(27, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.StyleManager = null;
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Tid";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel4.UseStyleColors = false;
            // 
            // ManualAdd_ID
            // 
            this.ManualAdd_ID.CustomBackground = false;
            this.ManualAdd_ID.CustomForeColor = false;
            this.ManualAdd_ID.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.ManualAdd_ID.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.ManualAdd_ID.Location = new System.Drawing.Point(196, 60);
            this.ManualAdd_ID.Multiline = false;
            this.ManualAdd_ID.Name = "ManualAdd_ID";
            this.ManualAdd_ID.SelectedText = "";
            this.ManualAdd_ID.Size = new System.Drawing.Size(88, 23);
            this.ManualAdd_ID.Style = MetroFramework.MetroColorStyle.Blue;
            this.ManualAdd_ID.StyleManager = null;
            this.ManualAdd_ID.TabIndex = 10;
            this.ManualAdd_ID.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ManualAdd_ID.UseStyleColors = false;
            // 
            // ManualAdd_Titel
            // 
            this.ManualAdd_Titel.CustomBackground = false;
            this.ManualAdd_Titel.CustomForeColor = false;
            this.ManualAdd_Titel.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.ManualAdd_Titel.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.ManualAdd_Titel.Location = new System.Drawing.Point(196, 89);
            this.ManualAdd_Titel.Multiline = false;
            this.ManualAdd_Titel.Name = "ManualAdd_Titel";
            this.ManualAdd_Titel.SelectedText = "";
            this.ManualAdd_Titel.Size = new System.Drawing.Size(88, 23);
            this.ManualAdd_Titel.Style = MetroFramework.MetroColorStyle.Blue;
            this.ManualAdd_Titel.StyleManager = null;
            this.ManualAdd_Titel.TabIndex = 11;
            this.ManualAdd_Titel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ManualAdd_Titel.UseStyleColors = false;
            // 
            // ManualAdd_Tid
            // 
            this.ManualAdd_Tid.CustomBackground = false;
            this.ManualAdd_Tid.CustomForeColor = false;
            this.ManualAdd_Tid.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.ManualAdd_Tid.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.ManualAdd_Tid.Location = new System.Drawing.Point(468, 60);
            this.ManualAdd_Tid.Multiline = false;
            this.ManualAdd_Tid.Name = "ManualAdd_Tid";
            this.ManualAdd_Tid.SelectedText = "";
            this.ManualAdd_Tid.Size = new System.Drawing.Size(88, 23);
            this.ManualAdd_Tid.Style = MetroFramework.MetroColorStyle.Blue;
            this.ManualAdd_Tid.StyleManager = null;
            this.ManualAdd_Tid.TabIndex = 13;
            this.ManualAdd_Tid.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ManualAdd_Tid.UseStyleColors = false;
            this.ManualAdd_Tid.Click += new System.EventHandler(this.ManualAdd_Tid_Click);
            // 
            // ManualAdd_Klass
            // 
            this.ManualAdd_Klass.CustomBackground = false;
            this.ManualAdd_Klass.CustomForeColor = false;
            this.ManualAdd_Klass.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.ManualAdd_Klass.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.ManualAdd_Klass.Location = new System.Drawing.Point(341, 89);
            this.ManualAdd_Klass.Multiline = false;
            this.ManualAdd_Klass.Name = "ManualAdd_Klass";
            this.ManualAdd_Klass.SelectedText = "";
            this.ManualAdd_Klass.Size = new System.Drawing.Size(88, 23);
            this.ManualAdd_Klass.Style = MetroFramework.MetroColorStyle.Blue;
            this.ManualAdd_Klass.StyleManager = null;
            this.ManualAdd_Klass.TabIndex = 12;
            this.ManualAdd_Klass.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ManualAdd_Klass.UseStyleColors = false;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.CustomBackground = false;
            this.metroLabel6.CustomForeColor = false;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel6.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel6.Location = new System.Drawing.Point(639, 41);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(109, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel6.StyleManager = null;
            this.metroLabel6.TabIndex = 14;
            this.metroLabel6.Text = "Lägg till manuellt";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel6.UseStyleColors = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.CustomBackground = false;
            this.metroLabel7.CustomForeColor = false;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel7.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel7.Location = new System.Drawing.Point(290, 89);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(36, 19);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel7.StyleManager = null;
            this.metroLabel7.TabIndex = 15;
            this.metroLabel7.Text = "Klass";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel7.UseStyleColors = false;
            // 
            // ManualAdd_AddButton
            // 
            this.ManualAdd_AddButton.Highlight = false;
            this.ManualAdd_AddButton.Location = new System.Drawing.Point(532, 91);
            this.ManualAdd_AddButton.Name = "ManualAdd_AddButton";
            this.ManualAdd_AddButton.Size = new System.Drawing.Size(75, 23);
            this.ManualAdd_AddButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ManualAdd_AddButton.StyleManager = null;
            this.ManualAdd_AddButton.TabIndex = 16;
            this.ManualAdd_AddButton.Text = "Add";
            this.ManualAdd_AddButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ManualAdd_AddButton.Click += new System.EventHandler(this.ManualAdd_AddButton_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.CustomBackground = false;
            this.metroLabel5.CustomForeColor = false;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel5.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel5.Location = new System.Drawing.Point(290, 60);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(45, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.StyleManager = null;
            this.metroLabel5.TabIndex = 18;
            this.metroLabel5.Text = "Namn";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel5.UseStyleColors = false;
            this.metroLabel5.Click += new System.EventHandler(this.metroLabel5_Click);
            // 
            // ManualAdd_Namn
            // 
            this.ManualAdd_Namn.CustomBackground = false;
            this.ManualAdd_Namn.CustomForeColor = false;
            this.ManualAdd_Namn.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.ManualAdd_Namn.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.ManualAdd_Namn.Location = new System.Drawing.Point(341, 61);
            this.ManualAdd_Namn.Multiline = false;
            this.ManualAdd_Namn.Name = "ManualAdd_Namn";
            this.ManualAdd_Namn.SelectedText = "";
            this.ManualAdd_Namn.Size = new System.Drawing.Size(88, 23);
            this.ManualAdd_Namn.Style = MetroFramework.MetroColorStyle.Blue;
            this.ManualAdd_Namn.StyleManager = null;
            this.ManualAdd_Namn.TabIndex = 17;
            this.ManualAdd_Namn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ManualAdd_Namn.UseStyleColors = false;
            // 
            // infoFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 471);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.ManualAdd_Namn);
            this.Controls.Add(this.ManualAdd_AddButton);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.ManualAdd_Tid);
            this.Controls.Add(this.ManualAdd_Klass);
            this.Controls.Add(this.ManualAdd_Titel);
            this.Controls.Add(this.ManualAdd_ID);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "InfoFrame";
            this.Text = "infoFrame";
            this.Load += new System.EventHandler(this.infoFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private MetroButton metroButton1;
        private TextBox textBox1;
        private MetroLabel metroLabel1;
        private MetroButton Save_button;
        private MetroToggle metroToggle1;
        private MetroLabel metroLabel2;
        private MetroLabel metroLabel3;
        private MetroLabel metroLabel4;
        private MetroTextBox ManualAdd_ID;
        private MetroTextBox ManualAdd_Titel;
        private MetroTextBox ManualAdd_Tid;
        private MetroTextBox ManualAdd_Klass;
        private MetroLabel metroLabel6;
        private MetroLabel metroLabel7;
        private MetroButton ManualAdd_AddButton;
        private MetroLabel metroLabel5;
        private MetroTextBox ManualAdd_Namn;
    }
}