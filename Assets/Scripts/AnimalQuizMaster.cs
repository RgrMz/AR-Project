using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimalQuizMaster : MonoBehaviour
{
    [SerializeField]
    private string[] animalNames;

    [SerializeField]
    private string currentAnimal;

    [SerializeField]
    private ParticleSystem correctParticles;

    [SerializeField]
    private ParticleSystem wrongParticles;

    private static int current;

    [SerializeField]
    private TextMeshProUGUI animalTextName;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        currentAnimal = animalNames[current];
        animalTextName.text = currentAnimal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimalSelected(string animalName)
    {
        if(animalName.Equals(animalNames[current]))
        {
            correctParticles.Emit(50);
            current++;
            currentAnimal = animalNames[current % animalNames.Length];
            animalTextName.text = currentAnimal;
        } else
        {
            wrongParticles.Play();
        }
        
    }
}
