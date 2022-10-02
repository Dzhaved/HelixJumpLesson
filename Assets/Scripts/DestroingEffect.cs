using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroingEffect : MonoBehaviour
{
    public ParticleSystem PlayerDestroingEffect;    
    public Player player;

    

    private void Update()
    {
        if (player.isDestoing)
        {
            PlayerDestroingEffect.Play();
            player.isDestoing = false;
            Invoke("EffectStop", 1f);
            
        }
    }
    private void EffectStop()
    {
        PlayerDestroingEffect.Stop();        
    }
}
