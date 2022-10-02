using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Player player;
    public Text CurrentScore;
   
    void Update()
    {
        CurrentScore.text = player._currentScore.ToString();
    }
}
