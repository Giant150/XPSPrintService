using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Fields;

namespace WordTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var doc = new Document();
            var section = doc.AddSection();
            var paragraph = section.AddParagraph();
            var f1 = new MergeField(doc);
            f1.Type = FieldType.FieldMergeField;
            f1.FieldName = "C1";
            paragraph.Items.Add(f1);
            doc.SaveToFile("t3.docx", FileFormat.Auto);
            doc.Close();
        }
    }
}
