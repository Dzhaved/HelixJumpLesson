using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Player player;
    public Text BestScoreText;
    
    
    void Awake()
    {
        BestScoreText.text ="Best: " +player.BestScore.ToString();
    }
}
