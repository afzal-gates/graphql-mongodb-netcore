using CB.Core.Infrastructure.Repository;
using CB.Core.Interfaces.Models;
using GraphQL.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraphQL.API.Extensions
{
    public static class RepositoryExtensions
    {
        /// <summary>
        /// For resolving an issue "Entity Framework - An item with the same key has already been added".
        /// </summary>
        public static void MakeEntitiesIdUnique(this IEnumerable<IEntity> entities)
        {
            int index = 0;
            var enumerator = entities.GetEnumerator();
            if (enumerator != null)
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (current != null)
                    {
                        enumerator.Current.Id = index++;
                    }
                }
            }
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services, Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

                foreach (var type in classTypes)
                {
                    var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());
                    foreach (var handlerType in interfaces.Where(x => x.GetInterface(nameof(IRepository)) != null))
                    {
                        services.AddScoped(handlerType.AsType(), type.AsType());
                    }
                }
            }

            return services;
        }
    }
}
