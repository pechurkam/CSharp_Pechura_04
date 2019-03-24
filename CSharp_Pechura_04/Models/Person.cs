using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharp_Pechura02_03.Tools.Exceptions;
using CSharp_Pechura04.Tools.Exceptions;

namespace CSharp_Pechura_04.Models
{
    [Serializable]
    internal class Person
    {
        #region Fields

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private int _age = -1;
        private string _sunSign;
        private string _chineseSign;
        private string _birthdayString;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthday
        {
            get { return _birthDate; }
            set
            {
                _birthDate = Convert.ToDateTime(value);
                _birthdayString = value.ToShortDateString();
                _age = AgeFunc();
                _sunSign = SunSignFunc();
                _chineseSign = ChineseSignFunc();

                OnPropertyChanged();
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("IsBirthday");
                OnPropertyChanged("BirthdayString");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
            }
        }

        #endregion

        #region Constructors

        private Person(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public Person(string name, string surname, string email, DateTime birthDate) :
            this(name, surname)
        {
            _email = email;
            _birthDate = birthDate;
        }

        public Person(string name, string surname, string email) :
            this(name, surname)
        {
            _email = email;
        }

        public Person(string name, string surname, DateTime birthDate) :
            this(name, surname)
        {
            _birthDate = birthDate;
        }

        #endregion

        #region ReadOnlyProps

        private int Age
        {
            get { return (_age == -1) ? (_age = AgeFunc()) : _age; }
        }

        public bool IsAdult
        {
            get { return (_age != -1) ? 18 <= _age : 18 <= (_age = AgeFunc()); }
        }

        public string BirthdayString
        {
            get { return _birthdayString ?? (_birthDate.ToString("dd MMMM yyyy")); }
        }

        public string SunSign
        {
            get { return _sunSign ?? (_sunSign = SunSignFunc()); }
        }

        public string ChineseSign
        {
            get { return _chineseSign ?? (_chineseSign = ChineseSignFunc()); }
        }

        public bool IsBirthday
        {
            get { return (_birthDate.Day == DateTime.Today.Day) && (_birthDate.Month == DateTime.Today.Month); }
        }

        #endregion



        public void Validate()
        {
            if (Age < 0 || DateTime.Today < Birthday)
            {
                throw new NotBornException();
            }

            if (Age > 135)
            {
                throw new DeadPersonException();
            }

            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(_email))
            {
                throw new EmailException(_email);
            }
        }

        private int AgeFunc()
        {
           return (DateTime.Today - Convert.ToDateTime(_birthDate)).Days / 365; 
        }

        private string SunSignFunc()
        {
            string zodiac = "";
            string[] zodiacSigns =
            {
                    "Овен", "Телець", "Близнюки", "Paк", "Лев", "Діва", "Терези", "Скорпіон", "Стрілець", "Козоріг",
                    "Водолій", "Риби"
                };
            if ((_birthDate.Month == 3 && _birthDate.Day >= 21) || (_birthDate.Month == 4 && _birthDate.Day <= 20))
            {
                zodiac = zodiacSigns[0];
            }
            else if ((_birthDate.Month == 4 && _birthDate.Day >= 21) ||
                     (_birthDate.Month == 5 && _birthDate.Day <= 20))
            {
                zodiac = zodiacSigns[1];
            }
            else if ((_birthDate.Month == 5 && _birthDate.Day >= 21) ||
                     (_birthDate.Month == 6 && _birthDate.Day <= 21))
            {
                zodiac = zodiacSigns[2];
            }
            else if ((_birthDate.Month == 6 && _birthDate.Day >= 22) ||
                     (_birthDate.Month == 7 && _birthDate.Day <= 22))
            {
                zodiac = zodiacSigns[3];
            }
            else if ((_birthDate.Month == 7 && _birthDate.Day >= 23) ||
                     (_birthDate.Month == 8 && _birthDate.Day <= 23))
            {
                zodiac = zodiacSigns[4];
            }
            else if ((_birthDate.Month == 8 && _birthDate.Day >= 24) ||
                     (_birthDate.Month == 9 && _birthDate.Day <= 22))
            {
                zodiac = zodiacSigns[5];
            }
            else if ((_birthDate.Month == 9 && _birthDate.Day >= 23) ||
                     (_birthDate.Month == 10 && _birthDate.Day <= 23))
            {
                zodiac = zodiacSigns[6];
            }
            else if ((_birthDate.Month == 10 && _birthDate.Day >= 24) ||
                     (_birthDate.Month == 11 && _birthDate.Day <= 22))
            {
                zodiac = zodiacSigns[7];
            }
            else if ((_birthDate.Month == 11 && _birthDate.Day >= 23) ||
                     (_birthDate.Month == 12 && _birthDate.Day <= 21))
            {
                zodiac = zodiacSigns[8];
            }
            else if ((_birthDate.Month == 12 && _birthDate.Day >= 22) ||
                     (_birthDate.Month == 1 && _birthDate.Day <= 20))
            {
                zodiac = zodiacSigns[9];
            }
            else if ((_birthDate.Month == 1 && _birthDate.Day >= 21) ||
                     (_birthDate.Month == 2 && _birthDate.Day <= 20))
            {
                zodiac = zodiacSigns[10];
            }
            else if ((_birthDate.Month == 2 && _birthDate.Day >= 21) ||
                     (_birthDate.Month == 3 && _birthDate.Day <= 20))
            {
                zodiac = zodiacSigns[11];
            }

            return zodiac;
        }

        private string ChineseSignFunc()
        {
            string[] zodiacSigns =
            {
                "Криса", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака",
                "Свиня"
            };
            return zodiacSigns[(_birthDate.Year - 4) % 12];
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
