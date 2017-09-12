using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator  {

    static float coefX = 1.0f; 
    static float coefY = 1.0f; 
    static float coefZ = 1.0f;

    public static void Boo()
    {
        Debug.Log("Boo");
    }

    //public static float EuclidDistance (Vector3 l, Vector3 p, float coefX = 1.0f, float coefY = 1.0f, float coefZ = 1.0f)
    public static float EuclidDistance (Vector3 l, Vector3 p)
    {
        float result = Mathf.Sqrt( (coefX*(l.x - p.x) * (l.x - p.x)) + (coefY*(l.y - p.y) * (l.y - p.y)) + (coefZ*(l.z - p.z) * (l.z - p.z)));
        Debug.Log(string.Format("Euclid distance between l = {0} and p = {1} equals {2}", l, p, result));
        return result;
    }
        

    public static float CanberraDistance (Vector3 l, Vector3 p)
    {
        float result = (Mathf.Abs(l.x - p.x) / Mathf.Abs(l.x + p.x)) + 
                       (Mathf.Abs(l.y - p.y) / Mathf.Abs(l.y + p.y)) + 
                       (Mathf.Abs(l.z - p.z) / Mathf.Abs(l.z + p.z));
        Debug.Log(string.Format("Canberra distance between l = {0} and p = {1} equals {2}", l, p, result));
        return result;
    }

    public static Vector3 AveragePoint (List<Vector3> coordinates)
    {
        float coef = 1.0f / (float)(coordinates.Count);

        float sumX, sumY, sumZ;
        sumX = 0.0f; sumY = 0.0f; sumZ = 0.0f;
        for (int i = 0; i < coordinates.Count; i++)
        {
            sumX += coef * coordinates[i].x;
            sumY += coef * coordinates[i].y;
            sumZ += coef * coordinates[i].z;
        }
        Vector3 result = new Vector3(sumX, sumY, sumZ);
        Debug.Log(string.Format("Average dot of a cluster is at {0}", result));
        return result;
    }

    public static Vector3 AveragePoint(Cluster cluster)
    {
        return AveragePoint(cluster.GetDotList());
    }

    public static Vector3 AveragePoint (List<Dot> dotList)
    {
        List<Vector3> coordinates = new List<Vector3>();
        foreach (Dot aDot in dotList)
        {
            coordinates.Add(aDot.GetPosition());
        }
        return AveragePoint(coordinates);
    }
        

    public static void SetWeights(float x, float y, float z)
    {
        coefX = x;
        coefY = y;
        coefZ = z;
    }

    public static void Normalise (List<Dot> dots)
    {
        float maxX = Mathf.NegativeInfinity;
        float minX = Mathf.Infinity;
        float maxY = Mathf.NegativeInfinity;
        float minY = Mathf.Infinity;
        float maxZ = Mathf.NegativeInfinity;
        float minZ = Mathf.Infinity;
        for (int i = 0; i < dots.Count; i++)
        {
            Dot cur = dots[i];
            if (cur.GetPosition().x > maxX)
                maxX = cur.GetPosition().x;
            if (cur.GetPosition().x < minX)
                minX = cur.GetPosition().x;
            if (cur.GetPosition().y > maxY)
                maxY = cur.GetPosition().y;
            if (cur.GetPosition().y < minY)
                minY = cur.GetPosition().y;
            if (cur.GetPosition().z > maxZ)
                maxZ = cur.GetPosition().z;
            if (cur.GetPosition().z < minZ)
                minZ = cur.GetPosition().z;
        }
        //Debug.Log();
        for (int i = 0; i < dots.Count; i++)
        {
            Dot cur = dots[i];
            Debug.Log("curx " + cur.GetX() + " maxx " + maxX + " minx " + minX);
            cur.SetX( 10 * (cur.GetX() - minX) / (maxX - minX) );
            cur.SetY( 10 * (cur.GetY() - minY) / (maxY - minY) );
            cur.SetZ( 10 * (cur.GetZ() - minZ) / (maxZ - minZ) );
        }

    }

    public static int MinID (List<float> theList)
    {
        float min = Mathf.Infinity;
        int minID = 0;
        for (int i = 0; i < theList.Count; i++)
        {
            if (theList[i] < min)
            {
                min = theList[i];
                minID = i;
            }
        }
        return minID;
    }
        

}
