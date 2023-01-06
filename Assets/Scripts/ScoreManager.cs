using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int _score;
    public int Score { get; set; }
    private static int TOTAL_PIECES = 9;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        scoreText.text = string.Format("{0}/9 PIECES PLACED", Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore()
    {
        Score++;
    }

    public void reduceScore()
    {
        if (Score > 0)
            Score--;
    }

}
