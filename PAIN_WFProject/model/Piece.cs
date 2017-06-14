using System;

namespace PAIN_WFProject.model
{
    [Serializable]
    public class Piece
    {
        [System.Xml.Serialization.XmlElement("title")]
        public string Title { get; set; }
        [System.Xml.Serialization.XmlElement("author")]
        public string Author { get; set; }
        [System.Xml.Serialization.XmlElement("recording-date")]
        public string RecordingDate { get; set; }
        [System.Xml.Serialization.XmlElement("category")]
        public string Category { get; set; }
    }
}
