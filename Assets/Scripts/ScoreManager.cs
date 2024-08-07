using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text text;
    public ReadyScreen readyScreen;

    void Start()
    {
        readyScreen = FindObjectOfType<ReadyScreen>();
    }

    void Update()
    {
        if (readyScreen.isGameStart == false)
        {
            text.enabled = false;
            return;
        }
        else
        {
            text.enabled = true;
        }
    }

    public void IncreaseScore()
    {
        score++;
        text.text = score.ToString();
    }
}
