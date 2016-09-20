using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using MetroFramework.Forms;

namespace designBIB
{
    public partial class KlasserSettings : MetroForm
    {
        public KlasserSettings()
        {
            InitializeComponent();
        }

        private class Row
        {
            public string Klasser { get; set; }
            public string Id { get; set; }
        }

        private static void Print(Row obj)
        {
            Console.WriteLine(obj.ToString());
        }

        private void KlasserSettings_Load(object sender, EventArgs e)
        {
           
                using (FileStream fs = new FileStream(@"klasser.xml",
                   FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                    var xDoc = XDocument.Load(fs);

                    var items = (from r in xDoc.Elements("DocumentElement").Elements("Row")
                                       select new Row
                                       {
                                           Klasser = (string)r.Element("Klasser") + "",
                                           Id = (string)r.Element("ID")+""
                                           
                                       }).ToList();

                    fs.SetLength(0);
                    xDoc.Save(fs);
                    items.ForEach(Print);
                    var list = new BindingList<Row>(items);
                    var converter = new ListtoDataTableConverter();
                    var dt = converter.ToDataTable(list);
                    dataGridView1.DataSource = dt;
                }
            }
        

        private void Save_button_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()

        {
            const string path = @"klasser.xml";
            var ds = dataGridView1.DataSource as DataTable;
            ds?.WriteXml(path);
        }

        private void btnCheckKlasser_Click(object sender, EventArgs e)
        {
            const string xmlfile = @"‪produkter.xml";
            var doc = XDocument.Load(xmlfile);
            //var node = doc.Descendants().Where(n => n.Value == metroTextBox1.Text);
            //metroComboBox2.DataSource = node.ToList();
            var itemType = doc.Root?.Elements("Row")
                   .Where(i => string.IsNullOrWhiteSpace((string)i.Element("Owner")))
                   ;

            if (itemType == null) return;
            foreach (var ex in itemType) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
