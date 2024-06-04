using System;
using System.Collections.Generic;
using InchirieriAuto.Models;

namespace InchirieriAuto.Repository
{
    public interface IAngajatiRepository
    {
        List<AngajatiModel> GetAllAngajatis();
        AngajatiModel GetAngajatisByID(Guid ID);
        void InsertAngajati(AngajatiModel angajatiModel);
        void UpdateAngajati(AngajatiModel angajatiModel);
        void DeleteAngajati(AngajatiModel angajatiModel);
    }
}
