using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ScaleEffect : MonoBehaviour, IPointerEnterHandler
{
    [Tooltip("Отклонение масштаба")]
    [SerializeField] private float _offsetScale = 0.95f;
    [Tooltip("Продолжительность")]
    [SerializeField] private float _duration = 0.3f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Scale();
    }

    private void Scale()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.SetDelay(0.3f);
        mySequence.Append(transform.DOScale(Vector3.one * _offsetScale, _duration));
        mySequence.Append(transform.DOScale(Vector3.one, _duration));
    }
}
