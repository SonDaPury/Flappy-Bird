using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedWhenSpace;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float degreesPerSecond;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private AudioSource flyAudio;
    [SerializeField] private GameObject flyAudioGameObject;

    public GameObject scoreManager;
    private Quaternion targetRotation;

    void Start()
    {
        Time.timeScale = 1;
        targetRotation = transform.rotation;
        flyAudioGameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flyAudioGameObject.SetActive(true);
            rg.AddForce(Vector2.up * speedWhenSpace);
            targetRotation = Quaternion.Euler(0, 0, degreesPerSecond);
            flyAudio.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            targetRotation = Quaternion.Euler(0, 0, -10);
        }

        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        // Game Over
        if (other.gameObject.CompareTag("Pipe"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            scoreManager.SetActive(false);
        }
    }

    public void Restart()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene(0);
        scoreManager.SetActive(true);
    }
}