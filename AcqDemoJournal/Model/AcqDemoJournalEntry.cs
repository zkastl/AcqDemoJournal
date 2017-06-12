using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AcqDemoJournal
{
    [DataContract]
    public class AcqDemoJournalEntry
    {
        [DataMember]
        public DateTime EntryDate { get; private set; }

        /// <summary>
        /// What was the contribution performed?
        /// </summary>
        [DataMember]
        public string EntryTextContribution { get; private set; }

        /// <summary>
        /// What was the result of this contribution?
        /// </summary>
        [DataMember]
        public string EntryTextResult { get; private set; }

        /// <summary>
        /// How did this impact my team?
        /// </summary>
        [DataMember]
        public string EntryTextImpact { get; private set; }

        [DataMember]
        public string Comments { get; private set; }

        [DataMember]
        public List<ContributionFactors> EntryFactors;

        [DataMember]
        public string ContributionTextFull { get; private set; }
        
        public AcqDemoJournalEntry(string contribution, string result, string impact, string comments, List<ContributionFactors> factors = null)
        {
            EntryDate = DateTime.Now;
            EntryTextContribution = contribution;
            EntryTextResult = result;
            EntryTextImpact = impact;
            Comments = comments;
            EntryFactors = factors ?? new List<ContributionFactors>();
            ContributionTextFull = string.Concat(EntryTextContribution, EntryTextResult, EntryTextImpact);
        }

    }

    public enum ContributionFactors
    {
        ProblemSolving = 1,
        TeamworkAndCooperation = 2,
        CustomerRelations = 4,
        LeadershipAndSupervision = 8,
        Communication = 16,
        ResourceManagment = 32
    }
}
