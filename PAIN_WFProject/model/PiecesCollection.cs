using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PAIN_WFProject.model
{
    [Serializable]
    [XmlRoot("pieces-collection")]
    public class PiecesCollection
    {
        public static readonly string[] Columns = {"Title", "Author", "Recording Date", "Category"};

        [XmlArray("pieces")]
        [XmlArrayItem("piece", typeof(Piece))]
        public Piece[] Pieces { get; set; }
    }
}
