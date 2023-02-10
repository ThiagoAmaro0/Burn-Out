using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Marshmallow : MonoBehaviour
{
    [SerializeField] private Color _burnedColor;
    private Tween _idleAnim;

    // Start is called before the first frame update
    void Start()
    {
        _idleAnim = transform.DORotate(transform.eulerAngles + new Vector3(0, 360, 0), 3, RotateMode.FastBeyond360);
        _idleAnim.SetEase(Ease.Linear);
        _idleAnim.SetLoops(-1);
        _idleAnim.Play();
    }

    public void Collect()
    {
        ScoreManager.OnGetScore?.Invoke(1);
        StartCoroutine(CollectAnim());
    }

    private IEnumerator CollectAnim()
    {
        _idleAnim.Kill();
        Tween endTween = transform.DORotate(transform.eulerAngles + new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360);
        endTween.SetEase(Ease.InCubic);
        endTween.SetLoops(-1);
        endTween.Play();
        transform.GetComponentInChildren<Renderer>().material.DOColor(_burnedColor, 1);
        yield return transform.DOMoveY(2, 1).WaitForCompletion();
        yield return transform.DOScale(0.01f, 0.5f).WaitForCompletion();
        endTween.Kill();
        Destroy(gameObject);
    }
}
