using UnityEngine;
using VContainer;
using VContainer.Unity;
using System.Collections.Generic;

public class MainMenuInstaller : LifetimeScope
{
    [Header("Views")]
    [SerializeField] private MainMenuView _mainView;
    [SerializeField] private CharacterSelectView _charView;

    [Header("Character Data")]
    [SerializeField] private CharacterConfig[] _configs;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_mainView).As<IMainMenuView>();
        builder.RegisterComponent(_charView).As<ICharacterSelectView>();  

        var models = new CharacterModel[_configs.Length];
        for (int i = 0; i < _configs.Length; i++)
        {
            var c = _configs[i];
            models[i] = new CharacterModel
            {
                Id = c.Id,
                LocalizedName = c.LocalizedName,
                IconSmall = c.IconSmall,
                IconBig = c.IconBig,
                Level = c.Level,
                CurrentExp = c.CurrentExp,
                ExpToNext = c.ExpToNext
            };
        }
        builder.RegisterInstance<IReadOnlyList<CharacterModel>>(models);

        builder.Register<SceneLoader>(Lifetime.Singleton);

        builder.Register<CharacterSelectPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<CharacterSelectPresenter>();
        builder.RegisterEntryPoint<MainMenuPresenter>();
    }
}
