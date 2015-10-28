namespace Base.Comands
{
    using System;

    using Microsoft.Practices.Prism.Commands;

    using Stateless;

    public static class StateMachineCommandEx
	{
		public static DelegateCommand CreateCommand<TState, TTrigger>(this StateMachine<TState, TTrigger> stateMachine, TTrigger trigger, Action execute = null, Func<bool> canExecute = null)
		{
			var action = execute;
			var func = canExecute;
		    if (func != null)
		    {
		    }
		    else
		    {
		        func = () => true;
		    }
		    if (action == null)
			{
				action = () => {
				};
			}
			var delegateCommand = new DelegateCommand(() => {
				action();
				stateMachine.Fire(trigger);
			}, () => (stateMachine.CanFire(trigger) && func()));
			return delegateCommand;
		}

		public static DelegateCommand<TCommandParam> CreateCommand<TState, TTrigger, TCommandParam>(this StateMachine<TState, TTrigger> stateMachine, TTrigger trigger, Action<TCommandParam> execute = null, Func<bool> canExecute = null)
		{
			var action = execute;
			var func = canExecute;
			if (func == null)
			{
				func = () => true;
			}
			if (action == null)
			{
				action = param0 => {
				};
			}
			var delegateCommand = new DelegateCommand<TCommandParam>(param => {
				action(param);
				stateMachine.Fire(trigger);
			}, arg => (stateMachine.CanFire(trigger) && func()));
			return delegateCommand;
		}
	}
}