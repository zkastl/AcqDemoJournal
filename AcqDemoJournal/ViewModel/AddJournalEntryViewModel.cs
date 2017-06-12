using System;
using System.Collections.Generic;
using System.Windows.Input;
using Utilities;

namespace AcqDemoJournal.ViewModel
{
    public class AddJournalEntryViewModel : ProtoBind
    {        
        public string ContributionText
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public string ResultText
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public string ImpactText
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public string CommentText
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public string ErrorText
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public bool ProblemSolvingCB
        {
            get { return ObservableGet<bool>(); }
            set { ObservableSet(value); }
        }
        public bool TeamworkAndCooperationCB
        {
            get { return ObservableGet<bool>(); }
            set { ObservableSet(value); }
        }
        public bool CustomerRelationsCB
        {
            get { return ObservableGet<bool>(); }
            set { ObservableSet(value); }
        }
        public bool LeadershipAndSupervisionCB
        {
            get { return ObservableGet<bool>(); }
            set { ObservableSet(value); }
        }
        public bool CommunicationCB
        {
            get { return ObservableGet<bool>(); }
            set { ObservableSet(value); }
        }
        public bool ResourceManagmentCB
        {
            get { return ObservableGet<bool>(); }
            set { ObservableSet(value); }
        }
        public ICommand AddEntryCommand { get; set; }

        private string defaultSerializedPath = @".\serializedJournal.jrl";

        public AddJournalEntryViewModel()
        {
            ProblemSolvingCB = TeamworkAndCooperationCB = 
            CustomerRelationsCB = LeadershipAndSupervisionCB =
            CommunicationCB = ResourceManagmentCB = false;

            AddEntryCommand = new ProtoSyncCommand(WriteEntryToXml);
        }

        private void WriteEntryToXml()
        {
            if (InvalidJournalEntry())
            {
                ErrorText = "Invalid Journal Entry";
                return;
            }

            AssessmentPeriod asp = SerializationUtilities.DeserializeContract<AssessmentPeriod>(defaultSerializedPath) ??
                new AssessmentPeriod(DateTime.Now, new DateTime(2017, 12, 31, 11, 59, 59), 67, "No plan; just wingin' it.");


            asp.PeriodEntries.Add(new AcqDemoJournalEntry(ContributionText, ResultText, ImpactText, null, GetFactors()));
            asp.SerializeContract(defaultSerializedPath);

            ClearView();
        }

        private bool InvalidJournalEntry()
        {
            return
                string.IsNullOrEmpty(ContributionText) ||
                string.IsNullOrEmpty(ResultText) ||
                string.IsNullOrEmpty(ImpactText) ||
                !(CommunicationCB || CustomerRelationsCB || LeadershipAndSupervisionCB ||
                ProblemSolvingCB || ResourceManagmentCB || TeamworkAndCooperationCB);
        }

        private void ClearView()
        {            
            ContributionText = ResultText = ImpactText = ErrorText = string.Empty;
            ProblemSolvingCB = TeamworkAndCooperationCB =
            CustomerRelationsCB = LeadershipAndSupervisionCB =
            CommunicationCB = ResourceManagmentCB = false;
        }

        private List<ContributionFactors> GetFactors()
        {
            List<ContributionFactors> factors = new List<ContributionFactors>();

            if (ProblemSolvingCB)
                factors.Add(ContributionFactors.ProblemSolving);
            if (TeamworkAndCooperationCB)
                factors.Add(ContributionFactors.TeamworkAndCooperation);
            if (CustomerRelationsCB)
                factors.Add(ContributionFactors.CustomerRelations);
            if (LeadershipAndSupervisionCB)
                factors.Add(ContributionFactors.LeadershipAndSupervision);
            if (CommunicationCB)
                factors.Add(ContributionFactors.Communication);
            if (ResourceManagmentCB)
                factors.Add(ContributionFactors.ResourceManagment);

            return factors;
        }
    }
}
