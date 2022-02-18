using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 displacement;
    [SerializeField] Vector3 aceleration;
    [SerializeField]  Vector3 velocity;
    new SphereCollider collider;
    [SerializeField] Transform center;
    [Range(0,1)] [SerializeField] float damping=1;
    public bool hasGravityAtraction;
    public bool borders;
    private void Start()
    {
        collider= GetComponent<SphereCollider>();
    }
    void Update()
    {

        Moving();
        if (borders)
        {
            CheckBorder();
        }
       
        DrawVelocity();
        DrawAceleration();
        DrawPosition();
    }

    public void Moving()
    {
        if (hasGravityAtraction)
        {
            aceleration = CalculateAceleration(center.position);

        }
       
        velocity += aceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
       

        transform.position += displacement; // entregador de euler 
        
    }

    public void CheckBorder()
    {
        if (transform.position.x >= 5-collider.radius )
        {
            velocity.x *= -1*damping;
            transform.position = new Vector3(5 - collider.radius, transform.position.y, 0);


        }
        else if(transform.position.x <= -5 + collider.radius)
        {

            velocity.x *= -1 * damping;
            transform.position = new Vector3(-5 + collider.radius, transform.position.y, 0);


        }
        else if (transform.position.y <= -5 + collider.radius)
        {
            velocity.y*= -1*damping;
            transform.position = new Vector3(transform.position.x, -5 + collider.radius, 0);

        }
        else if(transform.position.y >= 5 - collider.radius)
        {
            velocity.y *= -1 * damping;
            transform.position = new Vector3(transform.position.x, 5 - collider.radius, 0);

        }
    }

     void DrawVelocity()
    {
     
        Debug.DrawLine(transform.position, velocity);

    }

    void DrawAceleration()
    {
        Debug.DrawLine(transform.position, transform.position+aceleration, Color.red);

    }

    void DrawPosition()
    {
        Debug.DrawLine(Vector3.zero, this.transform.position, Color.yellow);
    }

    Vector3 CalculateAceleration(Vector3 center)
    {
        Vector3 aceleration=(center-this.transform.position);
        return aceleration;
    }
}
