namespace CoffeeMachine.Model.StateMachine
{
    public enum CoffeeMachineState
	{
		Idle,
		WithMoney,
		CanSelectCoffee,
		PreparingCoffee,
		CoffeeReady,
		RefundMoney
	}
}