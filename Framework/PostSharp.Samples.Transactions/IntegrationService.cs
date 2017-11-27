namespace PostSharp.Samples.Transactions
{
  public static class IntegrationService
  {
    [RequiresTransaction]
    public static void PlaceOrderAndPay(string sourceAccount, string destinationAccount, string description,
      decimal amount)
    {
      OrderService.PlaceOrder(description, amount);
      FinanceService.Transfer(sourceAccount, destinationAccount, amount, description);
    }
  }
}