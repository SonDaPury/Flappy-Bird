using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public ReadyScreen readyScreen;
    public GameObject pointSoundPrefab;
    private GameObject pointSoundInstance;
    public AudioSource pointAudio;

    void Start()
    {
        pointSoundInstance = Instantiate(pointSoundPrefab);
        pointAudio = pointSoundInstance.GetComponent<AudioSource>();
        pointSoundInstance.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        if (other.gameObject.CompareTag("Player"))
        {
            pointSoundInstance.SetActive(true);
            pointAudio.Play();
            scoreManager.IncreaseScore();
        }
    }
}
