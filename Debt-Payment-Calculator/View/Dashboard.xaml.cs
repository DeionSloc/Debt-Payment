using Debt_Payment_Calculator.Model;
using Debt_Payment_Calculator.Service;

namespace Debt_Payment_Calculator.View;

public partial class Dashboard : ContentPage
{
    private readonly DatabaseService _dbService;
    private int _editDebtId;


	public Dashboard(DatabaseService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listView.ItemsSource = await _dbService.GetDebtPayments());
	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (_editDebtId == 0)
        {
            //Adds new debt
            await _dbService.Create(new DebtPayment
            {
                Lender = lender.Text,
                OriginalAmount = originalAmount.Text,
                CurrentAmount = currentAmount.Text,
                Payment = payment.Text,
                PercentageRate = percentageRate.Text
            });
        }
        else
        {
            // Edit debt
            await _dbService.Update(new DebtPayment
            {
                Id = _editDebtId,
                Lender = lender.Text,
                OriginalAmount = originalAmount.Text,
                CurrentAmount = currentAmount.Text,
                Payment = payment.Text,
                PercentageRate = percentageRate.Text
            });
            _editDebtId = 0;
        }

        lender.Text = string.Empty;
        originalAmount.Text = string.Empty;
        currentAmount.Text = string.Empty;
        payment.Text = string.Empty;
        percentageRate.Text = string.Empty;

        listView.ItemsSource = await _dbService.GetDebtPayments();
    }

    private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var debt = (DebtPayment)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                _editDebtId = debt.Id;
                lender.Text = debt.Lender;
                originalAmount.Text = debt.OriginalAmount;
                currentAmount.Text = debt.CurrentAmount;
                payment.Text = debt.Payment;
                percentageRate.Text = debt.PercentageRate;
                break;

            case "Delete":
                await _dbService.Delete(debt);
                listView.ItemsSource = await _dbService.GetDebtPayments();
                break;
        }
    }
}