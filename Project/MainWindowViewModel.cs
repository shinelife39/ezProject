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
            initialization();
        }
        #endregion

        #region Properties
        //환자 처방전 목록 DataGrid
        private ObservableCollection<PrescriptionData> _PrescriptionList;
        public ObservableCollection<PrescriptionData> PrescriptionList { get { return _PrescriptionList; } set { _PrescriptionList = value; OnPropertyChanged("PrescriptionList"); } }

        //환자 목록 List
        private ObservableCollection<PatientData> _PatientList = new ObservableCollection<PatientData>();
        public ObservableCollection<PatientData> PatientList { get { return _PatientList; } set { _PatientList = value; OnPropertyChanged("PatientList"); } }

        //환자 검색 결과를 저장하는 List
        private ObservableCollection<PatientData> _PatientSearchList;
        public ObservableCollection<PatientData> PatientSearchList { get { return _PatientSearchList; } set { _PatientSearchList = value; OnPropertyChanged("PatientSearchList"); } }

        //환자 이름을 띄우는 TextBlock
        private string _PatientNameTextBlock;
        public string PatientNameTextBlock { get { return _PatientNameTextBlock; } set { _PatientNameTextBlock = value; OnPropertyChanged("PatientNameTextBlock"); } }

        //환자 처방전 목록에 있는 처방전에 매기는 번호
        private int _PrescriptionNumber;
        public int PrescriptionNumber { get { return _PrescriptionNumber; } set { _PrescriptionNumber = value; OnPropertyChanged("PrescriptionNumber"); } }

        //연령대 검색 콤보박스 항목 List
        private List<string> _AgeCollection;
        public List<string> AgeCollection { get { return _AgeCollection; } set { _AgeCollection = value; OnPropertyChanged("AgeCollection"); } }

        //연령대 검색 콤보박스에서 선택된 연령대
        private string _SelectedAge;
        public string SelectedAge { get { return _SelectedAge; } set { _SelectedAge = value; OnPropertyChanged("SelectedAge"); } }

        //환자 이름
        private string _PatientName;
        public string PatientName { get { return _PatientName; } set { _PatientName = value; OnPropertyChanged("PatientName"); } }

        //환자 번호
        private string _PatientNumber;
        public string PatientNumber { get { return _PatientNumber; } set { _PatientNumber = value; OnPropertyChanged("PatientNumber"); } }

        //환자 성별
        private string _PatientGender;
        public string PatientGender { get { return _PatientGender; } set { _PatientGender = value; OnPropertyChanged("PatientGender"); } }

        //환자 나이
        private int _PatientAge;
        public int PatientAge { get { return _PatientAge; } set { _PatientAge = value; OnPropertyChanged("PatientAge"); } }

        //환자 이름 또는 환자 번호로 검색하기 위해 TextBox와 binding
        private string _SearchNameNumber;
        public string SearchNameNumber { get { return _SearchNameNumber; } set { _SearchNameNumber = value; OnPropertyChanged("_SearchNameNumber"); } }

        //남자를 검색하기 위해 RadioButton과 binding
        private string _SearchMale;
        public string SearchMale { get { return _SearchMale; } set { _SearchMale = value; OnPropertyChanged("SearchMale"); } }

        //여자를 검색하기 위해 RadioButton과 binding
        private string _SearchFemale;
        public string SearchFemale { get { return _SearchFemale; } set { _SearchFemale = value; OnPropertyChanged("SearchFemale"); } }

        //남자 환자 선택 시 띄우는 이미지
        private bool _VisibleMaleIcon;
        public bool VisibleMaleIcon { get { return _VisibleMaleIcon; } set { _VisibleMaleIcon = value; OnPropertyChanged("VisibleMaleIcon"); } }

        //여자 환자 선택 시 띄우는 이미지
        private bool _VisibleFemaleIcon;
        public bool VisibleFemaleIcon { get { return _VisibleFemaleIcon; } set { _VisibleFemaleIcon = value; OnPropertyChanged("VisibleFemaleIcon"); } }

        //초기화 버튼
        private bool _IsInit;
        public bool IsInit { get { return _IsInit; } set { _IsInit = value; OnPropertyChanged("IsInit"); } }

        //검색 버튼
        private bool _IsOk;
        public bool IsOk { get { return _IsOk; } set { _IsOk = value; OnPropertyChanged("IsOk"); } }

        //"전체" RadioButton
        private bool _AllRadioButton = true;
        public bool AllRadioButton { get { return _AllRadioButton; } set { _AllRadioButton = value; OnPropertyChanged("AllRadioButton"); } }

        //"남" RadioButton
        private bool _MaleRadioButton;
        public bool MaleRadioButton { get { return _MaleRadioButton; } set { _MaleRadioButton = value; OnPropertyChanged("MaleRadioButton"); } }

        //"여" RadioButton
        private bool _FemaleRadioButton;
        public bool FemaleRadioButton { get { return _FemaleRadioButton; } set { _FemaleRadioButton = value; OnPropertyChanged("FemaleRadioButton"); } }

        //선택된 성별
        private string _GenderSelected;
        public string GenderSelected { get { return _GenderSelected; } set { _GenderSelected = value; OnPropertyChanged("GenderSelected"); } }
        #endregion


        #region Commands
        //환자 이름 또는 환자 번호로 검색
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

        //Button 및 ListBox 초기화
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

        //"전체" RadioButton 선택
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

        //"남" RadioButton 선택
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

        //"여" RadioButton 선택
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

        //ComboBox를 통해 연령대로 환자 검색
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

        //ListBox에서 더블클릭한 환자 정보 띄우기
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
            IsOk = false;
            IsInit = true;

            VisibleMaleIcon = true;
            VisibleFemaleIcon = true;

            PrescriptionList = new ObservableCollection<PrescriptionData>();

            this.AgeCollection = new List<string>() { "~10대", "20대", "30대", "40대", "50대", "60대", "70대", "80대", "90대~" };

            _PatientSearchList = PatientList;


            PatientList.Add(new PatientData()
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
            });
            
            for (int i = 0; i < 10; i++)
            {
                PrescriptionData a = new PrescriptionData()
                {
                    PrescriptionNumber = i+1
                };
                PrescriptionList.Add(a);
            }
        }

        //환자 이름 또는 환자 번호로 검색
        private void Search(object p)
        {
            IsOk = true;
            IsInit = false;

            PatientSearchList = new ObservableCollection<PatientData>(PatientList.Where(patient => patient.PatientName == SearchNameNumber || patient.PatientNumber == SearchNameNumber));
        }

        //Button 및 ListBox 초기화
        private void Reset(object p)
        {
            IsOk = false;
            IsInit = true;

            PatientSearchList = PatientList;
        }

        //"전체" RadioButton 선택
        private void AllCheck(object p)
        {
            GenderSelected = "전체";
            PatientSearchList = PatientList;
        }

        //"남" RadioButton 선택
        private void MaleCheck(object p)
        {
            GenderSelected = "남";
            PatientSearchList = new ObservableCollection<PatientData>(PatientList.Where(patient => patient.PatientGender == "남").Where(filterAge));
        }

        //"여" RadioButton 선택
        private void FemaleCheck(object p)
        {
            GenderSelected = "여";
            PatientSearchList = new ObservableCollection<PatientData>(PatientList.Where(patient => patient.PatientGender == "여").Where(filterAge));
        }

        //ComboBox를 통해 연령대로 환자 검색
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

        //ListBox에서 더블클릭한 환자 정보 띄우기
        private void OpenPatient(object p)
        {
            PatientData t = PatientSearchList.ElementAt((int)p);
            PatientName = t.PatientName;
            PatientGender = t.PatientGender;

            if (PatientGender == "남")
            {
                VisibleMaleIcon = false;
                VisibleFemaleIcon = true;
            }
            else if (PatientGender == "여")
            {
                VisibleMaleIcon = true;
                VisibleFemaleIcon = false;
            }
        }
        #endregion
    }
}
