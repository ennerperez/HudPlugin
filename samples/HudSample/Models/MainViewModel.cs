using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HudSample
{
    /// <summary>
    /// private bool _isDefective;
    /// public bool IsDefective
    /// {
    ///     get { return _isDefective; }
    ///     set { SetValue(ref _isDefective, value); }
    /// }
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetValue<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (!property.Equals(null) && property.Equals(value)) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Masks = new[] { "None", "Clear", "Black", "Gradient" };
            Types = new[] { "Normal", "Error", "Success", "Image" };
            Positions = new[] { "None", "Bottom", "Center", "Top" };
        }

        public string[] Masks { get; private set; }
        public string[] Types { get; private set; }
        public string[] Positions { get; private set; }

        private string _message = "Hi world!";

        public string Message
        {
            get { return _message; }
            set { SetValue(ref _message, value); }
        }

        private int _selectedMask;

        public int SelectedMask
        {
            get { return _selectedMask; }
            set { SetValue(ref _selectedMask, value); }
        }

        private int _selectedType;

        public int SelectedType
        {
            get { return _selectedType; }
            set { SetValue(ref _selectedType, value); }
        }

        private int _selectedPosition;

        public int SelectedPosition
        {
            get { return _selectedPosition; }
            set { SetValue(ref _selectedPosition, value); }
        }

        private int _timeout = 3;

        public int Timeout
        {
            get { return _timeout; }
            set { SetValue(ref _timeout, value); }
        }

        private float _progress = -1F;

        public float Progress
        {
            get { return _progress; }
            set { SetValue(ref _progress, value); }
        }

        private bool _centered = true;

        public bool Centered
        {
            get { return _centered; }
            set { SetValue(ref _centered, value); }
        }

        private string _cancelCaption = "Cancel";

        public string CancelCaption
        {
            get { return _cancelCaption; }
            set { SetValue(ref _cancelCaption, value); }
        }
    }
}