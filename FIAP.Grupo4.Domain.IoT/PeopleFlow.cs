using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FIAP.Grupo4.Domain.IoT
{
    [DataContract]
    public class PeopleFlow
    {
        [DataMember]
        [JsonPropertyName("people_entered")]
        public int PeopleEntered { get; set; }

        [DataMember]
        [JsonPropertyName("people_left")]
        public int PeopleLeft { get; set; }

        [DataMember]
        [JsonPropertyName("people_stayed")]
        public int PeopleStayed { get; set; }

        [DataMember]
        [JsonPropertyName("wagon")]
        public int Wagon { get; set; }

        public PeopleFlow()
        {
        }

        public PeopleFlow(int peopleEntered, int peopleLeft, int peopleStayed, int wagon)
        {
            PeopleEntered = peopleEntered;
            PeopleLeft = peopleLeft;
            PeopleStayed = peopleStayed;
            Wagon = wagon;
        }
    }
}