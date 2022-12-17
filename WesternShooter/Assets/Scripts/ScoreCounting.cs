using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounting : MonoBehaviour{
    private static string currentSceneName;
    private static int scoreValue = 0;
    [SerializeField] private TMPro.TextMeshProUGUI scoreDisplay;


    public static ScoreCounting Instance{ get; private set; }

    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }

        scoreDisplay = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void Start(){
        scoreValue = 0;
    }
    
    void Update(){
        scoreDisplay.SetText(scoreValue.ToString());
    }

    public void AddScore(int score){
        scoreValue += score;
    }


   
}