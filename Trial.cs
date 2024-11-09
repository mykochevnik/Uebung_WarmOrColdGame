using System.ComponentModel;

namespace U8WarmOderKalt;

public class Trial : INotifyPropertyChanged
{
    int _userValue;
    int _distance;
    bool? isCloser; //Trial may also be null if it is the first or last trial
    string? _message;
    string? _tipp;

    public Trial(int userValue, int distance, bool? isCloser)
    {
        UserValue = userValue;
        Distance = distance;
        IsCloser = isCloser;
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public int UserValue {
        get => _userValue;
        set
        {
            _userValue = value;
            OnPropertyChanged(nameof(UserValue));
        }
    }
    public int Distance { get => _distance; set => _distance = value; }
    public bool? IsCloser {
        get => isCloser;
        set
        {
            isCloser = value;
            OnPropertyChanged(nameof(IsCloser));
        }
    }
    public string? Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged(nameof(Message));
        }
    }
    public string? Tipp
    {
        get => _tipp;
        set
        {
            _tipp = value;
            OnPropertyChanged(nameof(Tipp));
        }
    }
}
