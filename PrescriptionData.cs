using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class PrescriptionData : EntityBase
    {
        private int _PrescriptionNumber;
        public int PrescriptionNumber { get { return _PrescriptionNumber; } set { _PrescriptionNumber = value; OnPropertyChanged("PrescriptionNumber"); } }
    }
}
