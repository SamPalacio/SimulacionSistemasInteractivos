using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid : MonoBehaviour
{
    Vector3 displacement;
    Vector3 acceleration;
    [SerializeField] [Range(0, 1)] float DragCoefficient;
    [SerializeField] Vector3 weight;
    [SerializeField] Vector3 velocity;
    [SerializeField] float mass = 1;
    float area;
    Vector3 friction;
    Vector3 fluidForce;
    private void Start()
    {
        area=transform.localScale.x;
    }
    void Update()
    {
        weight = Vector3.up * (mass * -9.81f);
        ApplyForce(weight);

        if (transform.position.y <= 0)
        {
            fluidForce = -(((velocity.magnitude) * (velocity.magnitude)) * area * DragCoefficient * velocity.normalized)/2;
            Debug.Log(fluidForce);

            ApplyForce(fluidForce);
        }
            
        
        Moving();

        acceleration = Vector3.zero;
    }

    public void Moving()
    {

        velocity += acceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position += displacement; // entregador de euler 

    }

    
    void DrawVelocity()
    {

        Debug.DrawLine(transform.position, velocity);

    }

    void DrawAcceleration()
    {
        Debug.DrawLine(transform.position, transform.position + acceleration, Color.red);

    }

    void DrawPosition()
    {
        Debug.DrawLine(Vector3.zero, this.transform.position, Color.yellow);
    }

    Vector3 CalculateAceleration(Vector3 center)
    {
        Vector3 acceleration = (center - this.transform.position);
        return acceleration;
    }
    void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

}
