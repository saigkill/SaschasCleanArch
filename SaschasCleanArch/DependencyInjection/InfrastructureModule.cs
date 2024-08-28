using Application.Services;
using Ardalis.GuardClauses;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace SaschasCleanArch.DependencyInjection;

public class InfrastructureModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		Guard.Against.Null(builder);
		builder.RegisterType<ConsoleService>().As<IHostedService>().InstancePerLifetimeScope();
	}
}
