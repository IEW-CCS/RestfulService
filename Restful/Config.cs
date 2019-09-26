using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Restful
{
    public class Config
    {
        private string _strConfigPath = string.Empty;
        private Dictionary<string, Dictionary<string, string>> _dicConfigSetting = new Dictionary<string, Dictionary<string, string>>();
        public Config(string configpath)
        {

            _strConfigPath = configpath;
            try
            {
                Load_Xml_Config(_strConfigPath);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Load System Conf error Configpath : {0}, Error Msg {1}].", _strConfigPath, ex.Message));
            }
        }

        private void Load_Xml_Config(string configpath)
        {
            if (File.Exists(configpath))
            {
                try
                {
                    _dicConfigSetting.Clear();

                    XElement xmlconfigfile = XElement.Load(configpath);

                    foreach (XElement xmlsection in xmlconfigfile.Elements())
                    {
                        Dictionary<string, string> tmp = new Dictionary<string, string>();
                        foreach (var el in xmlsection.Elements())
                        {
                            tmp.Add(el.Name.LocalName, el.Value);
                        }
                        _dicConfigSetting.Add(xmlsection.Name.LocalName, tmp);

                    }

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            else
            {
                throw new Exception("Config File Not Exist");
            }

        }

        public string GetConfig(string section, string key)
        {

            string _value = string.Empty;
            string _rtnvalue = string.Empty;
            Dictionary<string, string> _tmpdic = new Dictionary<string, string>();
            if (_dicConfigSetting.TryGetValue(section, out _tmpdic))
            {
                if (_tmpdic != null)
                {
                    if (_tmpdic.TryGetValue(key, out _value))
                    {
                        _rtnvalue = _value;
                    }
                }
            }
            return _rtnvalue;
        }
    }
}
