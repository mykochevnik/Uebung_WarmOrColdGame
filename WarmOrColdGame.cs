using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace U8WarmOderKalt;
public class WarmOrColdGame : INotifyPropertyChanged
{
    int randomSearchedNumber;
    ObservableCollection<Trial> _trials = new();
    Trial? previousTrial;
    Trial _currentTrial;
    Dictionary<int, string> _distance = new Dictionary<int, string>{
        { 5, "Sehr heiß" },
        { 16, "Heiß" },
        { 32, "Warm" },
        { 48, "Kalt" },
        { 64, "Eiskalt" },
        { 80, "Frostig" }
    };


    public ObservableCollection<Trial> Trials
    { 
        get => _trials;
        set
        {
            _trials = value;

        }
    }
    public int RandomSearchedNumber { get => randomSearchedNumber; }
    public Trial CurrentTrial
    {
        get => _currentTrial;
        set
        {
            _currentTrial = value;
            OnPropertyChanged(nameof(CurrentTrial));
        }
    }
    public Trial? PreviousTrial { get => previousTrial; set => previousTrial = value; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public WarmOrColdGame()
    {
        Random rdm = new Random();
        randomSearchedNumber = rdm.Next(0, 101);
    }

    public bool CheckWon(int userInput) => (userInput == RandomSearchedNumber) ? true : false;
    public void AddTrial(int userInput)
    {
        //set PreviousTrial
        PreviousTrial = Trials.Count() == 0 ? null : Trials.Last();

        int tmpDistance = CalculateAbsoluteDistance(userInput);
        bool? tmpIsCloser = CheckIfCloser(userInput);
        CurrentTrial = new Trial(userInput, tmpDistance, tmpIsCloser);
        Trials.Add(CurrentTrial);
        CurrentTrial.Message = GenerateMessage();
        CurrentTrial.Tipp = GenerateTipp();
        OnPropertyChanged(nameof(Trials));
    }
    public bool? CheckIfCloser(int userInput)
    {
        int index;
        //check if previous attempt exists
        if (PreviousTrial is not null)
            index = Trials.IndexOf(PreviousTrial);
        else
            return null;

        //TODO: find another variant to show winning text not in red
        if (userInput == randomSearchedNumber)
            return null;

        if (Trials[index].Distance > CalculateAbsoluteDistance(userInput))
            return true;
        else if (Trials[index].Distance == CalculateAbsoluteDistance(userInput) && (Trials[index].IsCloser is not null))
        {
            if((bool)Trials[index].IsCloser)
                return true;
            else
                return false;
        }

        else
            return false;
    }

    public string GenerateDistanceTipp()
    {
        string message = string.Empty;
        List<int> keys = new List<int>(_distance.Keys);
        for (int i = 0; i < _distance.Count(); i++)
        {
            int key = keys[i];
            string value = _distance[key];
            if (i == 0)
            {
                if (CurrentTrial.Distance <= keys[i])
                    message = value;
            }
            else if (i == _distance.Count() - 1)
            {
                if (CurrentTrial.Distance > keys[i])
                    message = value;
            }
            else
            {
                if (CurrentTrial.Distance <= keys[i] && CurrentTrial.Distance > keys[i - 1])
                    message = value;
            }
        }
        return message;
    }

    public string GenerateMessage()
    {
        string message = string.Empty;
        bool hasPlayerWon = IsGameWon();

        // generateMessage for first attempt
        if (PreviousTrial is null)
            return "Du bist auf dem richtigen Weg!";
        else if (hasPlayerWon)
            message = $"Volltreffer!\nDas ist die gesuchte Zahl!" +
                $"\nDu hast das Spiel mit {Trials.Count().ToString()} Versuchen gewonnen!";
        else if (CurrentTrial.IsCloser is null)
            message = (bool)PreviousTrial.IsCloser ? "Gleich warm" : "Gleich kalt";
        else
            message = (bool)CurrentTrial.IsCloser ? "Wärmer" : "Kälter";

        return message;
    }

    public string GenerateTipp()
    {
        string tipp = GenerateDistanceTipp();
        bool hasPlayerWon = IsGameWon();

        if (PreviousTrial is null)
            tipp += $": Wähle eine andere Zahl, die größer oder kleiner als {CurrentTrial.UserValue} ist";
        else if (!hasPlayerWon)
        {
            if(CurrentTrial.Distance > PreviousTrial.Distance)
                tipp += $": {CurrentTrial.UserValue} ist weiter entfernt als {PreviousTrial.UserValue}";
            else if(CurrentTrial.Distance < PreviousTrial.Distance)
                tipp += $": {CurrentTrial.UserValue} ist näher als {PreviousTrial.UserValue}";
            else
                tipp += $": Mit {CurrentTrial.UserValue} bist du genauso weit entfernt " +
                    $"wie mit {PreviousTrial.UserValue}";
            return tipp;
        }
        else
            tipp = string.Empty;

        return tipp;
    }

    public bool IsGameWon() => CurrentTrial.UserValue == randomSearchedNumber;
    

    public int CalculateAbsoluteDistance(int userInput)
    {
        //When checking the absolute distance:
        //from randomSearchedNumber, the user number is subtracted
        return Math.Abs(randomSearchedNumber - userInput);
    }

    public int CalculateDistance(int userInput)
    {
        //When checking the distance:
        //from randomSearchedNumber, the user number is subtracted
        return randomSearchedNumber - userInput;
    }
}
