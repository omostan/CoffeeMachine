namespace CoffeeMachine.Model.StateMachine
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using Properties;

    using Stateless;

   public sealed class CoffeeMachineModel : StateMachine<CoffeeMachineState, CoffeeMachineTrigger>, INotifyPropertyChanged
    {
       public static double CoffeePrice { get; } = 2;

       private double _InsertedMoney;
        public double InsertedMoney
        {
            get
            {
                return _InsertedMoney;
            }
            private set
            {
                if( Equals(_InsertedMoney, value) )
                {
                    return;
                }
                _InsertedMoney = value;
                OnPropertyChanged();
            }
        }

        private double _PreparationProcess;
        public double PreparationProcess
        {
            get
            {
                return _PreparationProcess;
            }
            private set
            {
                if( Equals(_PreparationProcess, value) )
                {
                    return;
                }
                _PreparationProcess = value;
                OnPropertyChanged();
            }
        }

        public CoffeeMachineModel() : base(CoffeeMachineState.Idle)
        {
            ConfigureMachine();
        }

        private void ConfigureMachine()
        {
            Configure(CoffeeMachineState.Idle).Permit(CoffeeMachineTrigger.InsertMoney, CoffeeMachineState.WithMoney);
            Configure(CoffeeMachineState.RefundMoney).OnEntry(RefundMoney).Permit(CoffeeMachineTrigger.MoneyRefunded, CoffeeMachineState.Idle);
            Configure(CoffeeMachineState.WithMoney).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.EnoughMoney, CoffeeMachineState.CanSelectCoffee);
            Configure(CoffeeMachineState.CanSelectCoffee).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.PrepareCoffee, CoffeeMachineState.PreparingCoffee);
            Configure(CoffeeMachineState.PreparingCoffee).OnEntry(PrepareCoffee).Permit(CoffeeMachineTrigger.CoffeePrepared, CoffeeMachineState.CoffeeReady);
            Configure(CoffeeMachineState.CoffeeReady).Permit(CoffeeMachineTrigger.TakeCoffe, CoffeeMachineState.RefundMoney);
            OnTransitioned(NotifyStateChanged);
        }

        public void InsertCoin(double amount)
        {
            CoffeeMachineModel insertedMoney = this;
            insertedMoney.InsertedMoney = insertedMoney.InsertedMoney + amount;
            if( (State == CoffeeMachineState.WithMoney && InsertedMoney >= 2) )
            {
                Fire(CoffeeMachineTrigger.EnoughMoney);
            }
        }

        private void NotifyStateChanged(Transition transition)
        {
            OnPropertyChanged("State");
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PrepareCoffee()
        {
            (new Task(() => {
                InsertedMoney = InsertedMoney - 2;
                while( PreparationProcess < 100 )
                {
                    Thread.Sleep(50);
                    CoffeeMachineModel preparationProcess = this;
                    preparationProcess.PreparationProcess = preparationProcess.PreparationProcess + 1;
                }
                PreparationProcess = 0;
                Fire(CoffeeMachineTrigger.CoffeePrepared);
            })).Start();
        }

        private void RefundMoney()
        {
            (new Task(() => {
                while( InsertedMoney > 1 )
                {
                    Thread.Sleep(200);
                    InsertedMoney = InsertedMoney - 1;
                }
                InsertedMoney = 0;
                Fire(CoffeeMachineTrigger.MoneyRefunded);
            })).Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}