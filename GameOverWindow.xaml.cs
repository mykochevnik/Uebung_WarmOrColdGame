using System.Windows;

namespace U8WarmOderKalt;

/// <summary>
/// Interaktionslogik für GameOverWindow.xaml
/// </summary>
public partial class GameOverWindow : Window
{
    string winGameNumber = string.Empty;
    private Window ownerWindow;

    public string WinGameNumber { get => winGameNumber; set => winGameNumber = value; }
    public Window OwnerWindow { get => ownerWindow; set => ownerWindow = value; }

    public GameOverWindow(Window owner, int winNumber)
    {
        InitializeComponent();
        WinGameNumber = winNumber.ToString();
        DataContext = this;
        OwnerWindow = owner;
    }

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        ownerWindow.Close();
    }

    private void OnExitClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
