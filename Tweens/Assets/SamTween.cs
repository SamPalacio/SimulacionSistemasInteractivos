using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamTween : MonoBehaviour
{

    [SerializeField] AnimationCurve curve;

    [SerializeField] float duration;
    [SerializeField]
    Vector3 startPosition;
    [SerializeField]
    Vector3 endPosition;
    public bool enableEaseOutQuart;
    private void Update()
    {
        float t = Time.time / duration;
        if (!enableEaseOutQuart)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(t));

        }
        else
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, easeOutQuart(t));

        }

    }

    float easeOutQuart(float x)
    {
     return 1 - Mathf.Pow(1 - x, 4);
    }

  
}