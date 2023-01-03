using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public GameObject compatibleCube;

    public GameObject neonRedThis;

    public GameObject neonRedOther;
    public GameObject neonGreenThis;

    public GameObject neonGreenOther;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("awachinao antes del if");
        if (other.gameObject.Equals(compatibleCube))
        {
            Debug.Log("awachinao despues del if");
            neonRedThis.SetActive(false);
            neonRedOther.SetActive(false);
            neonGreenThis.SetActive(true);
            neonGreenOther.SetActive(true);
        }
        else
        {
            neonGreenThis.SetActive(false);
            neonGreenOther.SetActive(false);
            neonRedThis.SetActive(true);
            neonRedOther.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(compatibleCube))
        {
            neonGreenThis.SetActive(false);
            neonGreenOther.SetActive(false);
            neonRedThis.SetActive(false);
            neonRedOther.SetActive(false);
        }
    }
}
