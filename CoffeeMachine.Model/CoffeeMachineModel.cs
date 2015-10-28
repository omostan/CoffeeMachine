namespace CoffeeMachine
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using Stateless;

    public class CoffeeMachineModel : StateMachine<CoffeeMachineState, CoffeeMachineTrigger>, INotifyPropertyChanged
    {
        private const double CoffeePrice = 2;

        public double InsertedMoney
        {
            get
            {
                V_0 = this.< InsertedMoney > k__BackingField;
                return V_0;
            }
            private set
            {
                if (this.< InsertedMoney > k__BackingField == value)
                {
                    return;
                }
                this.< InsertedMoney > k__BackingField = value;
                this.OnPropertyChanged("InsertedMoney");
            }
        }

        public double PreparationProcess
        {
            get
            {
                V_0 = this.< PreparationProcess > k__BackingField;
                return V_0;
            }
            private set
            {
                if (this.< PreparationProcess > k__BackingField == value)
                {
                    return;
                }
                this.< PreparationProcess > k__BackingField = value;
                this.OnPropertyChanged("PreparationProcess");
            }
        }

        public CoffeeMachineModel() : base(CoffeeMachineState.Idle)
        {
            this.ConfigureMachine();
        }

        private void ConfigureMachine()
        {
            base.Configure(CoffeeMachineState.Idle).Permit(CoffeeMachineTrigger.InsertMoney, CoffeeMachineState.WithMoney);
            base.Configure(CoffeeMachineState.RefundMoney).OnEntry(new Action(this.RefundMoney)).Permit(CoffeeMachineTrigger.MoneyRefunded, CoffeeMachineState.Idle);
            base.Configure(CoffeeMachineState.WithMoney).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.EnoughMoney, CoffeeMachineState.CanSelectCoffee);
            base.Configure(CoffeeMachineState.CanSelectCoffee).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.PrepareCoffee, CoffeeMachineState.PreparingCoffee);
            base.Configure(CoffeeMachineState.PreparingCoffee).OnEntry(new Action(this.PrepareCoffee)).Permit(CoffeeMachineTrigger.CoffeePrepared, CoffeeMachineState.CoffeeReady);
            base.Configure(CoffeeMachineState.CoffeeReady).Permit(CoffeeMachineTrigger.TakeCoffe, CoffeeMachineState.RefundMoney);
            base.OnTransitioned(new Action<StateMachine<CoffeeMachineState, CoffeeMachineTrigger>.Transition>(this.NotifyStateChanged));
        }

        public void InsertCoin( double amount )
        {
            CoffeeMachineModel insertedMoney = this;
            insertedMoney.InsertedMoney = insertedMoney.InsertedMoney + amount;
            if ((base.State == CoffeeMachineState.WithMoney && this.InsertedMoney >= 2))
            {
                base.Fire(CoffeeMachineTrigger.EnoughMoney);
            }
        }

        private void NotifyStateChanged( StateMachine<CoffeeMachineState, CoffeeMachineTrigger>.Transition transition )
        {
            this.OnPropertyChanged("State");
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void PrepareCoffee()
        {
            (new Task(() => {
                this.InsertedMoney = this.InsertedMoney - 2;
                while (this.PreparationProcess < 100)
                {
                    Thread.Sleep(50);
                    CoffeeMachineModel preparationProcess = this;
                    preparationProcess.PreparationProcess = preparationProcess.PreparationProcess + 1;
                }
                this.PreparationProcess = 0;
                base.Fire(CoffeeMachineTrigger.CoffeePrepared);
            })).Start();
        }

        private void RefundMoney()
        {
            (new Task(() => {
                while (this.InsertedMoney > 1)
                {
                    Thread.Sleep(200);
                    this.InsertedMoney = this.InsertedMoney - 1;
                }
                this.InsertedMoney = 0;
                base.Fire(CoffeeMachineTrigger.MoneyRefunded);
            })).Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
