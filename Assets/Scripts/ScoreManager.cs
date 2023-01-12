using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] representations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 masterRotation = new Vector3(0, 0, this.transform.position.z);
        foreach  (GameObject representation in representations)
        {
            representation.transform.rotation = Quaternion.Euler(masterRotation);
        }
    }


}
