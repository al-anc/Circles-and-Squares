using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    void Start(){
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue){
        score += coinValue;
        text.text = score.ToString() + "/8";

        if(score >= 8) {
        text.text = "You Win! Press R to Try Again.";
    }

    }
}
