using Documentos.Application.Interfaces;
using Documentos.Application.Mappings;
using Documentos.Application.Services;
using Documentos.Domain.Interfaces;
using Documentos.Infra.Data.Context;
using Documentos.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Npgsql;
using System;

namespace Documentos.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionStringDocumento
        )
        {
            services.AddScoped<IDbConnectionDocumento>(c => new DbConnectionCommon(new NpgsqlConnection(connectionStringDocumento)));

            services.AddScoped<IDocumentoRepository, DocumentoRepository>();

            services.AddScoped<IDocumentoService, DocumentoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("Documentos.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
