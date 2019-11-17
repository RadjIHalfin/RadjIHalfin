using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace _4936U_XmlCheck
{
    public partial class MainForm : Form
    {
        String fileName = "";
        XmlSchemaSet schemaSet = null;
        XmlSchema sko115fzOPERXsd = null;
        XmlSchema sko115fz03Xsd = null;
        XmlSchema sko115fz04Xsd = null;
        static bool isValid;

        public MainForm()
        {

            InitializeComponent();
            FileTypeCBox.SelectedIndex = 0;
        }

        private void FileOpenBtn_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
            XmlFileFullPathTextBox.Text = "";
            FileTypeCBox.SelectedIndex = 0;
            fileName = "";

            OpenFileDialog.FileName = fileName;

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = OpenFileDialog.FileName;

                XmlFileFullPathTextBox.Text = fileName;
                //это для прокрутки текста. чтобы файл, а не путь оставался видимым.
                XmlFileFullPathTextBox.SelectionStart = fileName.Length;
                XmlFileFullPathTextBox.ScrollToCaret();


                //определим тип
                //Пример имени: путь\SKO115FZ_01_049205703_20191115_000001.xml
                // /.*\/SKO115FZ_(?<type>\d{2})_049205703_\d{8}_\d{6}\.xml/
                Regex regex = new Regex(@".*\\SKO115FZ_(?<type>\d{2})_049205703_\d{8}_\d{6}\.xml");
                Match match = regex.Match(fileName);
                if (!match.Success)
                {
                    FileTypeCBox.SelectedIndex = 0;
                }
                else
                {
                    switch (match.Groups["type"].Value)
                    {
                        case "01": FileTypeCBox.SelectedIndex = 1; break;
                        case "03": FileTypeCBox.SelectedIndex = 2; break;
                        case "04": FileTypeCBox.SelectedIndex = 3; break;
                        default: FileTypeCBox.SelectedIndex = 0; break;
                    }
                }
            }
            else
            {

                if (OpenFileDialog.FileName != "")
                {
                    MessageBox.Show("Необходимо выбрать файл");
                }
            }
        }

        private void CheckXmlBtn_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.FileName == "")
            {
                MessageBox.Show("Необходимо выбрать файл");
                return;
            }
            else
            if (FileTypeCBox.SelectedIndex < 1)
            {
                MessageBox.Show("Необходимо указать тип файла");
                return;
            }

            if (CheckXml(fileName))
            {
                ResultTextBox.BackColor = ResultTextBox.BackColor; //без этого смена цвета (ResultTextBox.ForeColor) не сработает
                ResultTextBox.ForeColor = Color.Green;
                ResultTextBox.Text = "Соответствует схеме";
            }
            else
            {
                ResultTextBox.BackColor = ResultTextBox.BackColor; //без этого смена цвета (ResultTextBox.ForeColor) не сработает
                ResultTextBox.ForeColor = Color.Red;
                ResultTextBox.Text = "Не соответствует схеме";
            }

        }

        private bool CheckXml(String fileName)
        {
            XmlSchemaSet schemaSet = GetSchemaSet();

            switch(FileTypeCBox.SelectedIndex)
            {
                case 1:
                    return CheckWithSchemaXml(fileName, sko115fzOPERXsd);
                case 2:
                    return CheckWithSchemaXml(fileName, sko115fz03Xsd);
                case 3:
                    return CheckWithSchemaXml(fileName, sko115fz04Xsd);
            }

            return false;
        }

        private bool CheckWithSchemaXml(String fileName, XmlSchema xsd)
        {
            XmlReaderSettings xmlFile = new XmlReaderSettings();
            xmlFile.Schemas.Add(xsd);
            xmlFile.ValidationType = ValidationType.Schema;
            xmlFile.ValidationEventHandler += new ValidationEventHandler(xmlFileValidationEventHandler);

            XmlReader xmlFileReader = XmlReader.Create(fileName, xmlFile);

            isValid = true;
            try { 
                while (xmlFileReader.Read()) { }
            } catch
            {
                isValid = false;
            }

            return isValid;

        }

        static void xmlFileValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                isValid = false;
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                isValid = false;
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }
        }

        private XmlSchemaSet GetSchemaSet()
        {
            if (schemaSet != null)
            {
                return schemaSet;
            }

            schemaSet = new XmlSchemaSet();

            XmlSchema dataTypesXsd = schemaSet.Add(null, GetXmlResource("data_types.xsd"));
            sko115fzOPERXsd = schemaSet.Add(null, GetXmlResource("SKO115FZ_OPER.xsd"));
            sko115fz03Xsd = schemaSet.Add(null, GetXmlResource("SKO115FZ_03.xsd"));
            sko115fz04Xsd = schemaSet.Add(null, GetXmlResource("SKO115FZ_04.xsd"));

            XmlSchemaInclude includeDataTypes = new XmlSchemaInclude();
            includeDataTypes.Schema = dataTypesXsd;

            sko115fzOPERXsd.Includes.Add(includeDataTypes);
            sko115fz03Xsd.Includes.Add(includeDataTypes);
            sko115fz04Xsd.Includes.Add(includeDataTypes);

            schemaSet.Add(sko115fzOPERXsd);
            schemaSet.Add(sko115fz03Xsd);
            schemaSet.Add(sko115fz04Xsd);

            return schemaSet;
        }

        private XmlReader GetXmlResource(String xmlResourceName)
        {
            String resourceName = typeof(MainForm).Assembly.GetManifestResourceNames().Single(str => str.EndsWith("." + xmlResourceName));
            Stream resourceStream = typeof(MainForm).Assembly.GetManifestResourceStream(resourceName);

            {
                if (resourceStream == null)
                {
                    throw new FileLoadException("Ошибка загрузки файла из ресурсов.", resourceName);
                    //return null;
                }

                return XmlReader.Create(resourceStream);
            }
        }

    }
}
