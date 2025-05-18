using VContainer;
using VContainer.Unity;

public sealed class BootstrapEntryPoint : IStartable
{
    private readonly SceneLoader _loader;
    private readonly string _firstScene;

    [Inject]
    public BootstrapEntryPoint(SceneLoader loader, string firstScene)
    {
        _loader = loader;
        _firstScene = firstScene;
    }

    public void Start()
    {
        _loader.Load(_firstScene);
    }
}
