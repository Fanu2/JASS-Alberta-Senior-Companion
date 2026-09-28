using System.Diagnostics;
using System.Windows;
using JASS.AlbertaSeniorCompanion.Models;
using JASS.AlbertaSeniorCompanion.Services;

namespace JASS.AlbertaSeniorCompanion.Views;

public partial class MainWindow : Window
{
    private List<ChecklistItem> _checklist = AppData.LoadChecklist();

    public MainWindow()
    {
        InitializeComponent();
        ChecklistList.ItemsSource = _checklist;
        ResourcesList.ItemsSource = OfficialLinks.All;
        MaritalBox.SelectedIndex = 0;
    }

    private void Open(string url)
    {
        try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
        catch { MessageBox.Show("Windows could not open the official web page.", "JASS", MessageBoxButton.OK, MessageBoxImage.Information); }
    }

    private void SelectTab(System.Windows.Controls.TabItem tab) => tab.IsSelected = true;

    private void Emergency_Click(object s, RoutedEventArgs e) => SelectTab(EmergencyTab);
    private void Benefits_Click(object s, RoutedEventArgs e) => SelectTab(BenefitsTab);
    private void Health_Click(object s, RoutedEventArgs e) => SelectTab(HealthTab);
    private void Tax_Click(object s, RoutedEventArgs e) => SelectTab(TaxTab);
    private void Safety_Click(object s, RoutedEventArgs e) => SelectTabByHeader("🛡️ Scam Protection");
    private void Checklist_Click(object s, RoutedEventArgs e) => SelectTab(ChecklistTab);

    private void SelectTabByHeader(string header)
    {
        if (Content is System.Windows.Controls.Grid grid && grid.Children.Count > 1)
        {
            var tabs = grid.Children.OfType<System.Windows.Controls.TabControl>().FirstOrDefault();
            var item = tabs?.Items.OfType<System.Windows.Controls.TabItem>().FirstOrDefault(x => x.Header?.ToString() == header);
            if (item != null) item.IsSelected = true;
        }
    }

    private void Call911_Click(object s, RoutedEventArgs e) =>
        MessageBox.Show("For an immediate danger or life-threatening emergency, call 911.", "Emergency", MessageBoxButton.OK, MessageBoxImage.Warning);

    private void Health811_Click(object s, RoutedEventArgs e) => Open("https://myhealth.alberta.ca/811");
    private void IncomeEmergency_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/emergency-financial-assistance");
    private void Fire_Click(object s, RoutedEventArgs e) => MessageBox.Show("Wildfire reporting: 310-FIRE (3473), available 24/7.", "Wildfire", MessageBoxButton.OK, MessageBoxImage.Information);
    private void EmergencyNumbers_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/emergency-numbers");

    private void Coverage_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/coverage-for-seniors-program");
    private void SeniorsHealth_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/seniors-health-benefits");
    private void AlbertaSupports_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/alberta-supports");

    private void ASB_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/alberta-seniors-benefit");
    private void SeniorsFinancial_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/seniors-financial-assistance");
    private void Financial_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/financial-assistance-for-seniors");

    private void BenefitsFinder_Click(object s, RoutedEventArgs e) => Open("https://www.canada.ca/en/services/benefits/finder.html");
    private void DirectDeposit_Click(object s, RoutedEventArgs e) => Open("https://www.canada.ca/en/revenue-agency/services/about-canada-revenue-agency-cra/direct-deposit/individuals.html");
    private void CRAMyAccount_Click(object s, RoutedEventArgs e) => Open("https://www.canada.ca/en/revenue-agency/services/e-services/e-services-individuals/account-individuals.html");
    private void CRAProtect_Click(object s, RoutedEventArgs e) => Open("https://www.canada.ca/en/revenue-agency/corporate/scams-fraud/protect-account.html");
    private void CRAScam_Click(object s, RoutedEventArgs e) => Open("https://www.canada.ca/en/revenue-agency/corporate/scams-fraud/recognize-scam.html");

    private void Sharp_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/seniors-home-adaptation-repair-program");
    private void SharpGrant_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/sharp-grant");
    private void TaxDeferral_Click(object s, RoutedEventArgs e) => Open("https://www.alberta.ca/seniors-property-tax-deferral-program.aspx");
    private void SharpEstimator_Click(object s, RoutedEventArgs e) => Open("https://www.seniors.alberta.ca/sharp-loan-calculator");
    private void TaxEstimator_Click(object s, RoutedEventArgs e) => Open("https://www.seniors.alberta.ca/property-tax-loan-calculator");

    private void RunBenefits_Click(object s, RoutedEventArgs e)
    {
        if (!int.TryParse(AgeBox.Text, out var age)) { BenefitsResult.Text = "Enter a valid age."; return; }
        if (!decimal.TryParse(IncomeBox.Text, out var income)) { BenefitsResult.Text = "Enter a valid approximate annual income."; return; }

        var results = new List<string>();
        if (age >= 65 && AlbertaBox.IsChecked == true && CitizenBox.IsChecked == true)
        {
            results.Add("• Alberta Seniors Benefit — investigate eligibility.");
            results.Add("• Coverage for Seniors — investigate health coverage.");
            results.Add("• Dental and Optical Assistance — investigate eligibility.");
            results.Add("• Special Needs Assistance — investigate if relevant.");
            results.Add("• Seniors financial-assistance application — review whether several programs can be applied for together.");
        }
        if (age >= 65 && AlbertaBox.IsChecked == true)
        {
            results.Add("• Seniors Property Tax Deferral — investigate if you own your primary residence.");
            results.Add("• SHARP — investigate if home repairs/adaptations are needed.");
        }
        if (age >= 60)
            results.Add("• Canada Benefits Finder — check federal retirement and senior supports.");

        if (age >= 65 && OasBox.IsChecked == true && income > 0)
            results.Add("• Compare your income with the current Alberta Seniors Benefit guidance before applying.");

        BenefitsResult.Text = results.Count == 0
            ? "Based on these inputs, no program can be suggested by this simple screener. Review the official Benefits Finder and Alberta resources."
            : string.Join("\n", results) + "\n\nThis is only a screening aid. Confirm eligibility with the official program.";
    }

    private void SaveChecklist_Click(object s, RoutedEventArgs e)
    {
        AppData.SaveChecklist(_checklist);
        MessageBox.Show("Checklist saved locally.", "JASS", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ResetChecklist_Click(object s, RoutedEventArgs e)
    {
        if (MessageBox.Show("Reset all checklist items?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _checklist = AppData.LoadChecklist();
            foreach (var item in _checklist) item.Done = false;
            ChecklistList.ItemsSource = null;
            ChecklistList.ItemsSource = _checklist;
            AppData.SaveChecklist(_checklist);
        }
    }

    private void ResourceSearchChanged(object s, System.Windows.Controls.TextChangedEventArgs e)
    {
        var q = ResourceSearchBox.Text.Trim();
        ResourcesList.ItemsSource = string.IsNullOrWhiteSpace(q)
            ? OfficialLinks.All
            : OfficialLinks.All.Where(x => x.Title.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                                           x.Category.Contains(q, StringComparison.OrdinalIgnoreCase));
    }

    private void OpenResource_Click(object s, RoutedEventArgs e)
    {
        if (ResourcesList.SelectedItem is ResourceLink link) Open(link.Url);
    }
}
