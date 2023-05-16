using System;
using System.Configuration;
using System.Xml;
namespace SysBasicClass
{
	public class ConfigHelper
	{
		public static string GetAppSettings(string key)
		{
			return ConfigurationManager.AppSettings[key].ToString().Trim();
		}
		public static void SetValue(XmlDocument xmlDocument, string selectPath, string key, string keyValue)
		{
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
				{
					xmlNode.Attributes["value"].Value = keyValue;
					break;
				}
			}
		}
        /// <summary>
        /// 获取固定配置文件参数config.xml
        /// </summary>
        /// <param name="XmlNodeName"></param>
        /// <returns></returns>
        public static string GetXMLNodeData(string XmlNodeName)
        {
            string XmlNodeValue = "";
            string strAssemblyFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            String strAssemblyDirPath = System.IO.Path.GetDirectoryName(strAssemblyFilePath);
            String FilePath = strAssemblyDirPath + "\\config.xml";

            try
            {
                XmlDocument lXmlDocument = new XmlDocument();
                if (System.IO.File.Exists(FilePath))
                {
                    lXmlDocument.Load(FilePath);
                    XmlNodeList lXmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes;
                    XmlNode xn;
                    int i = 0;
                    for (i = 0; i < lXmlNodeList.Count; i++)
                    {
                        xn = lXmlNodeList.Item(i);
                        if (xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()))
                        {
                            XmlNodeValue = xn.InnerText;
                        }
                    }
                }
                else
                {
                    XmlElement lXmlNode = lXmlDocument.CreateElement("Info");
                    XmlElement lChildXmlElement = null;
                    lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName);
                    lChildXmlElement.InnerText = XmlNodeValue;
                    lXmlNode.AppendChild(lChildXmlElement);
                    lXmlDocument.AppendChild(lXmlNode);
                    lXmlDocument.Save(FilePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return XmlNodeValue;
        }
        /// <summary>
        /// 设置固定配置文件参数config.xml
        /// </summary>
        /// <param name="XmlNodeName"></param>
        /// <param name="XmlNodeValue"></param>

        public static void SetXMLNodeData(String XmlNodeName, String XmlNodeValue)
        {
            String strAssemblyFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            String strAssemblyDirPath = System.IO.Path.GetDirectoryName(strAssemblyFilePath);
            String FilePath = strAssemblyDirPath + "\\config.xml";
            XmlDocument lXmlDocument = new XmlDocument();
            try
            {
                if (System.IO.File.Exists(FilePath))
                {
                    Boolean IsExistsNode = false;
                    lXmlDocument.Load(FilePath);
                    XmlNodeList lXmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes;
                    foreach (XmlNode xn in lXmlNodeList)
                    {
                        if (xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()))
                        {
                            xn.InnerText = XmlNodeValue;
                            IsExistsNode = true;
                            continue;
                        }
                    }
                    if (!IsExistsNode)
                    {
                        XmlElement lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName);
                        lChildXmlElement.InnerText = XmlNodeValue;
                        lXmlDocument.SelectSingleNode("Info").AppendChild(lChildXmlElement);
                    }
                    lXmlDocument.Save(FilePath);
                }
                else
                {
                    XmlElement lXmlNode = lXmlDocument.CreateElement("Info");
                    XmlElement lChildXmlElement = null;
                    lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName);
                    lChildXmlElement.InnerText = XmlNodeValue;
                    lXmlNode.AppendChild(lChildXmlElement);
                    lXmlDocument.AppendChild(lXmlNode);
                    lXmlDocument.Save(FilePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
