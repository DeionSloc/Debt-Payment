using Debt_Payment_Calculator.View;

namespace Debt_Payment_Calculator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Loading), typeof(Loading));
            Routing.RegisterRoute(nameof(Dashboard), typeof(Dashboard));
        }
    }
}
