using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text text;

    public void IncreaseScore()
    {
        score++;
        text.text = score.ToString();
    }
}
