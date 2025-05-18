using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField] private float _duration = 0.25f;

    private CanvasGroup _cg;

    private void Awake() => _cg = GetComponent<CanvasGroup>();

    public void FadeIn() => _cg.DOFade(1f, _duration).From(0);
    public void FadeOut() => _cg.DOFade(0f, _duration);
}
