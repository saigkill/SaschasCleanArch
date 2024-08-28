using Ardalis.GuardClauses;
using Autofac;

namespace SaschasCleanArch.DependencyInjection;

public class ApplicationModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		Guard.Against.Null(builder);
	}
}
