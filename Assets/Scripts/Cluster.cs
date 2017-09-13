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
        dots.Add(dot);
        center = Calculator.AveragePoint(dots);
    }

    public List<Dot> Dots
    {
        get { return dots; }
    }

    public Vector3 Center
    {
        get {return center;}
    }
        

    public Color Color
    {
        get { return color; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

}
