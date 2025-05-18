using UnityEngine;
using UnityEngine.UI;
using TMPro;                     
using UniRx;
using DG.Tweening;
using System;

public sealed class CharacterCardView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Slider _progress;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _name;   

    private void Awake()
    {
        if (_button == null) _button = GetComponent<Button>();
    }

    public IObservable<Unit> Clicked => _button.OnClickAsObservable();

    
    public void Bind(Sprite icon, float progress01, string name)
    {
        _icon.sprite = icon;
        _name.text = name;

        _progress.value = 0;
        _progress.DOValue(progress01, .4f).SetEase(Ease.InOutSine);
    }

    public void SetSelected(bool value)
    {
        _icon.transform.DOPunchScale(Vector3.one * 0.08f, 0.2f);
        _name.color = value ? Color.white : new Color(1f, 1f, 1f, 0.5f);
    }
}
