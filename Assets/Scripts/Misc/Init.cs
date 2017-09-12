using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

    [SerializeField] GameObject markPrefab;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] List<Vector3> dotsCoordinates;
    private List<Dot> dots;
    Color xColor;
    Color yColor;
    Color zColor;
    [SerializeField] private List<Color> clusterColors;

    void Start()
    {
        xColor = Color.red;
        yColor = Color.green;
        zColor = Color.blue;

        GameObject instantiated;
        for (int i = -31; i < 31; i++)
        {
            instantiated = Instantiate(markPrefab, new Vector3(i, 0, 0), transform.rotation);
            instantiated.GetComponent<Renderer>().material.color = xColor;
            instantiated.GetComponentInChildren<TextMesh>().text = string.Format("{0}",i);
        }
        for (int i = -31; i < 31; i++)
        {
            if (i != 0)
            {
                instantiated = Instantiate(markPrefab, new Vector3(0, i, 0), transform.rotation);
                instantiated.GetComponent<Renderer>().material.color = yColor;
                instantiated.GetComponentInChildren<TextMesh>().text = string.Format("{0}", i);
            }
        }
        for (int i = -31; i < 31; i++)
        {
            if (i != 0)
            {
                instantiated = Instantiate(markPrefab, new Vector3(0, 0, i), transform.rotation);
                instantiated.GetComponent<Renderer>().material.color = zColor;
                instantiated.GetComponentInChildren<TextMesh>().text = string.Format("{0}", i);
            }
        }

        dots = new List<Dot>();
        foreach (Vector3 dot in dotsCoordinates)
        {
            GameObject currentDot = Instantiate(dotPrefab, dot, transform.rotation);
            dots.Add(currentDot.GetComponent<Dot>());
        }

        GetComponent<CalculationsManager>().SetDots(dots);
        GetComponent<CalculationsManager>().SetClusterColors(clusterColors);
    }

    public void SetCoordinatesVisible(bool val)
    {
        foreach (Dot dot in dots)
        {
            dot.CoordinatesVisible(val);
        }
    }

    public void SetClusterIDVisible(bool val)
    {
        foreach (Dot dot in dots)
        {
            dot.ClusterVisible(val);
        }
    }
}
