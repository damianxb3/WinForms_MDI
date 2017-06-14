using System.IO;
using System.Xml.Serialization;

namespace PAIN_WFProject.model.helper
{
    class PiecesXmlHelper
    {
        public XmlSerializer Serializer { get; }
        private const string Path = "../../model/pieces.xml";

        public PiecesXmlHelper()
        {
            Serializer = new XmlSerializer(typeof(PiecesCollection));
        }

        public PiecesCollection Deserialize()
        {
            StreamReader reader = new StreamReader(Path);
            PiecesCollection pieces = (PiecesCollection) Serializer.Deserialize(reader);
            reader.Close();
            return pieces;
        }

        public void Serialize(PiecesCollection pieces)
        {
            StreamWriter writer = new StreamWriter(Path);
            Serializer.Serialize(writer, pieces);
            writer.Close();
        }
    }
}
