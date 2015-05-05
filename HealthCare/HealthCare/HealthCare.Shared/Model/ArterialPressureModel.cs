using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Model
{
    public class ArterialPressureModel
    {
        public DateTime DateHour
        {
            get;
            set;
        }

        public float MaxPressure
        {
            get;
            set;
        }

        public float MinPressure
        {
            get;
            set;
        }
    }
}
