using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speedWhenSpace;

    [SerializeField]
    private Rigidbody2D rg;

    [SerializeField]
    private float degreesPerSecond;

    [SerializeField]
    private float rotationSpeed = 100f;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private AudioSource flyAudio;

    // private AudioSource swooshingAudio;

    [SerializeField]
    private GameObject flyAudioGameObject;

    [SerializeField]
    private GameObject swooshingAudioGameObject;

    public GameObject scoreManager;
    private Quaternion targetRotation;

    [SerializeField]
    private ReadyScreen readyScreen;
    public Animator animator;
    private SettingPanel settingPanel;

    void Start()
    {
        targetRotation = transform.rotation;
        flyAudioGameObject.SetActive(false);
        swooshingAudioGameObject.SetActive(false);
        readyScreen = FindFirstObjectByType<ReadyScreen>();
        animator = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        rg.isKinematic = true;
        settingPanel = FindObjectOfType<SettingPanel>();

        int soundOn = PlayerPrefs.GetInt("SoundOn", 1);
        if (soundOn == 0)
        {
            settingPanel.isSoundOn = false;
        }
        else
        {
            settingPanel.isSoundOn = true;
        }
    }

    void Update()
    {
        if (settingPanel != null && settingPanel.isSettingPanelOpen)
        {
            flyAudio.Pause();
            return;
        }

        if (readyScreen.isGameStart == false)
        {
            animator.enabled = false;
            rg.isKinematic = true;
            return;
        }
        else
        {
            rg.isKinematic = false;
            animator.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rg.AddForce(Vector2.up * speedWhenSpace);
                targetRotation = Quaternion.Euler(0, 0, degreesPerSecond);

                if (settingPanel.isSoundOn)
                {
                    flyAudioGameObject.SetActive(true);
                    flyAudio.Play();
                }
                else
                {
                    flyAudioGameObject.SetActive(false);
                    flyAudio.Pause();
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                targetRotation = Quaternion.Euler(0, 0, -10);
            }

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Game Over
        if (other.gameObject.CompareTag("Pipe"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            scoreManager.SetActive(false);

            if (settingPanel.isSoundOn)
            {
                swooshingAudioGameObject.SetActive(true);
            }
            else
            {
                swooshingAudioGameObject.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene(0);
        scoreManager.SetActive(true);
        Time.timeScale = 1;
    }
}
