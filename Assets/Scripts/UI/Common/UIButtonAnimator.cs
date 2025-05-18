using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class UIButtonAnimator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _punchStrength = 0.1f;
    [SerializeField] private float _duration = 0.15f;

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOPunchScale(Vector3.one * _punchStrength, _duration)
                 .SetEase(Ease.OutQuad);
    }

    public void OnPointerUp(PointerEventData eventData) { }   // можно добавить логику, если нужна
}
