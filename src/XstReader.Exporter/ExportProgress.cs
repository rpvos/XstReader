namespace XstReader.Exporter
{
    public class ExportProgress
    {
        private int _Value = 0;
        public int Value
        {
            get => _Value;
            set
            {
                if (value < 0) value = 0;
                if (value > Maximum) Maximum = value;
                _Value = value;
            }
        }

        private int _Maximum = 1;
        public int Maximum
        {
            get => _Maximum;
            set
            {
                if (value < 0) value = 0;
                if (value < Value) Value = value;
                _Maximum = value;
            }
        }
        public int Percentage => (int)(((double)Value / (double)Maximum) * 100);

        public string? CurrentStepDescription { get; set; }

        private int _DefaultStep = 1;
        public int DefaultStep
        {
            get => _DefaultStep;
            set
            {
                if (value < 1) value = 1;
                _DefaultStep = value;
            }
        }

        private Action<ExportProgress>? ReportProgressAction { get; set; }

        #region Ctor
        public ExportProgress() { }
        public ExportProgress(Action<ExportProgress> reportProgressAction) : this()
        {
            ReportProgressAction = reportProgressAction;
        }
        #endregion Ctor

        public void Step()
        {
            Value += DefaultStep;
            ReportProgressAction?.Invoke(this);
        }
        public void Step(string description)
        {
            Value += DefaultStep;
            CurrentStepDescription = description;
            ReportProgressAction?.Invoke(this);
        }
        public void Step(int incValue, string description)
        {
            Value += incValue;
            CurrentStepDescription = description;
            ReportProgressAction?.Invoke(this);
        }
        public void IncrementMaximum(int increment = 1)
        {
            Maximum += increment;
            ReportProgressAction?.Invoke(this);
        }
        public void IncrementMaximum(bool condition, int increment = 1)
        {
            if (condition)
                IncrementMaximum(increment);
        }
    }
}
