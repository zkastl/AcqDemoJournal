using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace AcqDemoJournal
{
    [DataContract]
    class AssessmentPeriod
    {
        [DataMember]
        public DateTime PeriodBegin { get; set; }

        [DataMember]
        public DateTime PeriodEnd { get; set; }

        [DataMember]
        public int TargetScore { get; set; }

        [DataMember]
        public string ContributionPlan { get; set; }

        [DataMember]
        public List<AcqDemoJournalEntry> PeriodEntries { get; set; }

        public AssessmentPeriod(DateTime begin, DateTime end, int score, string plan)
        {
            PeriodBegin = begin;
            PeriodEnd = end;
            TargetScore = score;
            ContributionPlan = plan;
            PeriodEntries = new List<AcqDemoJournalEntry>();
        }
    }
}
