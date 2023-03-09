using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultsPanel : MonoBehaviour
{
    [Header("Win Panel")]
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _winTitle;
    public List<CanvasGroup> _winCanvasGroup = new List<CanvasGroup>();
    public List<GameObject> _winStars = new List<GameObject>();
    public List<GameObject> _winIndicators = new List<GameObject>();

    [Header("Lose Panel")]
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject _loseTitle;
    public List<CanvasGroup> _loseCanvasGroup = new List<CanvasGroup>();
    public List<GameObject> _loseSkulls = new List<GameObject>();
    public List<GameObject> _loseIndicators = new List<GameObject>();

    private float fadeTime = 1f;

    public void StartWinAnimation()
    {
        HideWinGroup();

        RectTransform winTitle = _winTitle.GetComponent<RectTransform>();
        winTitle.localPosition = new Vector3(0f, 110f, 0f);
        Sequence mySequence = DOTween.Sequence();
        mySequence.SetDelay(0.3f);
        mySequence.SetEase(Ease.Linear);
        mySequence.Append(_winTitle.transform.DOScale(1.5f, 1f).SetEase(Ease.InOutElastic));
        mySequence.Append(_winTitle.transform.DOScale(1f, 1f).SetEase(Ease.InOutElastic));
        mySequence.Append(winTitle.DOAnchorPos(new Vector2(0f, 305f), 1f, false).SetEase(Ease.InOutQuint));
        mySequence.AppendCallback(ShowStars);
        
        DOVirtual.DelayedCall(4.5f, () =>
        {
            ShowWinIndicators();
        });
    }
    public void StartLoseAnimation()
    {
        HideLoseGroup();

        RectTransform loseTitle = _loseTitle.GetComponent<RectTransform>();
        loseTitle.localPosition = new Vector3(0f, 110f, 0f);
        Sequence mySequence = DOTween.Sequence();
        mySequence.SetDelay(0.3f);
        mySequence.SetEase(Ease.Linear);
        mySequence.Append(_loseTitle.transform.DOScale(1.5f, 1f).SetEase(Ease.InOutElastic));
        mySequence.Append(_loseTitle.transform.DOScale(1f, 1f).SetEase(Ease.InOutElastic));
        mySequence.Append(loseTitle.DOAnchorPos(new Vector2(0f, 305f), 1f, false).SetEase(Ease.InOutQuint));
        mySequence.AppendCallback(ShowSkulls);

        DOVirtual.DelayedCall(4.5f, () =>
        {
            ShowLoseIndicators();
        });
    }

    private void HideWinGroup()
    {
        for (int i = 0; i < _winCanvasGroup.Count; i++)
        {
            var canvasGroup = _winCanvasGroup[i];

            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
            }
        }
    }

    private void HideLoseGroup()
    {
        for (int i = 0; i < _loseCanvasGroup.Count; i++)
        {
            var canvasGroup = _loseCanvasGroup[i];

            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
            }
        }
    }

    private void ShowStars()
    {
        var canvasGroup = _winCanvasGroup[0];
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1, fadeTime);
            StartCoroutine(nameof(WinStarsAnimation));
        }
    }

    private void ShowSkulls()
    {
        var canvasGroup = _loseCanvasGroup[0];
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1, 2f);
            foreach (var iSkull in _loseSkulls)
            {
                Shake(iSkull);
            }
        }
    }

    private void ShowWinIndicators()
    {
        var canvasGroup = _winCanvasGroup[1];
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1, fadeTime);
            StartCoroutine(nameof(WinIndicatorsAnimation));
        }
    }

    private void ShowLoseIndicators()
    {
        var canvasGroup = _loseCanvasGroup[1];
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1, fadeTime);
            StartCoroutine(nameof(LoseIndicatorsAnimation));
        }
    }

    IEnumerator WinStarsAnimation()
    {
        foreach (var item in _winStars)
        {
            item.transform.localScale = Vector3.zero;
        }

        foreach (var item in _winStars)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.InOutElastic);
            yield return new WaitForSeconds(0.7f);
        }
    }

    IEnumerator WinIndicatorsAnimation()
    {
        foreach (var item in _winIndicators)
        {
            item.transform.localScale = Vector3.zero;
        }

        foreach (var item in _winIndicators)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.InOutElastic);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator LoseIndicatorsAnimation()
    {
        foreach (var item in _loseIndicators)
        {
            item.transform.localScale = Vector3.zero;
        }

        foreach (var item in _loseIndicators)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.InOutElastic);
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    private void Shake(GameObject obj)
    {
        float duration = 0.5f;
        float strength = 0.5f;

        obj.transform.DOScale(Vector3.one, 0.1f);
        obj.transform.DOShakeScale(duration, strength);
    }
}
