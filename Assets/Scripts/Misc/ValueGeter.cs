using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueGeter : MonoBehaviour {

    [SerializeField] private InputField weightX;
    [SerializeField] private InputField weightY;
    [SerializeField] private InputField weightZ;
    [SerializeField] private InputField threshold;
    private CalculationsManager calculationsManager;
    //[SerializeField] private RectTransform inputs;

	// Use this for initialization
	void Start () {
        calculationsManager = GetComponent<CalculationsManager>();
	}

    public void UpdateValues()
    {
        float valueX, valueY, valueZ, valueThreshold;
        valueX = float.Parse(weightX.text);
        valueY = float.Parse(weightY.text);
        valueZ = float.Parse(weightZ.text);
        valueThreshold = float.Parse(threshold.text);;
        calculationsManager.SetWeights(valueX, valueY, valueZ, valueThreshold);
        Debug.Log(valueX + " "+ valueY + " " + valueZ + " " + valueThreshold);
    }
	

}
