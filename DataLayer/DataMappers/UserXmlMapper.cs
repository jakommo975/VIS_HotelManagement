using DomainLayer.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.DataMappers
{
    public class UserXmlMapper : IUserXmlMapper
    {
        public void SaveGuests(List<User> guests, string filePath)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                
                foreach (var guest in guests)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                    xmlSerializer.Serialize(stringWriter, guest);
                }
                File.WriteAllText(filePath + ".xml", stringWriter.ToString());
            }
        }
    }
}
