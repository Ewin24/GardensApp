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
    public interface IPayment :IGenericRepository<Payment>
=======
    public interface IPayment : IGenericString<Payment>
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
    public interface IPayment : IGenericString<Payment>
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
    {
        
    }
}