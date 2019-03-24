using System;
using System.Collections.Generic;
using System.IO;
using CSharp_Pechura_04.Models;
using CSharp_Pechura_04.Tools.Managers;

namespace CSharp_Pechura_04.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _users;

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
                string[] names =
                {
                    "Коко",
                    "П'єр",
                    "Карл",
                    "Крістіан",
                    "Крістіан",
                    "Андре",
                    "Джорджо",
                    "Джанні",
                    "Вера",
                    "Ральф",
                    "Лорі",
                    "Валентин",
                    "Іссей",
                    "Александр",
                    "Джон",
                    "Донателла",
                    "Стелла",
                    "Донна",
                    "Вів'єн",
                    "Лілія",
                    "Стефано",
                    "Роберто",
                    "Джиммі",
                    "Фібі",
                    "Том",
                    "Валентіно",
                    "Кензо",
                    "Філіп",
                    "Кейт",
                    "Наомі",
                    "Сінді",
                    "Андріана",
                    "Коко",
                    "Дарія",
                    "Клаудія",
                    "Ірина",
                    "Алессандра",
                    "Кендіс",
                    "Кароліна",
                    "Карла",
                    "Стефані",
                    "Сергій",
                    "Яна",
                    "Христина",
                    "Івет",
                    "Майа",
                    "Уляна",
                    "Михайло",
                    "Фред",
                    "Хоакін"
                };
                string[] surnames =
                {
                    "Шанель",
                    "Карден",
                    "Лагерфельд",
                    "Діор",
                    "Лакруа",
                    "Тан",
                    "Армані",
                    "Версаче",
                    "Вонг",
                    "Лорен",
                    "Юдашкін",
                    "Міяке",
                    "Макквін",
                    "Гальяно",
                    "Версаче",
                    "МакКартні",
                    "Каран",
                    "Вествуд",
                    "Пустовіт",
                    "Габанна",
                    "Каваллі",
                    "Чу",
                    "Філон",
                    "Форд",
                    "Гаравані",
                    "Такада",
                    "Плейн",
                    "Мосс",
                    "Кемпбел",
                    "Кроуфорд",
                    "Ліма",
                    "Роша",
                    "Вербова",
                    "Шиффер",
                    "Шейк",
                    "Амброзіо",
                    "Сванепул",
                    "Куркова",
                    "Бруні",
                    "Сеймур",
                    "Полунін",
                    "Саленко",
                    "Дудинська",
                    "Шевченко",
                    "Шовире",
                    "Плісецька",
                    "Лопаткіна",
                    "Баришніков",
                    "Астер",
                    "Кортес"
                };
                string[] mails =
                {
                    "shanelka",
                    "kardencool",
                    "lager",
                    "diorbaby",
                    "yourlacrua",
                    "tanchik",
                    "armanikitten",
                    "versacegirl",
                    "vongboy",
                    "lorenamazing",
                    "yudashkin",
                    "miake",
                    "macqueen",
                    "galiano",
                    "versacebest",
                    "maccartni",
                    "caran",
                    "westwood",
                    "pustovit",
                    "gabanna",
                    "cavalli",
                    "chu",
                    "filon",
                    "ford",
                    "garavani",
                    "takada",
                    "plein",
                    "moss",
                    "kempbell",
                    "crouford",
                    "lima",
                    "rosha",
                    "verbova",
                    "shiffer",
                    "shake",
                    "ambrosio",
                    "swanepool",
                    "curcova",
                    "bruni",
                    "seymur",
                    "polunin",
                    "salenko",
                    "dudinska",
                    "shevchenko",
                    "shovire",
                    "plisetska",
                    "lopatkina",
                    "barishnicov",
                    "aster",
                    "kortes"
              
                };
                Random random = new Random();
                for (int i = 0; i < 50; ++i)
                {
                    DateTime birthday = new DateTime(random.Next(1890, 2015), random.Next(1, 12), random.Next(1, 28));
                    Person person = new Person(names[i], surnames[i], mails[i] + "@gmail.com", birthday);
                    _users.Add(person);
                }

                SaveChanges();
            }
        }

        

        public void Add(Person person)
        {
            _users.Add(person);
            SaveChanges();
        }

        public void Remove(Person person)
        {
            _users.Remove(person);
            SaveChanges();
        }

        public void DoChanges()
        {
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _users; }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }
    }
}
