using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public interface IMainMenuView
{
    IObservable<Unit> PlayClicked { get; }
    IObservable<Unit> CharactersClicked { get; }
    IObservable<Unit> ExitClicked { get; }
}

public sealed class MainMenuView : MonoBehaviour, IMainMenuView
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _charactersBtn;
    [SerializeField] private Button _exitBtn;

    public IObservable<Unit> PlayClicked => _playBtn.OnClickAsObservable();
    public IObservable<Unit> CharactersClicked => _charactersBtn.OnClickAsObservable();
    public IObservable<Unit> ExitClicked => _exitBtn.OnClickAsObservable();
}
