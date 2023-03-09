using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class LevelPanel : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject _panelObject;
    [SerializeField] private Image _background;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Fade(_panelObject);
    }

    private void Shake(GameObject obj)
    {
        float duration = 0.5f;
        float strength = 0.2f;

        obj.transform.DOScale(Vector3.one, 0.1f);
        obj.transform.DOShakeScale(duration, strength);
    }

    private void Fade(GameObject obj)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.SetDelay(0.3f);
        mySequence.Append(obj.transform.DOScale(Vector3.one * 0.95f, 0.3f));
        mySequence.Append(obj.transform.DOScale(Vector3.one, 0.3f));

        //mySequence.Append(obj.GetComponent<Image>().DOFade(0.5f, 0.3f));
        //mySequence.Append(obj.GetComponent<Image>().material.DOFade(1f, 0.3f));

        //float duration = 0.5f;
        //float strength = 0.2f;
        //obj.transform.DOScale(Vector3.one, 0.1f);
        //obj.transform.DOShakeScale(duration, strength);
    }
}
