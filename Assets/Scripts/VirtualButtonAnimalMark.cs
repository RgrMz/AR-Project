using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonAnimalMark : MonoBehaviour
{
    [SerializeField]
    private VirtualButtonBehaviour vb;

    [SerializeField]
    private GameObject masterTarget;

    [SerializeField]
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        vb.RegisterOnButtonPressed(OnButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        // Get the name of the animal in this mark
        
        
        Debug.Log(parent.name.Remove(0,2) + " was pressed");
        masterTarget.GetComponent<AnimalQuizMaster>().AnimalSelected(parent.name.Remove(0, 2));
    }
}
