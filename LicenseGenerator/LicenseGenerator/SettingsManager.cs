using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LicenseGenerator
{
    class SettingsManager : IEnumerable<XElement>
    {
        List<XElement> myList = new List<XElement>();
        public SettingsManager this[int index]
        {
            get { return myList[index]; }
            set { myList.Insert(index, XElement)\; }
        }
        private XDocument currentDocument = new XDocument();
        public bool saveData(string path)
        {
            try
            {
                XDocument currentDocument = new XDocument();
                currentDocument.Save(path);
            }
            catch(Exception e)
            {
                return false;
            }

            return false;
        }
        public void printAll()
        {
            foreach(var element in currentDocument.Element("date").Element("KeyGenerator").Elements())
            {
                MessageBox.Show(element.Name.LocalName);
            }
        }

        public XElement addData(XElement data)
        {
            currentDocument.Element("date").Add(data);

            return currentDocument.Elements();
        }

        public static XElement loadData(string path)
        {
            XElement document = XElement.Load(path);

            return document;
        }

        public IEnumerator<XElement> GetEnumerator()
        {
            foreach(var element in currentDocument.Elements())
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
