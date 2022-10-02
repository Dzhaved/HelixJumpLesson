using UnityEngine;
using UnityEngine.UI;

public class Progress_Bar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;

    private float _acceptableFinishPlayerDistance = 1f;
    private float _startY;
    private float _minimumReachedY;

    private void Start()
    {
        _startY=Player.transform.position.y;
        _minimumReachedY=Player.transform.position.y;
    }

    private void Update()
    {  
        _minimumReachedY = Mathf.Min(_minimumReachedY, Player.transform.position.y);
        float finishY=FinishPlatform.transform.position.y;
        float t=Mathf.InverseLerp(_startY,finishY+_acceptableFinishPlayerDistance, _minimumReachedY);
        Slider.value = t;
    }
}
