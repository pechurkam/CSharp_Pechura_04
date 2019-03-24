using System.Collections.Generic;
using CSharp_Pechura_04.Models;

namespace CSharp_Pechura_04.Tools.DataStorage
{
    internal interface IDataStorage
    {

        void Add(Person person);

        void Remove(Person person);

        void DoChanges();

        List<Person> PersonsList { get; }
    }
}
