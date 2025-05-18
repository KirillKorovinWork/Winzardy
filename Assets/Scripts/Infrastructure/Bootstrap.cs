using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Bootstrap : LifetimeScope
{
    [SerializeField] private string _firstScene = "MainMenu";

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SceneLoader>(Lifetime.Singleton);

        builder.RegisterEntryPoint<BootstrapEntryPoint>()
               .WithParameter("firstScene", _firstScene);
    }
}
