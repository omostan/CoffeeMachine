using System.Windows;

using CoffeeMachine.Wpf;

public partial class App
{
    public App()
    {
    }

    #region Overrides of Application

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var mw = new MainWindow();
        mw.ShowDialog();
    }

    #endregion
}