using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject pipePrefab;
    public float maxTime;
    private float timer;
    public Vector3 positionSpawn;
    public float height;
    public List<GameObject> pipes;
    private ReadyScreen readyScreen;

    void Start()
    {
        positionSpawn = transform.position;
        timer = maxTime;
        readyScreen = FindFirstObjectByType<ReadyScreen>();
    }

    void Update()
    {
        if (readyScreen.isGameStart == false)
        {
            return;
        }
        else
        {
            if (timer > maxTime)
            {
                float randomDistance = Random.Range(1, 4);
                float randomHeight = Random.Range(-height, height);

                positionSpawn = new Vector3(randomDistance + transform.position.x, randomHeight + transform.position.y, 0);
                GameObject tmp = Instantiate(pipePrefab, positionSpawn,
                    Quaternion.identity);

                Destroy(tmp, 10);
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }
}