using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Vector myVector ;
    [SerializeField] Vector myVector2 ;
    Vector myVector3 ;
    Vector myVector4;
    Vector myVector5;
    [Range(0, 1)]
    public float range;
    
    float dotProduct;
    float magnitud;
    private void Start()
    {
        myVector = new Vector(2, 2);
        
        
        myVector2 = new Vector(-1, 3);

        myVector3= myVector2-myVector;

        myVector.Draw(Color.red);
        myVector2.Draw(Color.green);
        myVector3.Draw(Color.yellow, myVector2);

        //myVector3= myVector.Add(myVector2);
        //Vector myVector4 = myVector.Difference(myVector2);
        //Debug.Log(myVector4);
        //dotProduct = myVector.DotProduct(myVector2);
        //Debug.Log("Dot product:"+dotProduct);
        //magnitud = myVector.Magnitud();
        //Debug.Log("Magnitud: " + magnitud);
        //Debug.Log("Magnitud: " + myVector.Normalized().Magnitud());


    }

    void Update()
    {

        

        //myVector3 = myVector2.Difference(myVector).Escalar(range);
        myVector3 = (myVector2-myVector)*range;
        myVector4 = Vector.Lerp(myVector,myVector2, range);
        Debug.Log(myVector4);
       
        Debug.Log(myVector3);
        myVector.Draw(Color.red);
        myVector2.Draw(Color.green);
        myVector4.Draw(Color.yellow);

      

        myVector3.Draw(Color.blue,myVector);
        //myVector.Draw(Color.red);
        //myVector2.Draw(Color.red);
        //myVector3.Draw(Color.black);
        //myVector.Draw(Color.green, myVector2);
    }
}
