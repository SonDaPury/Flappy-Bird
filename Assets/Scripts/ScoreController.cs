using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public ScoreManager scoreManager;


    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        scoreManager = FindFirstObjectByType<ScoreManager>();
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManager.IncreaseScore();
        }

    }
}
