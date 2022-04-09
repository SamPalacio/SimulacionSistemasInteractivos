using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    float randomX, randomY;
    private void Start()
    {
        randomX = Random.Range(-5, 5);
        randomY = Random.Range(-5, 5);
    }
    void Update()
    {
        transform.position = new Vector3( Mathf.Sin(Time.time) * randomY, Mathf.Cos(Time.time) * randomX, 0f);
    }
}
