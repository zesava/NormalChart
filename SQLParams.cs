using System;
using System.Collections.Generic;

namespace NormalChart
{
    public class SQLParams
    {
        public event EventHandler ParametersChanged;
        private void OnParametersChanged()
        {
            ParametersChanged?.Invoke(this, EventArgs.Empty);
        }


        private string _startDateTime = DateTime.Now.ToString();
        public string StartDateTime
        {
            get { return _startDateTime; }
            set
            {
                _startDateTime = value;
                OnParametersChanged();
            }
        }

        private int _resolution = -15;
        public int Resolution
        {
            get
            {
                return _resolution;
            }
            set
            {
                if (value < -1440 || value > -15)
                {
                    _resolution = -15;
                }
                else
                {
                    _resolution = value;
                }
                OnParametersChanged();
            }
        }

        public List<int> LogID { get; set; } = new List<int> { };

        public bool ForceDataReload
        {
            set
            {
                OnParametersChanged();
            }
        }
    }
}
