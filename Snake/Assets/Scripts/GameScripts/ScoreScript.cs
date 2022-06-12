using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    private int _score = 0;

    private void FixedUpdate()
    {
        ScoreText.text = $"Score: {_score}";
    }

    public void ScoreIncrement()
    {
        _score++;
    }
}
