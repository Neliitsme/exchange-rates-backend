using System.Xml.Serialization;

namespace exchange_rates_backend.Models;

[Serializable]
[XmlRoot("ValCurs")]
public class ValCursEntity
{
    [XmlAttribute("Date")] public string Date { get; set; }

    [XmlAttribute("name")] public string Name { get; set; }

    [XmlElement("Valute")] public List<ValuteEntity> Valutes { get; set; }

    public override string ToString()
    {
        return $"{Date} {Name}";
    }
}