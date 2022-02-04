using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// My Vector!!!!!!!
/// </summary>
[System.Serializable]
public struct Vector
{
    public float x;
    public float y;
    
    public Vector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }

    public Vector Add(Vector vector)
    {
        return new Vector(this.x + vector.x, this.y + vector.y);
    }
    public Vector Difference(Vector vector)
    {
        return new Vector(this.x - vector.x, this.y - vector.y);
    }
    public void Draw(Color color)
    {
        Vector2 vector = new Vector2(x, y);
        Debug.DrawRay(Vector2.zero, vector, color);
    }
    public void Draw(Color color, Vector origen)
    {
        Vector2 vector = new Vector2(x, y);
        Vector2 vector2 = new Vector2(origen.x, origen.y);
        Debug.DrawRay(vector2, vector, color);

    }

    public float DotProduct(Vector vector)
    {
        return ((vector.x * x) + (vector.y * y));
    }

    public Vector Escalar(float escalar)
    {
        return (new Vector(this.x * escalar, this.y * escalar));
    }
    public Vector Divide(float k)
    {
        if(k != 0)
        {
            return (new Vector(this.x /k, this.y /k));

        }
        return this;
    }

    public float Magnitud()
    {
        return Mathf.Sqrt((Mathf.Pow(this.x, 2) + Mathf.Pow(this.y, 2)));
    }

    public Vector Normalized()
    {
        return ( new Vector(X/this.Magnitud(),Y/ this.Magnitud()));
    }

    public static Vector Lerp(Vector initial,Vector final,float k)
    {
       
        //return initial.Add((final.Difference(initial).Escalar(k)));
        return initial + ((final - initial) * k);
    }
    public override string ToString()
    {
        return ("(" + x + "," + y + ")");
    }
    public static Vector operator +(Vector a, Vector b)
    {
        return a.Add(b);
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return a.Difference(b);
    }
    public static Vector operator *(Vector a, float b)
    {
        return a.Escalar(b);
    }
    public static Vector operator *(float a, Vector b)
    {
        return b.Escalar(a);
    }
    public static Vector operator /(Vector a,float b)
    {
        return a.Divide(b);
    }
 
}
