using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cluster  {

    private List<Dot> dots;
    private Vector3 center = new Vector3(0, 0, 0);
    private Color color;
    private int id = 0;

    public Cluster(int _id, Color col)
    {
        dots = new List<Dot>();
        color = col;
        id = _id;
    }

    public void AddDot(Dot dot)
    {
        dot.SetCluster(this);
        //dot.SetColor(color);
        dots.Add(dot);
        //Debug.Log("Dot color " + color);
        center = Calculator.AveragePoint(dots);
    }

    public List<Dot> GetDotList()
    {
        return dots;
    }

    public Vector3 GetCenter()
    {
        return center;
    }

    public Color GetColor()
    {
        return color;
    }

    public int GetID()
    {
        return id;
    }

    public void SetID(int val)
    {
        id = val;
    }

}
