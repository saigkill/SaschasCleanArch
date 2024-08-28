using Ardalis.GuardClauses;
using Autofac;

namespace SaschasCleanArch.DependencyInjection;

public class PresentationModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		Guard.Against.Null(builder);
	}
}
