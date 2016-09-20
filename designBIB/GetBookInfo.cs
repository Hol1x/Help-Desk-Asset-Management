using System.Linq;
using System.Xml.Linq;

namespace designBIB
{
    class GetBookInfo
    {
        public string Id(string bok) {
            var xmlfile = "‪/Bok2.xml";
            var doc = XDocument.Load(xmlfile);
            //var node = doc.Descendants().Where(n => n.Value == metroTextBox1.Text);
            //metroComboBox2.DataSource = node.ToList();
            var itemType = doc.Root?.Elements("bok").Elements("recorde")
                   .Where(i => (string)i.Element("nummer") == bok)
                   .Where(i => (string)i.Element("InUse") == "no")
                   .Select(i => (string)i.Element("title"))

                   .FirstOrDefault();
            return itemType;
        }
    }
}
