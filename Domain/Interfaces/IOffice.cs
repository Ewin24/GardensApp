using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
<<<<<<< HEAD
=======
using Core.Interfaces;
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
using Core.Interfaces;
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
using Domain.Entities;

namespace Domain.Interfaces
{
<<<<<<< HEAD
<<<<<<< HEAD
    public interface IOffice:IGenericRepository<Office>
=======
    public interface IOffice : IGenericString<Office>
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
    public interface IOffice : IGenericString<Office>
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
    {
        
    }
}