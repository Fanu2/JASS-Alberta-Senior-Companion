using JASS.AlbertaSeniorCompanion.Models;

namespace JASS.AlbertaSeniorCompanion.Services;

public static class OfficialLinks
{
    public static readonly List<ResourceLink> All = new()
    {
        new("Alberta Seniors Benefit", "https://www.alberta.ca/alberta-seniors-benefit", "Benefits"),
        new("Seniors Financial Assistance Programs", "https://www.alberta.ca/seniors-financial-assistance", "Benefits"),
        new("Financial Assistance for Seniors", "https://www.alberta.ca/financial-assistance-for-seniors", "Benefits"),
        new("Seniors Health Benefits", "https://www.alberta.ca/seniors-health-benefits", "Health"),
        new("Coverage for Seniors", "https://www.alberta.ca/coverage-for-seniors-program", "Health"),
        new("Health Link 811", "https://myhealth.alberta.ca/811", "Health"),
        new("Alberta Supports", "https://www.alberta.ca/alberta-supports", "Contacts"),
        new("Emergency Numbers", "https://www.alberta.ca/emergency-numbers", "Emergency"),
        new("Emergency Financial Assistance", "https://www.alberta.ca/emergency-financial-assistance", "Emergency"),
        new("SHARP — Home Adaptation & Repair", "https://www.alberta.ca/seniors-home-adaptation-repair-program", "Housing"),
        new("SHARP Grant", "https://www.alberta.ca/sharp-grant", "Housing"),
        new("Seniors Property Tax Deferral", "https://www.alberta.ca/seniors-property-tax-deferral-program.aspx", "Housing"),
        new("SHARP Loan Estimator", "https://www.seniors.alberta.ca/sharp-loan-calculator", "Housing"),
        new("Property Tax Deferral Loan Estimator", "https://www.seniors.alberta.ca/property-tax-loan-calculator", "Housing"),
        new("Canada Benefits Finder", "https://www.canada.ca/en/services/benefits/finder.html", "CRA & Tax"),
        new("CRA — Keep Your Account Secure", "https://www.canada.ca/en/revenue-agency/corporate/scams-fraud/protect-account.html", "CRA & Tax"),
        new("CRA — Recognize a Scam", "https://www.canada.ca/en/revenue-agency/corporate/scams-fraud/recognize-scam.html", "Safety"),
        new("CRA — Direct Deposit", "https://www.canada.ca/en/revenue-agency/services/about-canada-revenue-agency-cra/direct-deposit/individuals.html", "CRA & Tax"),
        new("CRA My Account", "https://www.canada.ca/en/revenue-agency/services/e-services/e-services-individuals/account-individuals.html", "CRA & Tax")
    };
}
