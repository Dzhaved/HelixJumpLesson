using Assets.Scripts;
using UnityEngine;



public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigibody;
    public Platform CurrentPlatform;
    public Game Game;
    public Material PlayerMaterial;
    [Min(-0.15f)]
    public float _Disappearance_Degree = -0.15f;
    public GameObject BounceEffect;

    internal int _currentScore;
    internal bool _isPlay;
    internal bool isBouncing = false;
    internal bool isDestoing = false;
    private AudioSource _ballBounce;
    
    private float _speed = 0.02f;




    private void Awake()
    {
        _isPlay=true;
        PlayerMaterial.SetFloat("_Disappearance_Degree", 0f);
        _ballBounce = GetComponent<AudioSource>();
    }

    public void Bounce()
    {        
        _ballBounce.Play();
         isBouncing=true;        
        Rigibody.velocity=new Vector3(0,BounceSpeed,0);
    }

    public void Die()
    {
        _ballBounce.Play();      
        isDestoing=true;
        Game.OnPlayerDied();
        Rigibody.velocity = Vector3.zero;
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigibody.velocity = Vector3.zero;
    }
    private const string BestScoreKey = "BestScore";

    public int BestScore
    {
        get => PlayerPrefs.GetInt(BestScoreKey, 0);
        set
        {
            PlayerPrefs.SetInt(BestScoreKey, value);
            PlayerPrefs.Save();
        }

    }
    private const string LevelHighScoreKey = "LevelHighScore";
    public int LevelHighScore 
    { 
        get => PlayerPrefs.GetInt(LevelHighScoreKey, 0);
        internal set            
        {
            PlayerPrefs.SetInt(LevelHighScoreKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string PreviousLevelScoreKey = "PreviousLevelScore";
    public int PreviousLevelScore
    {
        get => PlayerPrefs.GetInt(PreviousLevelScoreKey, 0);
        internal set
        {
            PlayerPrefs.SetInt(PreviousLevelScoreKey, value);
            PlayerPrefs.Save();
        }
    }

    private void FixedUpdate()
    {
        if (_isPlay) return;
        if(_Disappearance_Degree < 1.3f)
        Disappearance();
    }

    private void Disappearance()
    {
        _Disappearance_Degree += _speed;
        PlayerMaterial.SetFloat("_Disappearance_Degree", _Disappearance_Degree);
    }
}
