using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationsManager : MonoBehaviour {

    List<Dot> dots;
    List<Cluster> clusters;

    private float weightX, weightY, weightZ, threshold;
    private List<Color> clusterColors;

    public delegate float DistanceAction(Vector3 l, Vector3 p);

    public List<Vector3> originalCoordinates;

	// Use this for initialization
	void Start () {
        weightX = 1.0f; weightY = 1.0f; weightZ = 1.0f; threshold = 15.0f;
	}

    public void SetWeights(float x, float y, float z, float t)
    {
        weightX = x;
        weightY = y;
        weightZ = z;
        threshold = t;
    }

    public void Clusterize(DistanceAction FindDistance)
    {
        if (clusters != null)
            clusters.Clear();
        clusters = new List<Cluster>();

        Cluster firstCluster = new Cluster(0,clusterColors[0]);
        firstCluster.AddDot(dots[0]);
        clusters.Add(firstCluster);

        int numberOfClusters = 1;
        for (int i = 1; i < dots.Count; i++)
        { //for each dot
            int j = 0;
            List<Cluster> nearestClusters = new List<Cluster>();
            List<float> nearestClustersDistances = new List<float>();
            while (j < clusters.Count) //check each existing cluster
            {
                float distance = FindDistance(dots[i].Position, clusters[j].Center);
                if (distance < threshold)
                { //if the distance is small enough, add the cluster to the list of nearest clusters
                    Debug.Log("Dot " + i + " is close to the cluster " + j );
                    nearestClusters.Add(clusters[j]);
                    nearestClustersDistances.Add(distance);
                }
                j++;
            }
            if (nearestClusters.Count == 0)
            { //if no clusters nearby, create a new one
                Cluster newCluster = new Cluster(numberOfClusters, clusterColors[numberOfClusters]);
                numberOfClusters++;
                newCluster.AddDot(dots[i]);
                clusters.Add(newCluster);
            }
            else //if there are nearby clusters, find the closest one
            {
                nearestClusters[Calculator.MinID(nearestClustersDistances)].AddDot(dots[i]);
            }
        }
    }

    public void EuclidDistance()
    {
        Calculator.SetWeights(1, 1, 1);
        Clusterize(Calculator.EuclidDistance);
    }

    public void EuclidDistanceWeighted()
    {
        Calculator.SetWeights(weightX, weightY, weightZ);
        Clusterize(Calculator.EuclidDistance);
    }

    public void CanberraDistance()
    {
        Clusterize(Calculator.CanberraDistance);
    }

    public void Normalize()
    {
        Calculator.Normalise(dots);
    }

    public void SetDots(List<Dot> val)
    {
        dots = val;
    }

    public void SetClusterColors(List<Color> val)
    {
        clusterColors = val;
        Debug.Log(clusterColors);
    }


}
