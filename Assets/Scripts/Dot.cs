using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

    private SpriteRenderer glowSprite;
    [SerializeField] private TextMesh coordinatesText;
    [SerializeField] private TextMesh clusterText;
    private Cluster currentCluster;

	// Use this for initialization
	void Start () {
        glowSprite = GetComponentInChildren<SpriteRenderer>();
        UpdateIndicators();
	}

    public void SetCluster(Cluster val)
    {
        currentCluster = val;
        glowSprite.color = currentCluster.Color;
        UpdateIndicators();
    }

    public void CoordinatesVisible (bool val)
    {
        coordinatesText.gameObject.SetActive(val);
    }

    public void ClusterVisible (bool val)
    {
        clusterText.gameObject.SetActive(val);
    }

    void UpdateIndicators()
    {
        coordinatesText.text = "(" + (Mathf.Round(transform.position.x * 10f) / 10f) + "," + (Mathf.Round(transform.position.y * 10f) / 10f) + "," + (Mathf.Round(transform.position.z * 10f) / 10f) + ")";
        if (currentCluster != null)
            clusterText.text = "[" + currentCluster.Id + "]";
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set 
        { 
            transform.position = value;
            UpdateIndicators();
        }
    }

    public float X
    {
        get { return transform.position.x; }
        set
        {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
            UpdateIndicators();
        }
    }

    public float Y
    {
        get { return transform.position.y; }
        set
        {
            transform.position = new Vector3(transform.position.x, value, transform.position.z);
            UpdateIndicators();
        }
    }

    public float Z
    {
        get { return transform.position.z; }
        set
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, value);
            UpdateIndicators();
        }
    }

}
