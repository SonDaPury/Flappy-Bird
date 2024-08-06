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

    void Start()
    {
        positionSpawn = transform.position;
        timer = maxTime;
    }

    void Update()
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