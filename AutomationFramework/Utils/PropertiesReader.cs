using System.Reflection;
using System.Xml;

namespace AutomationFramework.Utils
{
    internal class PropertiesReader
    {

        public static string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string GetAssemblyFile(string fileName) => Path.Combine(AssemblyLocation, fileName);

        public static string GetProperty(string name, string xmlPath)
        {
            var doc = new XmlDocument();
            doc.Load(GetAssemblyFile(xmlPath));
            var node = doc.SelectSingleNode($"//property[@name='{name}']");
            return node?.Attributes["value"].Value ?? string.Empty;
        }
    }
}
