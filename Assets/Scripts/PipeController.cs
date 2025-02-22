using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }
}
