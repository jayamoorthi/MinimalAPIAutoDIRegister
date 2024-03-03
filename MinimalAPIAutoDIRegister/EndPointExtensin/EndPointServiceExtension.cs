
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using System.Reflection;

public static class EndPointServiceExtension
{
    public static IServiceCollection AddEndPoints(this IServiceCollection  services, Assembly assembly)
    {
        ServiceDescriptor[] serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndPoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndPoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(
    this WebApplication app)
    {
        IEnumerable<IEndPoint> endpoints = app.Services
            .GetRequiredService<IEnumerable<IEndPoint>>();

        IEndpointRouteBuilder builder = app
            ;
        foreach (IEndPoint endpoint in endpoints)
        {
            endpoint.MapEndPoint(builder);
        }

        return app;
    }


    // RouteGroupBuilder feature in .net 8, currently using .net 6/7, so commented if that lib is doesn't exist 
    //public static IApplicationBuilder MapEndpoints(
    //this WebApplication app,
    //RouteGroupBuilder? routeGroupBuilder = null)
    //{
    //    IEnumerable<IEndPoint> endpoints = app.Services
    //        .GetRequiredService<IEnumerable<IEndPoint>>();

    //    IEndpointRouteBuilder builder =
    //        routeGroupBuilder is null ? app : routeGroupBuilder;

    //    foreach (IEndPoint endpoint in endpoints)
    //    {
    //        endpoint.MapEndPoint(builder);
    //    }

    //    return app;
    //}

}

