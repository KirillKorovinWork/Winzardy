using UnityEngine;
using VContainer;
using VContainer.Unity;
using System.Collections.Generic;

public class CharacterSelectInstaller : LifetimeScope
{
    [SerializeField] private CharacterSelectView _view;
    [SerializeField] private CharacterConfig[] _configs;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_view).As<ICharacterSelectView>();

        var models = new CharacterModel[_configs.Length];
        for (int i = 0; i < _configs.Length; i++)
        {
            CharacterConfig c = _configs[i];
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
        builder.Register<CharacterSelectPresenter>(Lifetime.Scoped);
    }
}
