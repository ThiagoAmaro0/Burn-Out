using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public static Action<int> OnGetScore;

    private void OnEnable()
    {
        OnGetScore += AddScore;
    }
    private void OnDisable()
    {
        OnGetScore -= AddScore;
    }

    private void AddScore(int value)
    {
        _score += value;
        _scoreText.text = $"Pontos: {_score}";
    }
}
