using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using System;
using System.Collections.Generic;

public interface ICharacterSelectView
{
    IObservable<Unit> BackClicked { get; }
    IObservable<int> CharacterClickedIdx { get; }

    void ShowCharacters(IReadOnlyList<CharacterModel> models);
    void HighlightCharacter(int index);
    void SetBigIcon(Sprite sprite);
}

public sealed class CharacterSelectView : MonoBehaviour, ICharacterSelectView
{
    [SerializeField] private Image _bigIcon;
    [SerializeField] private Transform _gridRoot;
    [SerializeField] private CharacterCardView _cardPrefab;
    [SerializeField] private Button _backBtn;

    private readonly Subject<int> _clicked = new();
    private readonly List<CharacterCardView> _cards = new();

    public IObservable<Unit> BackClicked => _backBtn.OnClickAsObservable();
    public IObservable<int> CharacterClickedIdx => _clicked;

    public void ShowCharacters(IReadOnlyList<CharacterModel> models)
    {
        foreach (Transform child in _gridRoot) Destroy(child.gameObject);
        _cards.Clear();

        for (int i = 0; i < models.Count; i++)
        {
            var card = Instantiate(_cardPrefab, _gridRoot);
            float pct = models[i].CurrentExp / models[i].ExpToNext;

            card.Bind(models[i].IconSmall, pct, models[i].LocalizedName);

            int captured = i;
            card.Clicked.Subscribe(_ => _clicked.OnNext(captured)).AddTo(this);
            _cards.Add(card);
        }

    }

    public void HighlightCharacter(int index)
    {
        for (int i = 0; i < _cards.Count; i++)
            _cards[i].SetSelected(i == index);
    }

    public void SetBigIcon(Sprite sprite)
    {
        _bigIcon.DOFade(0, .15f).OnComplete(() =>
        {
            _bigIcon.sprite = sprite;
            _bigIcon.DOFade(1, .15f);
        });
    }
}
