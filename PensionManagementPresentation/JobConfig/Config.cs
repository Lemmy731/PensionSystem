using Hangfire;
using PensionManagementInfrastructure.CalculatessBenfit;
using PensionManagementInfrastructure.contribution;

namespace PensionManagementPresentation.JobConfig
{
    public  class Config
    {
        private readonly IValidateContribution _validateContribution;
        private readonly IBenefitEligiblity _benefitEligiblity;
        private readonly IMonthlyInterest _monthlyInterest;
        private readonly IGenerateStatement _generateStatement;


        public  Config(IValidateContribution validateContribution, IBenefitEligiblity benefitEligiblity, IMonthlyInterest monthlyInterest, IGenerateStatement generateStatement)
        {
                _validateContribution = validateContribution;  
                _benefitEligiblity = benefitEligiblity;
                _monthlyInterest = monthlyInterest;
                _generateStatement = generateStatement; 
        }
         public  void Configure()
         {
            RecurringJob.AddOrUpdate("validate-monthly-contributions",
                 () => _validateContribution.ValidateMonthlyContributions(), Cron.Monthly);

            RecurringJob.AddOrUpdate("update-benefit-eligibility",
                () => _benefitEligiblity.UpdateBenefitEligibility(), Cron.Weekly);

            RecurringJob.AddOrUpdate("calculate-interest",
                () => _monthlyInterest.CalculateMonthlyInterest(), Cron.Monthly);

            RecurringJob.AddOrUpdate("generate-statements",
                () => _generateStatement.GenerateAllStatements(), Cron.Monthly);
         }

    }
}
