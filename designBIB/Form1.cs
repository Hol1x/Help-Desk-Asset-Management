using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using designBIB.Properties;
using MetroFramework.Forms;
using OfficeOpenXml.FormulaParsing.Logging;

namespace designBIB
{
    public partial class Form1 : MetroForm
    {
        public static string UserNameWhoFuckedItUp { get; private set; }
        private readonly Logs _log = new Logs();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Text + Resources.Form1_Form1_Load__space +typeof(Form1).Assembly.GetName().Version;
            const string xmlfile = @"‪elever.xml";
            var doc = XDocument.Load(xmlfile);
            _log.Logger(xmlfile + " loaded");
            UserNameWhoFuckedItUp = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            const string xmlfile2 = @"‪klasser.xml";
            var doc2 = XDocument.Load(xmlfile2);
            _log.Logger(xmlfile2 + " loaded");
            //var node = doc.Descendants().Where(n => n.Value == metroTextBox1.Text);
            //metroComboBox2.DataSource = node.ToList();
            var itemType = from key in doc2.Descendants("Row").Descendants("Klasser")
                           select key.Value;
            var namn = from key in doc.Descendants("record").Descendants("Name")
                       select key.Value + " ";

            metroComboBox1.DataSource = itemType.ToList();
            metroComboBox2.DataSource = namn.ToList();
            
            
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var xmlfile = "‪elever.xml";
            metroProgressBar1.Value = 20;
            var doc = XDocument.Load(xmlfile);

            metroProgressBar1.Value = 40;
            var loadklass = metroComboBox1.SelectedItem.ToString();

            if (doc.Root != null)
            {
                var selectedKlass = doc.Root.Elements("Row")
                    .Where(i => (string)i.Element("Klass") == loadklass).Select(i => (string)i.Element("Fornamn")+" "+(string)i.Element("Efternamn"));

                metroProgressBar1.Value = 80;
                metroComboBox2.DataSource = selectedKlass.ToList();
            }
            metroProgressBar1.Value = 100;
            //Console.Write(loadklass);
            reset_progressbar();
        }

        private void reset_progressbar()
        {
            metroProgressBar1.Value = 0;
        }

        private string GetBookByTitle(string bok)
        {
            const string xmlfile = "‪/Bok2.xml";
            var doc = XDocument.Load(xmlfile);
            //metroComboBox2.DataSource = node.ToList();
            var itemType = doc.Root?.Elements("bok").Elements("recorde")
                .Where(i => (string)i.Element("title") == bok)
                .Where(i => (string)i.Element("InUse") == "no")
                .Select(i => (string)i.Element("nummer"))
                .FirstOrDefault();

            return itemType;
        }

        private string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd/ HH:mm");
        }

        

        private void metroButton1_Click(object sender, EventArgs e)
        {
            UpdateCheck();
            
                using (FileStream fs = new FileStream(@"service.xml",
                   FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fs);
                    XmlNode lanad = doc.CreateElement("Row");
                    XmlNode servicenummer = doc.CreateElement("Servicenummer");
                    servicenummer.InnerText = txtServicenummer.Text;
                    XmlNode servicestalle = doc.CreateElement("Servicestalle");
                    servicestalle.InnerText = txtServicestalle.Text;
                    XmlNode kontaktinformation = doc.CreateElement("Kontaktinformation");
                    kontaktinformation.InnerText = txtKontaktinformation.Text;
                    XmlNode serienummer = doc.CreateElement("Serienummer");
                    serienummer.InnerText = txtSerienummer.Text;
                    XmlNode anmalningsdatum = doc.CreateElement("Anmalningsdatum");
                    anmalningsdatum.InnerText = txtAnmalingsdatum.Text;
                    XmlNode leveransdatum = doc.CreateElement("Leveransdatum");
                    leveransdatum.InnerText = txtLeveransdatum.Text;
                    XmlNode user = doc.CreateElement("User");
                    user.InnerText =  metroComboBox2.SelectedItem +" "+ metroComboBox1.SelectedItem;
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
                        + "   info service number: "+ servicenummer.InnerText + Environment.NewLine
                        + "   info service place: " + servicestalle.InnerText + Environment.NewLine
                        + "   info contact information: " + kontaktinformation.InnerText + Environment.NewLine
                        + "   info serialnumber: " + serienummer.InnerText + Environment.NewLine
                        + "   info date: " + anmalningsdatum.InnerText + Environment.NewLine
                        + "   info delivery date: " + leveransdatum.InnerText + Environment.NewLine
                        + "   info problem: " + felbeskrvningxml.InnerText + Environment.NewLine
                        + "   info correction: " + atgardxml.InnerText + Environment.NewLine
                        + "   info sent?: " + skickad.InnerText + Environment.NewLine
                        + "   info done?: " + fardig.InnerText + Environment.NewLine);
                    metroLabel1.Text =Resources.Form1_metroButton1_Click_Ärendet_är_upplagdt;
                
            }
        }

     
        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            //metroLabel1.Text = SearchResults;
            metroID.Text = metroTextBox1.Text;
            //metroTextBox2.Text = SearchResults;
        }

        private string ReturnedId(string keyword)
        {
            var xmlfile = "‪/Bok2.xml";
            var doc = XDocument.Load(xmlfile);
            //var node = doc.Descendants().Where(n => n.Value == metroTextBox1.Text);
            //metroComboBox2.DataSource = node.ToList();
            var query = doc.Descendants("bok").Descendants("recorde").Descendants("title")
    .Where(x => !x.HasElements &&
                x.Value.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) >= 0);
            //foreach (var element in query)
            //Console.WriteLine(query.FirstOrDefault().Value);
            //foreach (var element in books)
            // Console.WriteLine(matches.First().Value);
            var xElements = query as XElement[] ?? query.ToArray();
            if (xElements.FirstOrDefault() != null)
            {
                var firstOrDefault = xElements.FirstOrDefault();
                if (firstOrDefault != null)

                {
                    var orDefault = xElements.FirstOrDefault();
                    if (orDefault != null) return orDefault.Value;
                }
                else
                    return "";
            }
            else return "";
            return null;
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            var seachResults = ReturnedId(metroTextBox2.Text);
            metroLabel1.Text = seachResults;

            metroTextBox1.Text = GetBookByTitle(seachResults);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //infoFrame frame = new infoFrame();
            //KlasserSettings frame = new KlasserSettings();
            FrmService frame = new FrmService();
            frame.Show();
        }
        private void UpdateCheck() {
            using (var fs = new FileStream(@"service.xml",
                   FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(fs);
                XmlNodeList xmlNodeList = xDoc.SelectNodes("DocumentElement/Row");
                if (xmlNodeList != null)
                    foreach (XmlNode xNode in xmlNodeList)
                        if (xNode.SelectSingleNode("Serienummer")?.InnerText == txtSerienummer.Text && xNode.SelectSingleNode("Fardig")?.InnerText == "Unchecked") {
                            xNode.ParentNode?.RemoveChild(xNode);
                            metroLabel1.Text =Resources.Form1_UpdateCheck_update_was_executed_;
                        }
                fs.SetLength(0);
                xDoc.Save(fs);
            }
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            using (var fs = new FileStream(@"service.xml",
                   FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                var xDoc = new XmlDocument();
                xDoc.Load(fs);
                var xmlNodeList = xDoc.SelectNodes("DocumentElement/Row");
                if (xmlNodeList != null)
                    foreach (XmlNode xNode in xmlNodeList)
                        if (xNode.SelectSingleNode("Serienummer")?.InnerText == txtSerienummer.Text) {
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

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            char[] delimiterChars = { ' ' };

            
            const string xmlfile = @"‪service.xml";
            const string xmlfile2 = @"produkter.xml";
            const string xmlfile3 = @"Elever.xml";
            metroProgressBar1.Value = 20;
            var doc = XDocument.Load(xmlfile);
            var doc1 = XDocument.Load(xmlfile2);
            var doc2 = XDocument.Load(xmlfile3);

            txtServicenummer.Text = "";
            txtServicestalle.Text = "";
            txtKontaktinformation.Text = "";

            txtAnmalingsdatum.Text = "";
            txtLeveransdatum.Text = "";

            Felbeskrivning.Text = "";
            Atgard.Text = "";
            txtBoxExtra.Text = "";
            chkSkickad.CheckState = CheckState.Unchecked;
            chkFardig.CheckState = CheckState.Unchecked;

            metroProgressBar1.Value = 40;
            var loadklass = metroComboBox2.SelectedItem +" "+ metroComboBox1.SelectedItem;
            var elevNamn = metroComboBox2.SelectedItem.ToString();

            if (doc.Root != null)
            {
                var servicenummer = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig")== "Unchecked").Select(i => (string)i.Element("Servicenummer")).FirstOrDefault();
                var servicestalle = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Servicestalle")).FirstOrDefault();
                var kontaktinformation = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Kontaktinformation")).FirstOrDefault();
                var serienummer = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Serienummer")).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(serienummer)) {
                    var words = elevNamn.Split(delimiterChars);
                    string id;
                    Debug.WriteLine(words.Length);
                    if (doc2.Root != null)
                    {
                        id = words.Length > 2 ? doc2.Root.Elements("Row").Where(i => (string)i.Element("Fornamn") == words[0]).Where(i => (string)i.Element("Efternamn") == words[1] + " " + words[2].Trim()).Where(i => (string)i.Element("Klass") == metroComboBox1.SelectedItem.ToString()).Select(i => (string)i.Element("Id")).FirstOrDefault() : doc2.Root.Elements("Row").Where(i => (string)i.Element("Fornamn") == words[0]).Where(i => (string)i.Element("Efternamn") == words[1]).Where(i => (string)i.Element("Klass") == metroComboBox1.SelectedItem.ToString()).Select(i => (string)i.Element("Id")).FirstOrDefault();
                        if (doc1.Root != null)
                            serienummer = doc1.Root.Elements("Row").Where(i => (string)i.Element("Owner") == id).Select(i => (string)i.Element("Serienummer")).FirstOrDefault();
                    }
                }
                var anmalningsdatum = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Anmalningsdatum")).FirstOrDefault();
                var leveransdatum = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Leveransdatum")).FirstOrDefault();
                var felbeskrivningValue = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Felbeskrivning")).FirstOrDefault();
                var atgardValue = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Atgard")).FirstOrDefault();
                var extra = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Extra")).FirstOrDefault();
                var skickad = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Skickad")).FirstOrDefault();
                var fardig = doc.Root.Elements("Row").Where(i => (string)i.Element("User") == loadklass).Where(i => (string)i.Element("Fardig") == "Unchecked").Select(i => (string)i.Element("Fardig")).FirstOrDefault();
                metroProgressBar1.Value = 80;
                txtSerienummer.Text = serienummer;
                if (fardig == "Unchecked") {
                    txtServicenummer.Text = servicenummer;
                    txtServicestalle.Text = servicestalle;
                    txtKontaktinformation.Text = kontaktinformation;
                
                    txtAnmalingsdatum.Text = anmalningsdatum;
                    txtLeveransdatum.Text = leveransdatum;
                    Felbeskrivning.Text = felbeskrivningValue;
                    Atgard.Text = atgardValue;
                    txtBoxExtra.Text = extra;
                    chkSkickad.CheckState = skickad == "Checked" ? CheckState.Checked : CheckState.Unchecked;
                    //if (Fardig == "Checked")
                    //    chkFardig.CheckState = CheckState.Checked;
                    //else chkFardig.CheckState = CheckState.Unchecked;

                    metroProgressBar1.Value = 100;
                }//Console.Write(loadklass);
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
            KlasserSettings frame = new KlasserSettings();
            //frmProdukter frame = new frmProdukter();
            frame.Show();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            FrmElever form = new FrmElever();
            form.Show();
        }

        private void txtAnmalingsdatum_Click(object sender, EventArgs e)
        {

            txtAnmalingsdatum.Text = GetTimestamp(DateTime.Now);
        }

        private void metroLabel15_Click(object sender, EventArgs e)
        {

        }
    }
}