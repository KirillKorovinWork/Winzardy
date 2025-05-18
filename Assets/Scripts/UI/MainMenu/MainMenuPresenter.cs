using VContainer.Unity;
using UniRx;
using System;
using UnityEngine;

public sealed class MainMenuPresenter : IInitializable, IDisposable
{
    private readonly IMainMenuView _view;
    private readonly CharacterSelectView _charView;
    private readonly CharacterSelectPresenter _charPresenter;
    private readonly SceneLoader _loader;

    private readonly CompositeDisposable _cd = new();

    public MainMenuPresenter(
        IMainMenuView view,
        CharacterSelectView charView,
        CharacterSelectPresenter charPresenter,
        SceneLoader loader)
    {
        _view = view;
        _charView = charView;
        _charPresenter = charPresenter;
        _loader = loader;
    }

    public void Initialize()
    {
        _view.PlayClicked
             .Subscribe(_ => StartGame())
             .AddTo(_cd);

        _view.CharactersClicked
             .Subscribe(_ => ShowCharacterSelect())
             .AddTo(_cd);

        _view.ExitClicked
             .Subscribe(_ => UnityEngine.Application.Quit())
             .AddTo(_cd);

        _charView.BackClicked
                 .Subscribe(_ => ShowMainMenu())
                 .AddTo(_cd);
    }

    private void StartGame()
    {
    }

    private void ShowCharacterSelect()
    {
        _charView.gameObject.SetActive(true);
        (_view as MonoBehaviour).gameObject.SetActive(false);
        _charPresenter.Refresh();
    }

    private void ShowMainMenu()
    {
        _charView.gameObject.SetActive(false);
        (_view as MonoBehaviour).gameObject.SetActive(true);
    }

    public void Dispose() => _cd.Dispose();
}
