using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[ExecuteInEditMode]
public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] GameObject mark1;
    [SerializeField] GameObject mark2;
    //[SerializeField] GameObject cube;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(mark1.transform.position, mark2.transform.position);
        Debug.DrawLine(mark1.transform.position, mark2.transform.position);
        Debug.Log(mark1.GetComponent<ImageTargetBehaviour>());
        Debug.Log("Distance " + distance);
        //if (distance <= 0.2)
            //cube.SetActive(true);
        
            //cube.SetActive(false);
    }
}
