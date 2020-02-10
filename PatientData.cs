using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class PatientData : EntityBase
    {
        private string _PatientName;
        public string PatientName { get { return _PatientName; } set { _PatientName = value; OnPropertyChanged("PatientName"); } }

        private string _PatientNumber;
        public string PatientNumber { get { return _PatientNumber; } set { _PatientNumber = value; OnPropertyChanged("PatientNumber"); } }

        private string _PatientGender;
        public string PatientGender { get { return _PatientGender; } set { _PatientGender = value; OnPropertyChanged("PatientGender"); } }

        private int _PatientAge;
        public int PatientAge { get { return _PatientAge; } set { _PatientAge = value; OnPropertyChanged("PatientAge"); } }

    }
}
