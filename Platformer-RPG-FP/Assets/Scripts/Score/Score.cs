using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    private float score;

    public int IntScore => Mathf.RoundToInt(score);

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        score += scoreMultiplier * Time.deltaTime;
        scoreText.text = IntScore.ToString();

        if (IntScore >= 10)
        {
            scoreMultiplier = 100f;
        }
    }
}
