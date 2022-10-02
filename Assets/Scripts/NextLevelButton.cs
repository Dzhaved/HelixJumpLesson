using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    public Controls Controls;
    public Player player;
    public Game game;
    public Button Button;
    public Text LevelInfoText;
    public Text PlayerStatusText;
    public void NewLevelTotalScore()
    {
        player.LevelHighScore = 0;
    }
    public void ReloadeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        Controls.enabled = true;
        player.transform.position =player.transform.position + new Vector3(0,5,0);
        game.CurrentState=0;
        Button.interactable = false;
        LevelInfoText.text=null;
        PlayerStatusText.text=null;       
        player._Disappearance_Degree = 0f;
        player._isPlay = true;
        player.PlayerMaterial.SetFloat("_Disappearance_Degree", player._Disappearance_Degree); ;
    }
    
}
