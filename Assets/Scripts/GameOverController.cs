using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    private TextMeshProUGUI text;

    private ScoreManager scoreManager;
    private ScoreManager[] gameObjects;

    void Start()
    {
        gameObjects = FindObjectsOfType<ScoreManager>(true);
        foreach (ScoreManager score in gameObjects)
        {
            if (score.gameObject.name == "ScoreManager")
            {
                this.scoreManager = score;
                return;
            }
        }

        Debug.Log(scoreManager);
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            text = GetComponent<TextMeshProUGUI>();
            text.text = "Score: " + scoreManager.score.ToString();
        }
    }
}
