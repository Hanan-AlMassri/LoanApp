using Xunit;
using LoanApp;

namespace LoanApp.Tests
{
    public class LoanEvaluatorFacts
    {
        //اختبار قبل التحسين 
        /*[Fact]
        public void GetLoanEligibility_Should_Return_NotEligible_When_Income_Low()
        {
        var evaluator = new LoanEvaluator();
        var result = evaluator.GetLoanEligibility(1500, true, 800, 5, true);
        Assert.Equal("Not Eligible", result);
        }*/

        // اختبارات بعد التحسين
        // (income<2000)حالة دخل منخفض
        
        [Fact] //TC1
        public void Employed_LowIncome_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(1500, true, 700, 1, true);
            Assert.Equal("Not Eligible", result);
        }

         // ==== حالات الموظف (hasJob = true) ====

        [Fact] // TC2
        public void HighIncome_Employed_MidCredit_NoDependents_ReturnsEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(2000, true, 700, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact] // TC3
        public void HighIncome_Employed_MidCredit_OneDependent_ReturnsReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, true, 700, 1, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact] // TC4
        public void HighIncome_Employed_MidCredit_MoreThan2Dependents_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, true, 700, 3, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact] // TC5
        public void HighIncome_Employed_MidCredit_OwnsHouse_ReturnsReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, true, 650, 1, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact] // TC6
        public void HighIncome_Employed_MidCredit_NotOwnHouse_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, true, 650, 1, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact] // TC7
        public void HighIncome_Employed_LowCredit_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(8000, true, 550, 0, false);
            Assert.Equal("Not Eligible", result);
        }

        // ==== حالات غير الموظف (hasJob = false) ====

        [Fact] // TC8
        public void HighIncome_Unemployed_HighCredit_OwnsHouse_ReturnsEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 750, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact] // TC9: غير موظف - دخل أقل بقليل من المطلوب
        public void NearThresholdIncome_Unemployed_HighCredit_NoDependents_OwnsHouse_ReturnsReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(4999, false, 750, 0, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact] // TC10
        public void HighIncomeMoreThan5000_Unemployed_HighCredit_WithDependents_NotOwnsHouse_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 750, 5, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact] // TC11
        public void HighIncome_Unemployed_HighCredit_NoDependents_NotOwnsHouse_ReturnsReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 750, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact] // TC12
        public void HighIncome_Unemployed_HighCredit_OneDependent_NotOwnsHouse_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 750, 1, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact] // TC13
        public void HighIncome_Unemployed_MidCredit_NoDependent_NotOwnsHouse_ReturnsReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 700, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact] // TC14
        public void HighIncome_Unemployed_MidCredit_WithDependents_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6500, false, 650, 2, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact] // TC15
        public void HighIncome_Unemployed_LowCredit_ReturnsNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(7000, false, 600, 3, false);
            Assert.Equal("Not Eligible", result);
        }

    }
    }

