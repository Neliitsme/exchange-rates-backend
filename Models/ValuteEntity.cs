using System.Xml.Serialization;

namespace exchange_rates_backend.Models;

[Serializable]
[XmlRoot("Valute")]
public class ValuteEntity
{
    [XmlAttribute("ID")] public string Id { get; set; }

    [XmlElement("NumCode")] public string NumCode { get; set; }

    [XmlElement("CharCode")] public string CharCode { get; set; }

    [XmlElement("Nominal")] public int Nominal { get; set; }

    [XmlElement("Name")] public string Name { get; set; }

    [XmlElement("Value")] public string Value { get; set; }

    public override string ToString()
    {
        return $"{Id} {NumCode} {CharCode} {Nominal} {Name} {Value}";
    }
}