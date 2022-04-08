using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMatrix : MonoBehaviour
{
    [SerializeField]private Transform someObject;
    [SerializeField] float rotationz = 0;
    [SerializeField] Vector3 scale = Vector3.one;

    void Update()
    {
       
            someObject.position = new Vector3(2, 2, 0);
            var myMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, rotationz), scale);
            var newPos = myMatrix.MultiplyVector(someObject.position);
            someObject.position = newPos;
        
       
    }
}
