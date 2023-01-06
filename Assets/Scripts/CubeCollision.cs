using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public GameObject compatibleCube;

    private GameObject neonRedThis;
    private GameObject neonGreenThis;

    private GameObject neonRedOther;
    private GameObject neonGreenOther;

    private GameObject parentOther;

    private bool isPlaced;

    private GameObject scoreManager;
    // Start is called before the first frame update
    void Start()
    {

        // Get the neon lights of the mark where the cube is
        GameObject parent = this.transform.parent.gameObject;
        //Debug.Log(String.Format("{1}: {0}/GreenNeon", parentName, this.gameObject.name));

        neonGreenThis = parent.transform.Find("GreenNeon").gameObject;
        neonRedThis = parent.transform.Find("RedNeon").gameObject;

        isPlaced = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Get the neon lights of the collided mark
        parentOther = other.gameObject.transform.parent.gameObject;
        //Debug.Log(String.Format("{0}/GreenNeon", parentOther));

        neonGreenOther = parentOther.transform.Find("GreenNeon").gameObject;
        neonRedOther = parentOther.transform.Find("RedNeon").gameObject;

        if (compatibleCube != null)
        {
            Debug.Log("awachinao antes del if");
            if (other.gameObject.Equals(compatibleCube))
            {
                Debug.Log("awachinao despues del if");
                neonRedThis.SetActive(false);
                neonRedOther.SetActive(false);
                neonGreenThis.SetActive(true);
                neonGreenOther.SetActive(true);

                isPlaced = true;
                scoreManager.GetComponent<ScoreManager>().addScore();
            }
            else
            {
                neonGreenThis.SetActive(false);
                neonRedThis.SetActive(true);
                Debug.Log(String.Format("{0}/{1} {2}", other.gameObject.transform.parent.name, other.gameObject.name, other.gameObject.GetComponent<CubeCollision>().getIsPlaced()));
                if (!other.gameObject.GetComponent<CubeCollision>().getIsPlaced())
                {
                    neonGreenOther.SetActive(false);
                    neonRedOther.SetActive(true);
                }
                    
            }
        } else
        {
            neonRedThis.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (compatibleCube != null)
        {
            if (other.gameObject.Equals(compatibleCube))
            {
                neonGreenThis.SetActive(false);
                neonRedThis.SetActive(false);
                if (this.isPlaced && other.gameObject.GetComponent<CubeCollision>().getIsPlaced())
                {
                    neonGreenOther.SetActive(false);
                    neonRedOther.SetActive(false);
                    isPlaced = false;
                    other.gameObject.GetComponent<CubeCollision>().isPlaced = false;

                    scoreManager.GetComponent<ScoreManager>().reduceScore();
                }
            }
        } else
        {
            neonRedThis.SetActive(false);
        }
    }

    public bool getIsPlaced()
    {
        return isPlaced;
    }
}
