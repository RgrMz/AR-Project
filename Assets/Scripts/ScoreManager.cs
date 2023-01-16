using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] representations;

    [SerializeField] 
    private GameObject masterMark;

    private Quaternion transformation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnEnable()
    {
        transformation = masterMark.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        foreach  (GameObject representation in representations)
        {
            representation.transform.rotation = masterMark.transform.rotation * Quaternion.Inverse(transformation);
        }
    }


}
