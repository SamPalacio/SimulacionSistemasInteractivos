using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionSeno : MonoBehaviour
{
    [SerializeField] GameObject point;
    List<GameObject> points;
    [SerializeField] [Range(0.2f, 50)] float separationFactor;
    [SerializeField, Range(-10, 10)] float amplitud;
    [SerializeField, Range(0.01f, 10)] float periodo;

    float time;
    public int nSamples;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        points = new List<GameObject>();    
        for (int i = 0; i < nSamples; i++)
        {
            points.Add(Instantiate(point, transform));
            points[i].transform.localPosition= Vector3.zero;
            points[i].transform.position = new Vector3(i / separationFactor, Mathf.Sin(i / separationFactor), 0);

        }

       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        for (int i = 0; i < nSamples; i++)
        {
            float x = (i /separationFactor);
            points[i].transform.position = new Vector3(x, (Mathf.Sin(2 * Mathf.PI * (x + time) / periodo))*amplitud, 0);

        }
    }
}
