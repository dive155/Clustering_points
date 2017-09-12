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
        glowSprite.color = currentCluster.GetColor();
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
            clusterText.text = "[" + currentCluster.GetID() + "]";
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector3 val)
    {
        transform.position = val;
        UpdateIndicators();
    }

    public float GetX()
    {
        return transform.position.x;
    }

    public float GetY()
    {
        return transform.position.y;
    }

    public float GetZ()
    {
        return transform.position.z;
    }

    public void SetX(float val)
    {
        transform.position = new Vector3(val, transform.position.y, transform.position.z);
        UpdateIndicators();
    }

    public void SetY(float val)
    {
        transform.position = new Vector3(transform.position.x, val, transform.position.z);
        UpdateIndicators();
    }

    public void SetZ(float val)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, val);
        UpdateIndicators();
    }

}
