using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlCreator
{
    /// <summary>
    /// The class that will generate the XML-file.
    /// </summary>
    public abstract class XmlCreator
    {
        private string _fileName;
        private string _filePath;

        private XDocument _xmlDocument;

        /// <summary>
        /// The name of the file.
        /// </summary>
        public String SafeFileName => _fileName;

        /// <summary>
        /// The name of the file with the complete file-path.
        /// </summary>
        public String FullFileName => _filePath;

        /// <summary>
        /// The XML-document itself.
        /// </summary>
        public XDocument XmlDocument => _xmlDocument;

        /// <summary>
        /// Create and/or load an XML-file to/from the local AppData-folder.
        /// </summary>
        /// <param name="fileName">The name of the XML-file that needs to be generated/used.</param>
        public XmlCreator(string fileName)
            : this (fileName, String.Empty)
        {
            
        }

        /// <summary>
        /// Create and/or load an XML-file to/from a specific file-path.
        /// </summary>
        /// <param name="fileName">The name of the XML-file that needs to be generated/used.</param>
        /// <param name="filePath">The full path for the XML-file.</param>
        public XmlCreator(string fileName, string filePath)
        {
            _fileName = fileName;

            if (String.IsNullOrWhiteSpace(filePath))
            {
                filePath = GetDefaultFilePath();
                _filePath = filePath;
            }
            else
            {
                _filePath = Path.Combine(filePath, fileName);
            }

            if (!File.Exists(_filePath))
            {
                _xmlDocument = new XDocument();
                var xml = CreateDefaultXElement();
                _xmlDocument.Add(xml);
                _xmlDocument.Save(_filePath);
            }
            else
            {
                _xmlDocument = XDocument.Load(_filePath);
            }
        }

        /// <summary>
        /// Generate the string-value for the local AppData-folder.
        /// </summary>
        /// <returns>The full path to the local AppData-folder.</returns>
        private string GetDefaultFilePath()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string configurationFileDirectory = Path.Combine(localAppData, "XmlCreator");

            if (!Directory.Exists(configurationFileDirectory)) Directory.CreateDirectory(configurationFileDirectory);

            return Path.Combine(configurationFileDirectory, _fileName);
        }

        /// <summary>
        /// Create a single default element for the XML-document.
        /// </summary>
        /// <returns>An XML-element. This may contain elements of its own.</returns>
        protected abstract XElement CreateDefaultXElement();
    }
}
