using System.Collections;
using Vuforia;
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

    private ParticleSystem.EmissionModule correctEmission;
    private ParticleSystem.EmissionModule wrongEmission;

    private static int current;

    [SerializeField]
    private TextMeshProUGUI animalTextName;

    [SerializeField]
    private VirtualButtonBehaviour vb;

    [SerializeField]
    private AudioClip[] animalSounds;
    // Start is called before the first frame update
    void Start()
    {
        current = Random.Range(0, animalNames.Length);
        currentAnimal = animalNames[current];
        animalTextName.text = currentAnimal;

        correctEmission = correctParticles.emission;
        wrongEmission = wrongParticles.emission;
        correctEmission.enabled = false;
        wrongEmission.enabled = false;

        vb.RegisterOnButtonPressed(OnButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimalSelected(string animalName)
    {
        if (animalName.Equals(animalNames[current]))
        {
            correctEmission.enabled = true;
            StartCoroutine(stopParticles());
            current = Random.Range(0, animalNames.Length);
            currentAnimal = animalNames[current];
            animalTextName.text = currentAnimal;
        }
        else
        {
            wrongEmission.enabled = true;
            StartCoroutine(stopParticles());
        }

    }

    IEnumerator stopParticles()
    {
        yield return new WaitForSeconds(3f);

        wrongEmission.enabled = false;
        correctEmission.enabled = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (gameObject.GetComponent<AudioSource>().clip != null)
        {
            if (!currentAnimal.Equals(gameObject.GetComponent<AudioSource>().clip.name))
            {
                loadClip(); gameObject.GetComponent<AudioSource>().Play();
            } else
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        } else
        {
            loadClip();
            gameObject.GetComponent<AudioSource>().Play();
        }
        

    }

    private void loadClip()
    {
        // Find the sound of the current animal
        AudioClip sound = null;
        foreach (AudioClip clip in animalSounds)
        {
            if (clip.name.Equals(currentAnimal))
                sound = clip;
        }
        gameObject.GetComponent<AudioSource>().clip = sound;
    }
}
