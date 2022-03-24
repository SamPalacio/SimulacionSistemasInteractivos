using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLookAt : MonoBehaviour
{
    Vector3 displacement;
    Vector3 acceleration;
    [SerializeField] Vector3 velocity;
    public bool aceleration;
    public bool hasDisplacement;
    // Update is called once per frame
    void Update()
    {
        //transform.localPosition=GetWorldMousePosition();

        //float slope = mousePos.y / mousePos.x;
        //float radians =Mathf.Atan(slope);
        if (aceleration)
        {
            MovingWithAceleration();
        }
        else
        {
            Moving();

        }

        //Debug.DrawLine(Vector3.zero, transform.localPosition);
    }

    Vector3 GetWorldMousePosition()
    {
        Camera camera=Camera.main;
        Vector3 screenPos=new Vector3(Input.mousePosition.x, Input.mousePosition.y,camera.nearClipPlane);
        Vector4 worldPos=Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }


    public void Moving()

    {
        Vector3 mousePos = GetWorldMousePosition() - transform.position;
        acceleration = CalculateAceleration(mousePos);
        float radians = Mathf.Atan2(mousePos.y, mousePos.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
        if (hasDisplacement)
        {
            velocity = acceleration;
            displacement = velocity * Time.deltaTime;
            transform.position += displacement; // entregador de euler 
        }
       
        


      

    }
    public void MovingWithAceleration()
    {

        Vector3 mousePos = GetWorldMousePosition() - transform.position;
        acceleration = CalculateAceleration(mousePos);
        float radians = Mathf.Atan2(velocity.y, velocity.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);


        velocity += acceleration*Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position += displacement; // entregador de euler 

    }

    Vector3 CalculateAceleration(Vector3 center)
    {
        Vector3 acceleration = (center - this.transform.position);
        return acceleration;
    }

}
