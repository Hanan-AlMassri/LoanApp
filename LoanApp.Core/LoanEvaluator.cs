using System.Data;
using System.Runtime.InteropServices;

namespace LoanApp
{
    public class LoanEvaluator
    {
        // الكود قبل التحسين
        /*  public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
            {
                if (income < 2000)
                    return "Not Eligible";
                if (hasJob)
                {
                    if (creditScore >= 700)
                    {
                        if (dependents == 0)
                            return "Eligible";
                        else if (dependents <= 2)
                            return "Review Manually";
                        else
                            return "Not Eligible";
                    }
                    else if (creditScore >= 600)
                    {
                        if (ownsHouse)
                            return "Review Manually";
                        else
                            return "Not Eligible";
                    }
                    else
                    {
                        return "Not Eligible";
                    }
                }
                else
                {
                    if (creditScore >= 750 && income > 5000 && ownsHouse)
                        return "Eligible";
                    else if (creditScore >= 650 && dependents == 0)
                        return "Review Manually";
                    else
                        return "Not Eligible";
                }
            }*/

        // الكود بعد التحسين
        public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
        {
            if (!HasMinimumIncome(income))
                return "Not Eligible";
            if (hasJob)
                return EvaluateEmployed(creditScore, dependents, ownsHouse);
            else
                return EvaluateUnemployed(creditScore, income, dependents, ownsHouse);
        }
        private bool HasMinimumIncome(int income) => income >= 2000;
        private string EvaluateEmployed(int creditScore, int dependents, bool ownsHouse)
        {   if (creditScore >= 700)
            {   if (dependents == 0)
                    return "Eligible";
                else if (dependents <= 2)
                    return "Review Manually";
                else
                    return "Not Eligible";}
            if (creditScore >= 600)
                return ownsHouse ? "Review Manually" : "Not Eligible";
            return "Not Eligible";}
        private string EvaluateUnemployed(int creditScore, int income, int dependents, bool ownsHouse)
        {
            if (creditScore >= 750 && income > 5000 && ownsHouse)
                return "Eligible";
            else if (creditScore >= 650 && dependents == 0)
                return "Review Manually";

            else return "Not Eligible";
        }
    }
}

