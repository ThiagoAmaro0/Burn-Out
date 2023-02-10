using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private string[] _tutorialStrings;
    [SerializeField] private float _delay;
    [SerializeField] private TextMeshProUGUI _tutorialText;
    [SerializeField] private Color _color;
    // Start is called before the first frame update
    void Start()
    {
        ShowTutorial();
    }

    private void ShowTutorial()
    {
        StartCoroutine(Print(_tutorialStrings));
    }

    private IEnumerator Print(string[] msgs)
    {
        _tutorialText.color = new Color(_color.r, _color.g, _color.b, 0);
        foreach (string s in _tutorialStrings)
        {
            _tutorialText.text = s;
            yield return _tutorialText.DOColor(_color, 0.5f).WaitForCompletion();
            yield return new WaitForSeconds(_delay);
            yield return _tutorialText.DOColor(new Color(_color.r, _color.g, _color.b, 0), 0.5f).WaitForCompletion();
        }
    }
}
