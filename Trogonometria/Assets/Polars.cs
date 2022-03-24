using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polars : MonoBehaviour
{

    [SerializeField] float r, theta;
    [SerializeField] Vector2 polarCoord;
    [Header("Angular")]
     float angularSpeed;
    [SerializeField] float angularAcceleration;
    [Header("Radial")]
     float radialSpeed;
    [SerializeField] float radialAcceleration;
   public  bool flip=true;


    // Update is called once per frame
    void Update()
    {


        angularSpeed += angularAcceleration * Time.deltaTime;
        radialSpeed += radialAcceleration * Time.deltaTime;
        polarCoord.y += angularSpeed * Time.deltaTime;
        polarCoord.x += radialSpeed * Time.deltaTime;

        Debug.Log(flip);

        Draw(polarCoord);
        if (Mathf.Abs(polarCoord.x) > 5)
        {
            polarCoord.x = 5*Mathf.Sign(polarCoord.x);
            radialSpeed = 0;
                if (Mathf.Abs(radialAcceleration) > 0)
            {
                radialAcceleration = -radialAcceleration;
            }
            else
            {
                radialSpeed = -radialSpeed;
            }
        }
    }

    private void Draw(Vector2 polar)
    {
        Vector2 coordenadasCartesianas= PolarToCartesian(polar);
        transform.position = coordenadasCartesianas;
        Debug.DrawLine(Vector3.zero, coordenadasCartesianas, Color.green);
    }
    Vector3 PolarToCartesian(Vector2 polar)
    {
        Vector2 coordenadasCartesianas;
        r = polar.x;
        theta = polar.y;
        coordenadasCartesianas = new Vector2(Mathf.Cos(theta) * polar.x, Mathf.Sin(theta) * polar.x);
        return coordenadasCartesianas;
    }

}
