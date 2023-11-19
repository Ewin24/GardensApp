using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using Core.Interfaces;
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
using Domain.Entities;

namespace Domain.Interfaces
{
<<<<<<< HEAD
    public interface IPayment :IGenericRepository<Payment>
=======
    public interface IPayment : IGenericString<Payment>
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
    {
        
    }
}