using VContainer.Unity;
using UniRx;
using System;
using System.Collections.Generic;

public sealed class CharacterSelectPresenter : IInitializable, IDisposable
{
    private readonly ICharacterSelectView _view;
    private readonly IReadOnlyList<CharacterModel> _models;
    private readonly CompositeDisposable _cd = new();

    private int _current;

    public CharacterSelectPresenter(ICharacterSelectView view, IReadOnlyList<CharacterModel> models)
    {
        _view = view;
        _models = models;
    }

    public void Initialize()
    {
        _view.ShowCharacters(_models);
        Select(0);

        _view.CharacterClickedIdx.Subscribe(Select).AddTo(_cd);
        _view.BackClicked.Subscribe(_ => UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu")).AddTo(_cd);
    }

    private void Select(int idx)
    {
        _current = idx;
        _view.HighlightCharacter(idx);
        _view.SetBigIcon(_models[idx].IconBig);
    }

    public void Refresh()
    {
        _view.ShowCharacters(_models);
        _view.HighlightCharacter(_current);
        _view.SetBigIcon(_models[_current].IconBig);
    }


    public void Dispose() => _cd.Dispose();
}
