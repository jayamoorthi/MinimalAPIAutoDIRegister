using Domain.BaseDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class SoftDeleteModelBuilderExtensions
    {
        public static ModelBuilder ApplySoftDeleteQueryFilter( this ModelBuilder modelBuilder)
        {

            foreach(var entityTypes in modelBuilder.Model.GetEntityTypes())
            {
                if(!typeof(ISoftDelete).IsAssignableFrom(entityTypes.ClrType))
                {
                    continue;
                }

                var param = Expression.Parameter(entityTypes.ClrType, "entity");
                var prop = Expression.PropertyOrField(param, nameof(ISoftDelete.IsSoftDeleted));
                var enitiyNotDeleted = Expression.Lambda(Expression.Equal(prop,Expression.Constant(false)),param);
                entityTypes.SetQueryFilter(enitiyNotDeleted);
            }


            return modelBuilder;
        }
    }
}
