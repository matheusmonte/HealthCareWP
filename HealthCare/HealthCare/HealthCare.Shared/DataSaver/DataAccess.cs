using HealthCare.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace HealthCare.DataSaver
{
    public class DataAccess
    {
        private ApplicationDataContainer DataBase;

        private readonly string DATA_LOCAL_GLICOSE = "GlicoseAppData";
        private readonly string DATA_LOCAL_PRESSURE = "PressureAppData";

        public DataAccess()
        {
            if (DataBase == null)
            {
                DataBase = Windows.Storage.ApplicationData.Current.LocalSettings;
            }
        }

        public List<GlicoseModel> RecoveryGlicoseData()
        {
            return (List<GlicoseModel>)DataBase.Values[DATA_LOCAL_GLICOSE];
        }

        public void SaveNewGlicose(GlicoseModel newGlicose)
        {
            List<GlicoseModel> list = RecoveryGlicoseData();
            list.Add(newGlicose);
            SaveListGlicose(list);
        }

        private void SaveListGlicose(List<GlicoseModel> list)
        {
            DataBase.Values[DATA_LOCAL_GLICOSE] = list;
        }


        public List<ArterialPressureModel> RecoveryPressureData()
        {
            return (List<ArterialPressureModel>)DataBase.Values[DATA_LOCAL_PRESSURE];
        }

        public void SaveNewPressure(ArterialPressureModel newPressure)
        {
            List<ArterialPressureModel> list = RecoveryPressureData();
            list.Add(newPressure);
            SaveListPressure(list);
        }

        private void SaveListPressure(List<ArterialPressureModel> list)
        {
            DataBase.Values[DATA_LOCAL_PRESSURE] = list;
        }
    }
}
