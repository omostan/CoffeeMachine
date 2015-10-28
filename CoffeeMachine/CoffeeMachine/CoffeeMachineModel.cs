using CoffeeMachine.Properties;
using Stateless;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    //public sealed class CoffeeMachineModel : StateMachine<CoffeeMachineState, CoffeeMachineTrigger>, INotifyPropertyChanged
    //{
    //	private const double CoffeePrice = 2;

    //    private double _insertedMoney;
    //	public double InsertedMoney
    //	{
    //		get
    //		{
    //			return this._insertedMoney;
    //		}
    //		private set
    //		{
    //			if (Math.Abs(this._insertedMoney) > 0)
    //			{
    //				return;
    //			}
    //			this._insertedMoney = value;
    //			this.OnPropertyChanged("InsertedMoney");
    //		}
    //	}

    //    private double _preparationProcess;
    //       public double PreparationProcess
    //	{
    //		get
    //		{
    //			return this._preparationProcess;
    //		}
    //		private set
    //		{
    //			if (Math.Abs(this._preparationProcess - value) > 0)
    //			{
    //				return;
    //			}
    //			this._preparationProcess = value;
    //			this.OnPropertyChanged("PreparationProcess");
    //		}
    //	}

    //	public CoffeeMachineModel() : base(CoffeeMachineState.Idle)
    //	{
    //		this.ConfigureMachine();
    //	}

    //	private void ConfigureMachine()
    //	{
    //		this.Configure(CoffeeMachineState.Idle).Permit(CoffeeMachineTrigger.InsertMoney, CoffeeMachineState.WithMoney);
    //		this.Configure(CoffeeMachineState.RefundMoney).OnEntry(this.RefundMoney).Permit(CoffeeMachineTrigger.MoneyRefunded, CoffeeMachineState.Idle);
    //		this.Configure(CoffeeMachineState.WithMoney).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.EnoughMoney, CoffeeMachineState.CanSelectCoffee);
    //		this.Configure(CoffeeMachineState.CanSelectCoffee).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.PrepareCoffee, CoffeeMachineState.PreparingCoffee);
    //		this.Configure(CoffeeMachineState.PreparingCoffee).OnEntry(this.PrepareCoffee).Permit(CoffeeMachineTrigger.CoffeePrepared, CoffeeMachineState.CoffeeReady);
    //		this.Configure(CoffeeMachineState.CoffeeReady).Permit(CoffeeMachineTrigger.TakeCoffe, CoffeeMachineState.RefundMoney);
    //		this.OnTransitioned(this.NotifyStateChanged);
    //	}

    //	public void InsertCoin(double amount)
    //	{
    //		var insertedMoney = this;
    //		insertedMoney.InsertedMoney = insertedMoney.InsertedMoney + amount;
    //		if ((this.State == CoffeeMachineState.WithMoney && this.InsertedMoney >= 2))
    //		{
    //			this.Fire(CoffeeMachineTrigger.EnoughMoney);
    //		}
    //	}

    //	private void NotifyStateChanged(Transition transition)
    //	{
    //		this.OnPropertyChanged("State");
    //	}

    //	[NotifyPropertyChangedInvocator]
    //	private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //	{
    //		var handler = this.PropertyChanged;
    //		if (handler != null)
    //		{
    //			handler(this, new PropertyChangedEventArgs(propertyName));
    //		}
    //	}

    //	private void PrepareCoffee()
    //	{
    //		(new Task(() => {
    //			this.InsertedMoney = this.InsertedMoney - 2;
    //			while (this.PreparationProcess < 100)
    //			{
    //				Thread.Sleep(50);
    //				var preparationProcess = this;
    //				preparationProcess.PreparationProcess = preparationProcess.PreparationProcess + 1;
    //			}
    //			this.PreparationProcess = 0;
    //			this.Fire(CoffeeMachineTrigger.CoffeePrepared);
    //		})).Start();
    //	}

    //	private void RefundMoney()
    //	{
    //		(new Task(() => {
    //			while (this.InsertedMoney > 1)
    //			{
    //				Thread.Sleep(200);
    //				this.InsertedMoney = this.InsertedMoney - 1;
    //			}
    //			this.InsertedMoney = 0;
    //			this.Fire(CoffeeMachineTrigger.MoneyRefunded);
    //		})).Start();
    //	}

    //	public event PropertyChangedEventHandler PropertyChanged;
    //}

    public sealed class CoffeeMachineModel : StateMachine<CoffeeMachineState, CoffeeMachineTrigger>, INotifyPropertyChanged
    {
        private const double CoffeePrice = 2;

        private double _InsertedMoney;
        public double InsertedMoney
        {
            get
            {
                return _InsertedMoney;
            }
            private set
            {
                if( this._InsertedMoney == value )
                {
                    return;
                }
                this._InsertedMoney = value;
                this.OnPropertyChanged("InsertedMoney");
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
                if( this._PreparationProcess == value )
                {
                    return;
                }
                this._PreparationProcess = value;
                this.OnPropertyChanged("PreparationProcess");
            }
        }

        public CoffeeMachineModel() : base(CoffeeMachineState.Idle)
        {
            this.ConfigureMachine();
        }

        private void ConfigureMachine()
        {
            this.Configure(CoffeeMachineState.Idle).Permit(CoffeeMachineTrigger.InsertMoney, CoffeeMachineState.WithMoney);
            this.Configure(CoffeeMachineState.RefundMoney).OnEntry(new Action(this.RefundMoney)).Permit(CoffeeMachineTrigger.MoneyRefunded, CoffeeMachineState.Idle);
            this.Configure(CoffeeMachineState.WithMoney).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.EnoughMoney, CoffeeMachineState.CanSelectCoffee);
            this.Configure(CoffeeMachineState.CanSelectCoffee).PermitReentry(CoffeeMachineTrigger.InsertMoney).Permit(CoffeeMachineTrigger.RefundMoney, CoffeeMachineState.RefundMoney).Permit(CoffeeMachineTrigger.PrepareCoffee, CoffeeMachineState.PreparingCoffee);
            this.Configure(CoffeeMachineState.PreparingCoffee).OnEntry(new Action(this.PrepareCoffee)).Permit(CoffeeMachineTrigger.CoffeePrepared, CoffeeMachineState.CoffeeReady);
            this.Configure(CoffeeMachineState.CoffeeReady).Permit(CoffeeMachineTrigger.TakeCoffe, CoffeeMachineState.RefundMoney);
            this.OnTransitioned(new Action<Transition>(this.NotifyStateChanged));
        }

        public void InsertCoin(double amount)
        {
            CoffeeMachineModel insertedMoney = this;
            insertedMoney.InsertedMoney = insertedMoney.InsertedMoney + amount;
            if( (this.State == CoffeeMachineState.WithMoney && this.InsertedMoney >= 2) )
            {
                this.Fire(CoffeeMachineTrigger.EnoughMoney);
            }
        }

        private void NotifyStateChanged(Transition transition)
        {
            this.OnPropertyChanged("State");
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if( handler != null )
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void PrepareCoffee()
        {
            (new Task(() => {
                this.InsertedMoney = this.InsertedMoney - 2;
                while( this.PreparationProcess < 100 )
                {
                    Thread.Sleep(50);
                    CoffeeMachineModel preparationProcess = this;
                    preparationProcess.PreparationProcess = preparationProcess.PreparationProcess + 1;
                }
                this.PreparationProcess = 0;
                this.Fire(CoffeeMachineTrigger.CoffeePrepared);
            })).Start();
        }

        private void RefundMoney()
        {
            (new Task(() => {
                while( this.InsertedMoney > 1 )
                {
                    Thread.Sleep(200);
                    this.InsertedMoney = this.InsertedMoney - 1;
                }
                this.InsertedMoney = 0;
                this.Fire(CoffeeMachineTrigger.MoneyRefunded);
            })).Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}