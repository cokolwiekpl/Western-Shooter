using UnityEngine;

public class ScoreCounting : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField] private TMPro.TextMeshProUGUI scoreDisplay;


    public static ScoreCounting Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        scoreDisplay = GetComponent<TMPro.TextMeshProUGUI>();
    }


    void Update()
    {
        scoreDisplay.SetText(scoreValue.ToString());
    }

    public void AddScore(int score)
    {
        scoreValue += score;
    }
}