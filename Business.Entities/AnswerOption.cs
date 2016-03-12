using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class AnswerOption : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Option { get; set; }
        [DataMember]
        public int NumberOfVotes { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int QuestionnaireId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}