using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 displacement;
    Vector3 acceleration;

    //[SerializeField] [Range(0,1)]float frictionCoefficient;
    //[SerializeField] Vector3 weight;
    [SerializeField]  Vector3 velocity;
    [SerializeField] float mass = 1;
    [SerializeField] GameObject centerM;
    new CircleCollider2D collider;
    //[SerializeField] Transform center;
    //[Range(0,1)] [SerializeField] float damping=1;
    //public bool hasGravityAtraction;
    //public bool borders;
    //Vector3 friction;


    public bool orbital;
    Vector3 orbitalForce;
    Vector3 d;


    [SerializeField] float g, m2;



    private void Start()
    {
        collider= GetComponent<CircleCollider2D>();
        
    }
    void Update()
    {

        if (orbital)
        {
            d = centerM.transform.position - transform.position;
            orbitalForce = ((g * mass * m2) / (d.magnitude * d.magnitude)) * d.normalized;
            ApplyForce(orbitalForce);
        }
        //else
        //{
        //    weight = Vector3.up * (mass * -9.81f);
        //    ApplyForce(weight);
        //    if (transform.position.y <= 0)
        //    {
        //        friction = -(frictionCoefficient * 17 * velocity.normalized);
        //        ApplyForce(friction);

        //    }
        //    if (borders)
        //    {
        //        CheckBorder();
        //    }
        //}
        Moving();




        DrawVelocity();
        DrawAcceleration();
        DrawPosition();
        acceleration = Vector3.zero;
    }

    public void Moving()
    {
        //if (hasGravityAtraction)
        //{
        //    acceleration = CalculateAceleration(center.position);

        //}
       
        velocity += acceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position += displacement; // entregador de euler 
        
    }

    //public void CheckBorder()
    //{
    //    if (transform.position.x >= 5-collider.radius )
    //    {
    //        velocity.x *= -1*damping;
    //        transform.position = new Vector3(5 - collider.radius, transform.position.y, 0);


    //    }
    //    else if(transform.position.x <= -5 + collider.radius)
    //    {

    //        velocity.x *= -1 * damping;
    //        transform.position = new Vector3(-5 + collider.radius, transform.position.y, 0);


    //    }
    //    else if (transform.position.y <= -5 + collider.radius)
    //    {
    //        velocity.y*= -1*damping;
    //        transform.position = new Vector3(transform.position.x, -5 + collider.radius, 0);

    //    }
    //    else if(transform.position.y >= 5 - collider.radius)
    //    {
    //        velocity.y *= -1 * damping;
    //        transform.position = new Vector3(transform.position.x, 5 - collider.radius, 0);

    //    }
    //}

     void DrawVelocity()
    {

        Debug.DrawLine(transform.position, velocity);

    }

    void DrawAcceleration()
    {
        Debug.DrawLine(transform.position, transform.position+ acceleration, Color.red);

    }

    void DrawPosition()
    {
        Debug.DrawLine(Vector3.zero, this.transform.position, Color.yellow);
    }

    Vector3 CalculateAceleration(Vector3 center)
    {
        Vector3 acceleration = (center-this.transform.position);
        return acceleration;
    }
    void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    
}
