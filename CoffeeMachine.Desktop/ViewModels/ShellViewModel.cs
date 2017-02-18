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
				return _coffeeMachine;
			}
			set
			{
				if (_coffeeMachine == value)
				{
					return;
				}
				_coffeeMachine = value;
				OnPropertyChanged("CoffeeMachine");
			}
		}

	    private DelegateCommand<double?> _insertCoinCommand;
		public DelegateCommand<double?> InsertCoinCommand
		{
			get
			{
				return _insertCoinCommand;
			}
			set
			{
				if (_insertCoinCommand == value)
				{
					return;
				}
				_insertCoinCommand = value;
				OnPropertyChanged("InsertCoinCommand");
			}
		}

	    private DelegateCommand _prepareCoffeeCommand;
        public DelegateCommand PrepareCoffeeCommand
		{
			get
			{
				return _prepareCoffeeCommand;
			}
			set
			{
				if (_prepareCoffeeCommand == value)
				{
					return;
				}
				_prepareCoffeeCommand = value;
				OnPropertyChanged("PrepareCoffeeCommand");
			}
		}

	    private DelegateCommand _refundMoneyCommand;
        public DelegateCommand RefundMoneyCommand
		{
			get
			{
				return _refundMoneyCommand;
			}
			set
			{
				if (_refundMoneyCommand == value)
				{
					return;
				}
				_refundMoneyCommand = value;
				OnPropertyChanged("RefundMoneyCommand");
			}
		}

	    private DelegateCommand _takeCoffeeCommand;
        public DelegateCommand TakeCoffeeCommand
		{
			get
			{
				return _takeCoffeeCommand;
			}
			set
			{
				if (_takeCoffeeCommand == value)
				{
					return;
				}
				_takeCoffeeCommand = value;
				OnPropertyChanged("TakeCoffeeCommand");
			}
		}

	    private string _userMessage;
        public string UserMessage
		{
			get
			{
				return _userMessage;
			}
			set
			{
				if (string.Equals(_userMessage, value, StringComparison.Ordinal))
				{
					return;
				}
				_userMessage = value;
				OnPropertyChanged("UserMessage");
			}
		}

		public ShellViewModel()
		{
            UserMessage = "Ready";
            CoffeeMachine = new CoffeeMachineModel();
            CoffeeMachine.OnTransitioned(OnTransitionAction);
            InsertCoinCommand = CoffeeMachine.CreateCommand(CoffeeMachineTrigger.InsertMoney,
                (double? param) =>
                {
                var coffeeMachine = CoffeeMachine;
                var nullable = param;
                coffeeMachine.InsertCoin((nullable.HasValue ? nullable.GetValueOrDefault() : 0));
                });

            RefundMoneyCommand = CoffeeMachine.CreateCommand(CoffeeMachineTrigger.RefundMoney);
            PrepareCoffeeCommand = CoffeeMachine.CreateCommand(CoffeeMachineTrigger.PrepareCoffee);
            TakeCoffeeCommand = CoffeeMachine.CreateCommand(CoffeeMachineTrigger.TakeCoffe);
            CoffeeMachine.PropertyChanged += CoffeeMachineOnPropertyChanged;
        }

		private void CoffeeMachineOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			if ((propertyChangedEventArgs.PropertyName == "InsertedMoney" || propertyChangedEventArgs.PropertyName == "PreparationProcess"))
			{
				UpdateScreenMessage();
			}
		}

		private void OnTransitionAction(StateMachine<CoffeeMachineState, CoffeeMachineTrigger>.Transition transition)
		{
			var source = new object[] { transition.Source, transition.Destination, transition.Trigger };
			Debug.WriteLine("Transition from {0} to {1}, trigger = {2}.", source);
			UpdateScreenMessage();
			RefreshCommands();
		}

		private void RefreshCommands()
		{
			InsertCoinCommand.RaiseCanExecuteChanged();
			RefundMoneyCommand.RaiseCanExecuteChanged();
			PrepareCoffeeCommand.RaiseCanExecuteChanged();
			TakeCoffeeCommand.RaiseCanExecuteChanged();
		}

		private void UpdateScreenMessage()
		{
			switch (CoffeeMachine.State)
			{
				case CoffeeMachineState.Idle:
				{
					UserMessage = "Ready";
					break;
				}
				case CoffeeMachineState.WithMoney:
				case CoffeeMachineState.CanSelectCoffee:
				{
					UserMessage = string.Empty;
					break;
				}
				case CoffeeMachineState.PreparingCoffee:
				{
					UserMessage = $"Preparing coffee {CoffeeMachine.PreparationProcess} %...";
					break;
				}
				case CoffeeMachineState.CoffeeReady:
				{
					UserMessage = "Your coffee is ready!";
					break;
				}
				case CoffeeMachineState.RefundMoney:
				{
					UserMessage = "Refunding money...";
					break;
				}
				default:
				{
					UserMessage = "Out of order";
					break;
				}
			}
		}
	}
}