using EzCareTech.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project
{
    public class MainWindowViewModel : NotifyPropertyChangedBase
    {

        #region Variables
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            IsOk = false;
            IsInit = true;

            PrescriptionList = new ObservableCollection<PrescriptionData>();

            this.AgeCollection = new List<string>() { "~10대", "20대", "30대", "40대", "50대", "60대", "70대", "80대", "90대~" };

            _PatientSearchList = PatientList;

            /*PatientData data = new PatientData()
            {
                PatientName = "이선주",
                PatientNumber = "A20",
                PatientGender = "여",
                PatientAge = 10
            };*/

            /*PatientList.Add(new PatientData()
            {
                PatientName = "이선주",
                PatientNumber = "A20",
                PatientGender = "여",
                PatientAge = 10
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "송재원",
                PatientNumber = "B30",
                PatientGender = "남",
                PatientAge = 20
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "류다영",
                PatientNumber = "C40",
                PatientGender = "여",
                PatientAge = 30
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "박종현",
                PatientNumber = "D50",
                PatientGender = "남",
                PatientAge = 40
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "채민규",
                PatientNumber = "E60",
                PatientGender = "남",
                PatientAge = 50
            });*/

            initialization();


        }

        #endregion

        #region Properties
        private ObservableCollection<PrescriptionData> _PrescriptionList;
        public ObservableCollection<PrescriptionData> PrescriptionList { get { return _PrescriptionList; } set { _PrescriptionList = value; OnPropertyChanged("PrescriptionList"); } }

        private ObservableCollection<PatientData> _PatientList = new ObservableCollection<PatientData>();
        public ObservableCollection<PatientData> PatientList { get { return _PatientList; } set { _PatientList = value; OnPropertyChanged("PatientList"); } }

        private ObservableCollection<PatientData> _PatientSearchList;
        public ObservableCollection<PatientData> PatientSearchList { get { return _PatientSearchList; } set { _PatientSearchList = value; OnPropertyChanged("PatientSearchList"); } }

        private ObservableCollection<PatientData> _PatientTempList = new ObservableCollection<PatientData>();
        public ObservableCollection<PatientData> PatientTempList { get { return _PatientTempList; } set { _PatientTempList = value; OnPropertyChanged("PatientTempList"); } }

        private string _PatientNameTextBlock;
        public string PatientNameTextBlock { get { return _PatientNameTextBlock; } set { _PatientNameTextBlock = value; OnPropertyChanged("PatientNameTextBlock"); } }

        private Object _GenderColor;
        public Object GenderColor { get { return _GenderColor; } set { _GenderColor = value; OnPropertyChanged("GenderColor"); } }

        private int _PrescriptionNumber;
        public int PrescriptionNumber { get { return _PrescriptionNumber; } set { _PrescriptionNumber = value; OnPropertyChanged("PrescriptionNumber"); } }

        private List<string> _AgeCollection;
        public List<string> AgeCollection { get { return _AgeCollection; } set { _AgeCollection = value; OnPropertyChanged("AgeCollection"); } }

        private string _SelectedAge;
        public string SelectedAge { get { return _SelectedAge; } set { _SelectedAge = value; OnPropertyChanged("SelectedAge"); } }

        private string _PatientName;
        public string PatientName { get { return _PatientName; } set { _PatientName = value; OnPropertyChanged("PatientName"); } }

        private string _PatientNumber;
        public string PatientNumber { get { return _PatientNumber; } set { _PatientNumber = value; OnPropertyChanged("PatientNumber"); } }

        private string _PatientGender;
        public string PatientGender { get { return _PatientGender; } set { _PatientGender = value; OnPropertyChanged("PatientGender"); } }

        private int _PatientAge;
        public int PatientAge { get { return _PatientAge; } set { _PatientAge = value; OnPropertyChanged("PatientAge"); } }

        private string _SearchNameNumber;
        public string SearchNameNumber { get { return _SearchNameNumber; } set { _SearchNameNumber = value; OnPropertyChanged("_SearchNameNumber"); } }

        private string _SearchMale;
        public string SearchMale { get { return _SearchMale; } set { _SearchMale = value; OnPropertyChanged("SearchMale"); } }

        private string _SearchFemale;
        public string SearchFemale { get { return _SearchFemale; } set { _SearchFemale = value; OnPropertyChanged("SearchFemale"); } }

        private bool _IsInit;
        public bool IsInit { get { return _IsInit; } set { _IsInit = value; OnPropertyChanged("IsInit"); } }

        private bool _IsOk;
        public bool IsOk { get { return _IsOk; } set { _IsOk = value; OnPropertyChanged("IsOk"); } }

        private bool _AllRadioButton = true;
        public bool AllRadioButton { get { return _AllRadioButton; } set { _AllRadioButton = value; OnPropertyChanged("AllRadioButton"); } }

        private bool _MaleRadioButton;
        public bool MaleRadioButton { get { return _MaleRadioButton; } set { _MaleRadioButton = value; OnPropertyChanged("MaleRadioButton"); } }

        private bool _FemaleRadioButton;
        public bool FemaleRadioButton { get { return _FemaleRadioButton; } set { _FemaleRadioButton = value; OnPropertyChanged("FemaleRadioButton"); } }

        private string _GenderSelected;
        public string GenderSelected { get { return _GenderSelected; } set { _GenderSelected = value; OnPropertyChanged("GenderSelected"); } }
        #endregion


        #region Commands
        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                    _SearchCommand = new RelayCommand(p => this.Search(p));
                return _SearchCommand;
            }
        }


        private ICommand _CheckAllCommand;
        public ICommand CheckAllCommand
        {
            get
            {
                if (_CheckAllCommand == null)
                    _CheckAllCommand = new RelayCommand(p => this.AllCheck(p));
                return _CheckAllCommand;
            }
        }

        private ICommand _CheckMaleCommand;
        public ICommand CheckMaleCommand
        {
            get
            {
                if (_CheckMaleCommand == null)
                    _CheckMaleCommand = new RelayCommand(p => this.MaleCheck(p));
                return _CheckMaleCommand;
            }
        }

        private ICommand _CheckFemaleCommand;
        public ICommand CheckFemaleCommand
        {
            get
            {
                if (_CheckFemaleCommand == null)
                    _CheckFemaleCommand = new RelayCommand(p => this.FemaleCheck(p));
                return _CheckFemaleCommand;
            }
        }



        private ICommand _ResetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_ResetCommand == null)
                    _ResetCommand = new RelayCommand(p => this.Reset(p));
                return _ResetCommand;
            }
        }

        private ICommand _AgeSelectionCommand;
        public ICommand AgeSelectionCommand
        {
            get
            {
                if (_AgeSelectionCommand == null)
                    _AgeSelectionCommand = new RelayCommand(p => this.AgeSelection(p));
                return _AgeSelectionCommand;
            }
        }

        private ICommand _OpenPatientCommand;
        public ICommand OpenPatientCommand
        {
            get
            {
                if (_OpenPatientCommand == null)
                    _OpenPatientCommand = new RelayCommand(p => this.OpenPatient(p));
                return _OpenPatientCommand;
            }
        }

       


        #endregion

        #region Methods
        private void initialization()
        {
            //PatientList = new ObservableCollection<PatientData>();
            for (int i = 0; i < 10; i++)
            {
                PatientData data = new PatientData()
                {
                    PatientName = "환자" + i,
                    PatientNumber = "A" + i + 10,
                    PatientGender = (i % 2 == 0) ? "여" : "남",
                    PatientAge = (i + 1) * 10,
                };

                PrescriptionData a = new PrescriptionData()
                {
                    PrescriptionNumber = i+1
                };
                PatientList.Add(data);
                PrescriptionList.Add(a);

            }



           
        }

        private void Search(object p)
        {
            IsOk = true;
            IsInit = false;

            PatientSearchList = new ObservableCollection<PatientData>(PatientList.Where(patient => patient.PatientName == SearchNameNumber || patient.PatientNumber == SearchNameNumber));



            //for (int i = 0; i < PatientList.Count; i++)
            //{
            //    if (SearchNameNumber == PatientList.ElementAt(i).PatientName ||
            //        SearchNameNumber == PatientList.ElementAt(i).PatientNumber)
            //    {
            //        PatientData data = new PatientData()
            //        {
            //            PatientName = PatientList.ElementAt(i).PatientName,
            //            PatientNumber = PatientList.ElementAt(i).PatientNumber,
            //            PatientGender = PatientList.ElementAt(i).PatientGender,
            //            PatientAge = PatientList.ElementAt(i).PatientAge
            //        };
            //        PatientSearchList.Add(data);
            //    }
            //}
            //PatientTempList = PatientList;
            //PatientList = PatientSearchList;
            //PatientSearchList = PatientTempList;
        }


        //private void Init(object p)
        //{
        //    IsOk = true;
        //    IsInit = false;

        //    initialization();
        //}

        private void Reset(object p)
        {
            IsOk = false;
            IsInit = true;

            PatientSearchList = PatientList;

            //PatientTempList = PatientSearchList;
            //PatientSearchList = PatientList;
            //PatientList = PatientTempList;


            //PatientSearchList.Clear();
        }

        private void AllCheck(object p)
        {
            GenderSelected = "전체";
            PatientSearchList = PatientList;
        }

        private void MaleCheck(object p)
        {
            GenderSelected = "남";
            PatientSearchList = new ObservableCollection<PatientData>(PatientList.Where(patient => patient.PatientGender == "남").Where(filterAge));
        }

        private void FemaleCheck(object p)
        {
            GenderSelected = "여";
            PatientSearchList = new ObservableCollection<PatientData>(PatientList.Where(patient => patient.PatientGender == "여").Where(filterAge));
        }




        //if (GenderModeArray[1] == true)
        //{
        //    for (int i = 0; i < PatientList.Count; i++)
        //    {
        //        if (PatientList.ElementAt(i).PatientGender == "남")
        //        {
        //            PatientData data = new PatientData()
        //            {
        //                PatientName = PatientList.ElementAt(i).PatientName,
        //                PatientNumber = PatientList.ElementAt(i).PatientNumber,
        //                PatientGender = PatientList.ElementAt(i).PatientGender,
        //                PatientAge = PatientList.ElementAt(i).PatientAge
        //            };
        //            PatientSearchList.Add(data);
        //        }
        //    }
        //    PatientTempList = PatientList;
        //    PatientList = PatientSearchList;
        //    PatientSearchList = PatientTempList;
        //}
        //else if (GenderModeArray[2] == true)
        //{
        //    for (int i = 0; i < PatientList.Count; i++)
        //    {
        //        if (PatientList.ElementAt(i).PatientGender == "여")
        //        {
        //            PatientData data = new PatientData()
        //            {
        //                PatientName = PatientList.ElementAt(i).PatientName,
        //                PatientNumber = PatientList.ElementAt(i).PatientNumber,
        //                PatientGender = PatientList.ElementAt(i).PatientGender,
        //                PatientAge = PatientList.ElementAt(i).PatientAge
        //            };
        //            PatientSearchList.Add(data);
        //        }
        //    }
        //    PatientTempList = PatientList;
        //    PatientList = PatientSearchList;
        //    PatientSearchList = PatientTempList;
        //}
        //else if (GenderModeArray[0] == true)
        //{
        //    Reset(p);
        //}



        private void AgeSelection(object p)
        {
            PatientSearchList = new ObservableCollection<PatientData>(PatientList.Where(filterAge));
        }

        bool filterAge(PatientData patient)
        {
            var age = patient.PatientAge;
            switch (SelectedAge)
            {
                default:
                    return true;
                case "~10대":
                    return age < 20;
                case "20대":
                    return age >= 20 && age < 30;
                case "30대":
                    return age >= 30 && age < 40;
                case "40대":
                    return age >= 40 && age < 50;
                case "50대":
                    return age >= 50 && age < 60;
                case "60대":
                    return age >= 60 && age < 70;
                case "70대":
                    return age >= 70 && age < 80;
                case "80대":
                    return age >= 80 && age < 90;
                case "90대~":
                    return age >= 90;
            }
        }

        private void OpenPatient(object p)
        {
            PatientData t = PatientList.ElementAt((int)p);
            PatientName = t.PatientName;
            PatientGender = t.PatientGender;


        }
        #endregion
    }
}
