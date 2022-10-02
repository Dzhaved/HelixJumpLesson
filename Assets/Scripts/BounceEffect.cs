using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public ParticleSystem PlayerBounceRock;
    public ParticleSystem PlayerBounceSmoke;
    public Player player;

    private void Update()
    {
        if (player.isBouncing)
        {
            PlayerBounceRock.Play();
            PlayerBounceSmoke.Play();
            player.isBouncing = false;            
            Invoke("EffectStop", 0.2f);
        }        
    }
    private void EffectStop()
    {
        PlayerBounceRock.Stop();
        PlayerBounceSmoke.Stop();
    }
}
