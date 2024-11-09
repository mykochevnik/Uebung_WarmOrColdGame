using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace U8WarmOderKalt;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    WarmOrColdGame g;
    int UserInputValue;
    double startWindowWidth = 500;
    double resizedWindowWidth = 800;
    bool showHistory = false;
    bool showTipp = false;
    public event PropertyChangedEventHandler PropertyChanged;
    string? errorMessage;
    double screenWidth;
    double screenHeight;


    public WarmOrColdGame Game { get => g; set => g = value; }
    public string? ErrorMessage { get => errorMessage; set => errorMessage = value; }
    public bool ShowHistory {
        get => showHistory;
        set{
            showHistory = value;
            OnPropertyChanged(nameof(ShowHistory));
        }
    }

    public bool ShowTipp {
        get => showTipp;
        set{
            showTipp = value;
            OnPropertyChanged(nameof(ShowTipp));
        }
    }

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
        l_game.Content = "WARM oder KALT?";
        tblock_gameRules.Text = "Es wird eine Zahl von 0 bis 100 gesucht." +
            " Versuche sie zu erraten." +
            " Kommst du der gesuchten Zahl näher," +
            " bekommst du Hinweis \"wärmer\"." +
            " Entfernst du dich von der Zahl, wird es \"kälter\".";

        StartNewGame();
        DataContext = Game;
        list_Trials.ItemsSource = Game.Trials;
        Game.Trials.CollectionChanged += Trials_CollectionChanged;
        ResizeWindowWithoutHistory();
    }

    private void ResizeWindowWithoutHistory()
    {
        screenWidth = SystemParameters.PrimaryScreenWidth;
        screenHeight = SystemParameters.PrimaryScreenHeight;
        Width = startWindowWidth;
    }

    private void ResizeWindowWithHistory()
    {
        screenWidth = SystemParameters.PrimaryScreenWidth;
        screenHeight = SystemParameters.PrimaryScreenHeight;
        if (screenWidth > Width)
        {
            Left = (screenWidth - resizedWindowWidth) / 2;
            Top = (screenHeight - Height) / 3;
        }
        else
        {
            this.Left = 20;
            this.Top = 20;
        }
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        tbox_userInput.Focus();
        tbox_userInput.Select(0, 0); // Places the cursor at the beginning of the text
    }

    private void Trials_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        //when a new item is added, the list scrolls down and this item is visible
        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            // Focus on the last element
            list_Trials.ScrollIntoView(Game.Trials[Game.Trials.Count - 1]);
        }
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return)
        {
            bool isUserInputCorrect = int.TryParse(tbox_userInput.Text, out UserInputValue);

            if (isUserInputCorrect && UserInputValue >= 0 && UserInputValue <= 100)
            {
                var mainColorBrush = (SolidColorBrush)FindResource("MainColor");
                
                if (Game.CheckWon(UserInputValue))
                    HandleWon();
                else
                {
                    HandleWarmOrCold();
                    tbox_userInput.Clear();
                }

                border_userInput.BorderBrush = new SolidColorBrush(Colors.White);
                tbox_userInput.Foreground = mainColorBrush;
                tblock_errorMessage.Visibility = Visibility.Hidden;

            }
            else
            {
                tblock_errorMessage.Visibility = Visibility.Visible;
                ErrorMessage = "Bitte gib eine gültige Zahl ein";
                tblock_errorMessage.Text = ErrorMessage;
                border_userInput.BorderBrush = new SolidColorBrush(Colors.Red);
                tbox_userInput.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }

    public void StartNewGame()
    {
        Game = new WarmOrColdGame();
        OnPropertyChanged(nameof(Game.Trials));
        tbox_userInput.Clear();
    }

    public void HandleWon()
    {
        Game.AddTrial(UserInputValue);
        gameNumber.Text = UserInputValue.ToString();
        var gover = new GameOverWindow(this, UserInputValue);
        tbox_userInput.IsEnabled = false;
        gover.ShowDialog();

    }

    public void HandleWarmOrCold() {
        Game.AddTrial(UserInputValue);
    }

    private void Toogleb_history_Click(object sender, RoutedEventArgs e)
    {
        CheckBox box = sender as CheckBox;
        ShowHistory = (bool) box.IsChecked;

        //In this case, history is displayed  in the right part of the window
        if (ShowHistory)
        {
            Width = resizedWindowWidth;
            tblock_singleMessage.Visibility = Visibility.Collapsed;
            stackp_history.Visibility = Visibility.Visible;
            ResizeWindowWithHistory();
        }

        else
        {
            tblock_singleMessage.Visibility = Visibility.Visible;
            stackp_history.Visibility = Visibility.Collapsed;
            ResizeWindowWithoutHistory();
        }

        tbox_userInput.Focus();
        tbox_userInput.Select(0, 0);
    }

    private void Toogleb_tipp_Click(object sender, RoutedEventArgs e)
    {
        CheckBox box = sender as CheckBox;
        ShowTipp = (bool)box.IsChecked;

        if (ShowTipp)
            tblock_singleTipp.Visibility = Visibility.Visible;
        else
            tblock_singleTipp.Visibility = Visibility.Collapsed;

        tbox_userInput.Focus();
        tbox_userInput.Select(0, 0);
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}