using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using designBIB.Properties;
using MetroFramework.Forms;

namespace designBIB
{
    public partial class Form1 : MetroForm
    {
        private readonly Logs _log = new Logs();

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the latest build number to display
            Text = Text + Resources.Form1_Form1_Load__space + typeof(Form1).Assembly.GetName().Version;

            // Load kunder.xml to display in combobox
            const string xmlfile = @"‪elever.xml";
            var doc = XDocument.Load(xmlfile);
            _log.Logger(xmlfile + " loaded");

            // Get all values to string array
            //var namn = from key in doc.Descendants("Row").Descendants("Fornamn")
            //    select key.Value + " ";
            if (doc.Root == null) return;
            var namn = doc.Root.Elements("Row")
                .Select(i => (string)i.Element("Fornamn") + " " + (string)i.Element("Efternamn") + " " + (string)i.Element("Id"));
            // put convert to list and use as datasource 
            Kund_box.DataSource = namn.ToList();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            const string xmlfile = "‪produkter.xml";
            metroProgressBar1.Value = 20;
            var doc = XDocument.Load(xmlfile);

            metroProgressBar1.Value = 40;
            // get the id of the user
            var loadklass = Kund_box.SelectedItem.ToString();
            var digits = loadklass.SkipWhile(c => !Char.IsDigit(c))
            .TakeWhile(Char.IsDigit)
            .ToArray();

            var id = new string(digits);
            
            if (doc.Root != null)
            {
                //populate combobox with units connected to that user id
                var serienummer =
                                doc.Root.Elements("Row")
                                    .Where(i => (string)i.Element("Owner") == id)
                                    .Select(i => (string)i.Element("Serienummer"))
                                    ;
                metroProgressBar1.Value = 80;
                Enhet_box.DataSource = serienummer.ToList();
            }
            metroProgressBar1.Value = 100;
            //Console.Write(loadklass);
            reset_progressbar();
        }

        private void reset_progressbar()
        {
            metroProgressBar1.Value = 0;
        }

        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd/ HH:mm");
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            UpdateCheck();

            using (var fs = new FileStream(@"service.xml",
                FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                var doc = new XmlDocument();
                doc.Load(fs);
                XmlNode lanad = doc.CreateElement("Row");
                XmlNode servicenummer = doc.CreateElement("Servicenummer");
                servicenummer.InnerText = Servicenr_box.Text;
                XmlNode servicestalle = doc.CreateElement("Servicestalle");
                servicestalle.InnerText = Service_box.Text;
                XmlNode kontaktinformation = doc.CreateElement("Kontaktinformation");
                kontaktinformation.InnerText = Kontakt_box.Text;
                XmlNode serienummer = doc.CreateElement("Serienummer");
                serienummer.InnerText = Serie_box.Text;
                XmlNode anmalningsdatum = doc.CreateElement("Anmalningsdatum");
                anmalningsdatum.InnerText = anmalningsdatum_box.Text;
                XmlNode leveransdatum = doc.CreateElement("Leveransdatum");
                leveransdatum.InnerText = utlamnings_box.Text;
                XmlNode user = doc.CreateElement("User");
                user.InnerText = Enhet_box.SelectedItem + " " + Kund_box.SelectedItem;
                XmlNode felbeskrvningxml = doc.CreateElement("Felbeskrivning");
                felbeskrvningxml.InnerText = Felbeskrivning.Text;
                XmlNode atgardxml = doc.CreateElement("Atgard");
                atgardxml.InnerText = Atgard.Text;
                XmlNode extraNode = doc.CreateElement("Extra");
                extraNode.InnerText = txtBoxExtra.Text;
                XmlNode skickad = doc.CreateElement("Skickad");
                skickad.InnerText = chkSkickad.CheckState.ToString();
                XmlNode fardig = doc.CreateElement("Fardig");
                fardig.InnerText = chkFardig.CheckState.ToString();
                lanad.AppendChild(servicenummer);
                lanad.AppendChild(servicestalle);
                lanad.AppendChild(kontaktinformation);
                lanad.AppendChild(serienummer);
                lanad.AppendChild(anmalningsdatum);
                lanad.AppendChild(leveransdatum);
                lanad.AppendChild(user);
                lanad.AppendChild(felbeskrvningxml);
                lanad.AppendChild(atgardxml);
                lanad.AppendChild(extraNode);
                lanad.AppendChild(skickad);
                lanad.AppendChild(fardig);
                doc.DocumentElement?.AppendChild(lanad);
                fs.SetLength(0);
                doc.Save(fs);

                _log.Logger("Updated service for: " + user.InnerText + Environment.NewLine
                            + "   info service number: " + servicenummer.InnerText + Environment.NewLine
                            + "   info service place: " + servicestalle.InnerText + Environment.NewLine
                            + "   info contact information: " + kontaktinformation.InnerText + Environment.NewLine
                            + "   info serialnumber: " + serienummer.InnerText + Environment.NewLine
                            + "   info date: " + anmalningsdatum.InnerText + Environment.NewLine
                            + "   info delivery date: " + leveransdatum.InnerText + Environment.NewLine
                            + "   info problem: " + felbeskrvningxml.InnerText + Environment.NewLine
                            + "   info correction: " + atgardxml.InnerText + Environment.NewLine
                            + "   info sent?: " + skickad.InnerText + Environment.NewLine
                            + "   info done?: " + fardig.InnerText + Environment.NewLine);
                metroLabel1.Text = Resources.Form1_metroButton1_Click_Ärendet_är_upplagdt;
            }
        }


        private void metroButton2_Click(object sender, EventArgs e)
        {
            //infoFrame frame = new infoFrame();
            //KlasserSettings frame = new KlasserSettings();
            var frame = new FrmService();
            frame.Show();
        }

        private void UpdateCheck()
        {
            using (var fs = new FileStream(@"service.xml",
                FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                var xDoc = new XmlDocument();
                xDoc.Load(fs);
                var xmlNodeList = xDoc.SelectNodes("DocumentElement/Row");
                if (xmlNodeList != null)
                    foreach (XmlNode xNode in xmlNodeList)
                        if ((xNode.SelectSingleNode("Serienummer")?.InnerText == Serie_box.Text) &&
                            (xNode.SelectSingleNode("Fardig")?.InnerText == "Unchecked"))
                        {
                            xNode.ParentNode?.RemoveChild(xNode);
                            metroLabel1.Text = Resources.Form1_UpdateCheck_update_was_executed_;
                        }
                fs.SetLength(0);
                xDoc.Save(fs);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            using (var fs = new FileStream(@"service.xml",
                FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                var xDoc = new XmlDocument();
                xDoc.Load(fs);
                var xmlNodeList = xDoc.SelectNodes("DocumentElement/Row");
                if (xmlNodeList != null)
                    foreach (XmlNode xNode in xmlNodeList)
                        if (xNode.SelectSingleNode("Serienummer")?.InnerText == Serie_box.Text)
                        {
                            xNode.ParentNode?.RemoveChild(xNode);
                            metroLabel1.Text = metroLabel1.Text + @" Är nu återlämnad!";
                        }
                fs.SetLength(0);
                xDoc.Save(fs);
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var digits = Kund_box.SelectedItem.ToString().SkipWhile(c => !Char.IsDigit(c))
    .TakeWhile(Char.IsDigit)
    .ToArray();

            var id2 = new string(digits);
           
            char[] delimiterChars = {' '};


            const string xmlfile = @"‪service.xml";
            const string xmlfile2 = @"produkter.xml";
            const string xmlfile3 = @"Elever.xml";
            metroProgressBar1.Value = 20;
            var doc = XDocument.Load(xmlfile);
            var doc1 = XDocument.Load(xmlfile2);
            var doc2 = XDocument.Load(xmlfile3);

            Servicenr_box.Text = "";
            Service_box.Text = "";
            Kontakt_box.Text = "";

            anmalningsdatum_box.Text = "";
            utlamnings_box.Text = "";

            Felbeskrivning.Text = "";
            Atgard.Text = "";
            txtBoxExtra.Text = "";
            chkSkickad.CheckState = CheckState.Unchecked;
            chkFardig.CheckState = CheckState.Unchecked;

            metroProgressBar1.Value = 40;
            var loadklass = Enhet_box.SelectedItem + " " + Kund_box.SelectedItem;
            var elevNamn = Enhet_box.SelectedItem.ToString();

            if (doc.Root != null)
            {
                var servicenummer =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Servicenummer"))
                        .FirstOrDefault();
                var servicestalle =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Servicestalle"))
                        .FirstOrDefault();
                var kontaktinformation =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Kontaktinformation"))
                        .FirstOrDefault();
                var serienummer =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Serienummer"))
                        .FirstOrDefault();
                if (string.IsNullOrWhiteSpace(serienummer))
                {
                    var words = elevNamn.Split(delimiterChars);
                    string id;
                    Debug.WriteLine(words.Length);
                    if (doc2.Root != null)
                    {
                        id = words.Length > 2
                            ? doc2.Root.Elements("Row")
                                .Where(i => (string) i.Element("Fornamn") == words[0])
                                .Where(i => (string) i.Element("Efternamn") == words[1] + " " + words[2].Trim())
                                .Where(i => (string) i.Element("Klass") == Kund_box.SelectedItem.ToString())
                                .Select(i => (string) i.Element("Id"))
                                .FirstOrDefault()
                            : doc2.Root.Elements("Row")
                                .Where(i => (string) i.Element("Fornamn") == words[0])
                                .Where(i => (string) i.Element("Efternamn") == words[1])
                                .Where(i => (string) i.Element("Klass") == Kund_box.SelectedItem.ToString())
                                .Select(i => (string) i.Element("Id"))
                                .FirstOrDefault();
                        if (doc1.Root != null)
                            serienummer =
                                doc1.Root.Elements("Row")
                                    .Where(i => (string) i.Element("Owner") == id2)
                                    .Select(i => (string) i.Element("Serienummer"))
                                    .FirstOrDefault();
                    }
                }
                var anmalningsdatum =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Anmalningsdatum"))
                        .FirstOrDefault();
                var leveransdatum =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Leveransdatum"))
                        .FirstOrDefault();
                var felbeskrivningValue =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Felbeskrivning"))
                        .FirstOrDefault();
                var atgardValue =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Atgard"))
                        .FirstOrDefault();
                var extra =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Extra"))
                        .FirstOrDefault();
                var skickad =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Skickad"))
                        .FirstOrDefault();
                var fardig =
                    doc.Root.Elements("Row")
                        .Where(i => (string) i.Element("User") == loadklass)
                        .Where(i => (string) i.Element("Fardig") == "Unchecked")
                        .Select(i => (string) i.Element("Fardig"))
                        .FirstOrDefault();
                metroProgressBar1.Value = 80;
                Serie_box.Text = serienummer;
                if (fardig == "Unchecked")
                {
                    Servicenr_box.Text = servicenummer;
                    Service_box.Text = servicestalle;
                    Kontakt_box.Text = kontaktinformation;
                    Serie_box.Text = serienummer;
                    anmalningsdatum_box.Text = anmalningsdatum;
                    utlamnings_box.Text = leveransdatum;
                    Felbeskrivning.Text = felbeskrivningValue;
                    Atgard.Text = atgardValue;
                    txtBoxExtra.Text = extra;
                    chkSkickad.CheckState = skickad == "Checked" ? CheckState.Checked : CheckState.Unchecked;
                    //if (Fardig == "Checked")
                    //    chkFardig.CheckState = CheckState.Checked;
                    //else chkFardig.CheckState = CheckState.Unchecked;

                    metroProgressBar1.Value = 100;
                } //Console.Write(loadklass);
            }
            reset_progressbar();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            //infoFrame frame = new infoFrame();
            //KlasserSettings frame = new KlasserSettings();
            var frame = new FrmProdukter();
            frame.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            //infoFrame frame = new infoFrame();
            var frame = new KlasserSettings();
            //frmProdukter frame = new frmProdukter();
            frame.Show();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            var form = new FrmKunder();
            form.Show();
        }

        private void txtAnmalingsdatum_Click(object sender, EventArgs e)
        {
            anmalningsdatum_box.Text = GetTimestamp(DateTime.Now);
        }

        private void metroLabel15_Click(object sender, EventArgs e)
        {
        }
    }
}