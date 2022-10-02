using UnityEngine;

public class Finish : MonoBehaviour
{    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        player.ReachFinish();        
    }
}
