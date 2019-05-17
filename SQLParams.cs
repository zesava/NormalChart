using System;
using System.Collections.Generic;

namespace NormalChart
{
    public class SQLParams
    {
        private int _resolution = -15;

        public string StartDateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

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
            }
        }

        public List<int> LogID { get; set; } = new List<int> { };
    }
}
