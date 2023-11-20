using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class CustomQueryRepository<T> where T : BaseEntity
    {
        // public DbSet<T> Entidad { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        
        public IQueryable<T> ObtenerEntidadesPersonalizadas(string campo, string condicion, string valorCondicion)
        {
            // Crear una expresión lambda dinámicamente para la condición
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, campo);
            var constant = Expression.Constant(valorCondicion);
            var condition = GetExpression(condicion, property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(condition, parameter);

            // Aplicar la consulta personalizada
            return _unitOfWork.Set<T>().Where(lambda);
        }

        private Expression GetExpression(string condicion, MemberExpression left, ConstantExpression right)
        {
            switch (condicion)
            {
                case "igual":
                    return Expression.Equal(left, right);

                case "mayor que":
                    return Expression.GreaterThan(left, right);

                case "mayor o igual que":
                    return Expression.GreaterThanOrEqual(left, right);

                case "menor que":
                    return Expression.LessThan(left, right);

                case "menor o igual que":
                    return Expression.LessThanOrEqual(left, right);

                // Agregar más casos según las condiciones que necesites

                default:
                    throw new NotSupportedException($"La condición '{condicion}' no es compatible.");
            }
        }
    }
}