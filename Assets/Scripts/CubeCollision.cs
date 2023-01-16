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

    private ParticleSystem placedCorrectParticle;
    private ParticleSystem.EmissionModule emission;

    private GameObject mark;
    // Start is called before the first frame update
    void Start()
    {

        // Get the neon lights of the mark where the cube is
        mark = this.transform.parent.gameObject;

        neonGreenThis = mark.transform.Find("GreenNeon").gameObject;
        neonRedThis = mark.transform.Find("RedNeon").gameObject;

        // Sistema de emision de particulas
        if (GetComponentInChildren<ParticleSystem>() != null)
        {
            placedCorrectParticle = GetComponentInChildren<ParticleSystem>();
            emission = placedCorrectParticle.emission;
            emission.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Get the neon lights of the collided mark
        parentOther = other.gameObject.transform.parent.gameObject;
        
        // Ver que aristas han colisionado para ponerlos como colocados
        string sideThis = gameObject.name.Remove(0, 4);
        string sideOther = other.gameObject.name.Remove(0, 4);

        neonGreenOther = parentOther.transform.Find("GreenNeon").gameObject;
        neonRedOther = parentOther.transform.Find("RedNeon").gameObject;

        if (compatibleCube != null)
        {
            // El otro es un cubo compatible -> neon verde
            if (other.gameObject.Equals(compatibleCube))
            {
                Debug.Log("OnTriggerEnter llamado");
                neonRedThis.SetActive(false);
                neonRedOther.SetActive(false);
                neonGreenThis.SetActive(true);
                neonGreenOther.SetActive(true);

                // Lado colocado
                mark.GetComponent<MarkController>().setSidePlaced(sideThis);
                other.gameObject.GetComponent<CubeCollision>().getMark().GetComponent<MarkController>().setSidePlaced(sideOther);
                
                emission.enabled = true;
                StartCoroutine(stopParticle());
            }
            else
            {
                if (mark.GetComponent<MarkController>().isAnySidePlaced())
                {
                    neonRedOther.SetActive(true);
                    neonGreenThis.SetActive(true);
                } else
                {
                    neonRedThis.SetActive(true);
                    neonRedOther.SetActive(true);
                }

                if (other.gameObject.GetComponent<CubeCollision>() == null)
                {
                    // Es una arista con ninguna compatible, alli donde se ponga esta mal colocada
                    neonRedOther.SetActive(true);
                    neonRedThis.SetActive(true);
                }
                
                    
            }
        } else
        {
            neonRedThis.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string sideThis = gameObject.name.Remove(0, 4);
        string sideOther = other.gameObject.name.Remove(0, 4);

        // Quitar los lados que antes estaban colocados -> pieza que retiramos
        mark.GetComponent<MarkController>().resetSide(sideThis);
        if (other.gameObject.GetComponent<CubeCollision>() != null)
            other.gameObject.GetComponent<CubeCollision>().getMark().GetComponent<MarkController>().resetSide(sideOther);
        else
            neonRedOther.SetActive(false);

        if (compatibleCube != null)
        {
            if (other.gameObject.Equals(compatibleCube))
            {
                if (mark.GetComponent<MarkController>().isAnySidePlaced())
                {
                    neonRedOther.SetActive(false);
                    neonGreenOther.SetActive(false);
                    neonGreenThis.SetActive(true);
                } else
                {
                    neonRedOther.SetActive(false);
                    neonGreenOther.SetActive(false);
                    neonGreenThis.SetActive(false);
                }
            } else
            {
                if (mark.GetComponent<MarkController>().isAnySidePlaced())
                {
                    neonRedOther.SetActive(false);
                    neonGreenOther.SetActive(false);
                    neonGreenThis.SetActive(true);
                } else
                {
                    neonRedOther.SetActive(false);
                    neonRedThis.SetActive(false);
                }
            }
        }
    }

    IEnumerator stopParticle()
    {
        yield return new WaitForSeconds(3f);

        emission.enabled = false;
    }

    public GameObject getMark()
    {
        return this.mark;
    }
}
