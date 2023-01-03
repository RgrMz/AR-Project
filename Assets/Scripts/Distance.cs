using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject neon1;
    public GameObject neon2;
    public GameObject cylinder;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(sphere1.transform.position, sphere2.transform.position);
        //  Horse.SetActive(false);
        if (distance > 0.05)
        {
            cylinder.SetActive(false);
            neon1.SetActive(false);
            neon2.SetActive(false);
        }
        else if (0.05 > distance)
        {
            cylinder.SetActive(true);
            neon1.SetActive(true);
            neon2.SetActive(true);
        }

        //Debug.Log(distance);
    }
}
