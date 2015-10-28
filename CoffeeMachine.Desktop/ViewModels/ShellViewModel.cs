namespace ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    using Base.Comands;

    using CoffeeMachine.Model.StateMachine;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;

    using Stateless;

    public class ShellViewModel : BindableBase
	{
	    private CoffeeMachineModel _coffeeMachine;
        public CoffeeMachineModel CoffeeMachine
		{
			get
			{
				return this._coffeeMachine;
			}
			set
			{
				if (this._coffeeMachine == value)
				{
					return;
				}
				this._coffeeMachine = value;
				this.OnPropertyChanged("CoffeeMachine");
			}
		}

	    private DelegateCommand<double?> _insertCoinCommand; 
		public DelegateCommand<double?> InsertCoinCommand
		{
			get
			{
				return this._insertCoinCommand;
			}
			set
			{
				if (this._insertCoinCommand == value)
				{
					return;
				}
				this._insertCoinCommand = value;
				this.OnPropertyChanged("InsertCoinCommand");
			}
		}

	    private DelegateCommand _prepareCoffeeCommand;
        public DelegateCommand PrepareCoffeeCommand
		{
			get
			{
				return this._prepareCoffeeCommand;
			}
			set
			{
				if (this._prepareCoffeeCommand == value)
				{
					return;
				}
				this._prepareCoffeeCommand = value;
				this.OnPropertyChanged("PrepareCoffeeCommand");
			}
		}

	    private DelegateCommand _refundMoneyCommand;
        public DelegateCommand RefundMoneyCommand
		{
			get
			{
				return this._refundMoneyCommand;
			}
			set
			{
				if (this._refundMoneyCommand == value)
				{
					return;
				}
				this._refundMoneyCommand = value;
				this.OnPropertyChanged("RefundMoneyCommand");
			}
		}

	    private DelegateCommand _takeCoffeeCommand;
        public DelegateCommand TakeCoffeeCommand
		{
			get
			{
				return this._takeCoffeeCommand;
			}
			set
			{
				if (this._takeCoffeeCommand == value)
				{
					return;
				}
				this._takeCoffeeCommand = value;
				this.OnPropertyChanged("TakeCoffeeCommand");
			}
		}

	    private string _userMessage;
        public string UserMessage
		{
			get
			{
				return this._userMessage;
			}
			set
			{
				if (string.Equals(this._userMessage, value, StringComparison.Ordinal))
				{
					return;
				}
				this._userMessage = value;
				this.OnPropertyChanged("UserMessage");
			}
		}

		public ShellViewModel()
		{
            this.UserMessage = "Ready";
            this.CoffeeMachine = new CoffeeMachineModel();
            this.CoffeeMachine.OnTransitioned(this.OnTransitionAction);
            this.InsertCoinCommand = this.CoffeeMachine.CreateCommand(CoffeeMachineTrigger.InsertMoney,
                (double? param) =>
                {
                var coffeeMachine = this.CoffeeMachine;
                var nullable = param;
                coffeeMachine.InsertCoin((nullable.HasValue ? nullable.GetValueOrDefault() : 0));
                }, null);

            this.RefundMoneyCommand = this.CoffeeMachine.CreateCommand(CoffeeMachineTrigger.RefundMoney, null, null);
            this.PrepareCoffeeCommand = this.CoffeeMachine.CreateCommand(CoffeeMachineTrigger.PrepareCoffee, null, null);
            this.TakeCoffeeCommand = this.CoffeeMachine.CreateCommand(CoffeeMachineTrigger.TakeCoffe, null, null);
            this.CoffeeMachine.PropertyChanged += this.CoffeeMachineOnPropertyChanged;
        }

		private void CoffeeMachineOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			if ((propertyChangedEventArgs.PropertyName == "InsertedMoney" || propertyChangedEventArgs.PropertyName == "PreparationProcess"))
			{
				this.UpdateScreenMessage();
			}
		}

		private void OnTransitionAction(StateMachine<CoffeeMachineState, CoffeeMachineTrigger>.Transition transition)
		{
			var source = new object[] { transition.Source, transition.Destination, transition.Trigger };
			Debug.WriteLine("Transition from {0} to {1}, trigger = {2}.", source);
			this.UpdateScreenMessage();
			this.RefreshCommands();
		}

		private void RefreshCommands()
		{
			this.InsertCoinCommand.RaiseCanExecuteChanged();
			this.RefundMoneyCommand.RaiseCanExecuteChanged();
			this.PrepareCoffeeCommand.RaiseCanExecuteChanged();
			this.TakeCoffeeCommand.RaiseCanExecuteChanged();
		}

		private void UpdateScreenMessage()
		{
			switch (this.CoffeeMachine.State)
			{
				case CoffeeMachineState.Idle:
				{
					this.UserMessage = "Ready";
					break;
				}
				case CoffeeMachineState.WithMoney:
				case CoffeeMachineState.CanSelectCoffee:
				{
					this.UserMessage = string.Empty;
					break;
				}
				case CoffeeMachineState.PreparingCoffee:
				{
					this.UserMessage = string.Format("Preparing coffee {0} %...", this.CoffeeMachine.PreparationProcess);
					break;
				}
				case CoffeeMachineState.CoffeeReady:
				{
					this.UserMessage = "You coffee is ready!";
					break;
				}
				case CoffeeMachineState.RefundMoney:
				{
					this.UserMessage = "Refunding money...";
					break;
				}
				default:
				{
					this.UserMessage = "Out of order";
					break;
				}
			}
		}
	}
}