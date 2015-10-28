namespace CoffeeMachine.Model.StateMachine
{
    public enum CoffeeMachineTrigger
	{
		InsertMoney,
		RefundMoney,
		PrepareCoffee,
		TakeCoffe,
		EnoughMoney,
		CoffeePrepared,
		MoneyRefunded
	}
}