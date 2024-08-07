using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    public bool isGameStart = false;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            isGameStart = true;
        }
    }
}
