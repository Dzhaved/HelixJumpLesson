using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Random = System.Random;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject Info;
    public Player player;
    public Text LevelInfoText;
    public Text PlayerStatusText;
    public Slider Slider;
    [Min(0)]
    public float Volume;
    public ParticleSystem[] LoseEffect;
    public ParticleSystem[] WinEffect;

    private AudioSource _backgroundAudio;


    private void Awake()
    {
        _backgroundAudio= GetComponent<AudioSource>();
    }

    private void Update()
    {
        _backgroundAudio.volume= Volume;
    }

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;          
        if (player.BestScore < player.PreviousLevelScore+LevelHighScore(player._currentScore))
        {
            player.BestScore = player.PreviousLevelScore + LevelHighScore(player._currentScore);
        }
        foreach(ParticleSystem p in LoseEffect)
        {
            p.Play();
        }
        Invoke("LoseScreenActivate", 1.2f);
        
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;        
        player.BestScore = player.PreviousLevelScore + LevelHighScore(player._currentScore);
        player.PreviousLevelScore = player.BestScore;
        foreach (ParticleSystem p in WinEffect)
        {
            p.Play();
        }
        WinScreen.SetActive(true);
        PlayerStatusText.color = Color.white;
        PlayerStatusText.text = "You Win";
        LevelInfoText.color = Color.yellow;
        LevelInfoText.text= "Level " + (LevelIndex-1).ToString() + " passed";

    }

    private void LoseScreenActivate()
    {
        LoseScreen.SetActive(true);
        Info.SetActive(true);
        foreach (ParticleSystem p in LoseEffect)
        {
            p.Stop();
        } 
        PlayerStatusText.color = Color.black;
        PlayerStatusText.text = "You Lose";
        LevelInfoText.color = Color.yellow;
        LevelInfoText.text = ((int)(Slider.value * 100)).ToString() + "% completed";
    }

    private int LevelHighScore(int currentScore)
    {       
        if (player.LevelHighScore < currentScore)
        {
            player.LevelHighScore = currentScore; 
        }
        return player.LevelHighScore;
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 1);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);            
            PlayerPrefs.Save();
        }
        
    }
    private const string LevelIndexKey = "LevelIndex";
}
