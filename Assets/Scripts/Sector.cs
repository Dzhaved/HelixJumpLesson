using Unity.VisualScripting;

using UnityEngine;
using Random = System.Random;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;    
    public MeshCollider SectorCollider;
    public ParticleSystem BriksBlow;    
    public Material BriksMatirial;

    private int _colorIndex;
    private Player _player;

    
    internal bool _isDestroing=false;

    private void Awake()
    {        
        Random rnd = new Random();
        _colorIndex = rnd.Next(0, 100) % 5;
        float r;
        float g;
        float b;
        switch (_colorIndex)
        {
            case 0:
                 r = (float)(64f / 255f);
                 g = (float)(60f / 255f);
                 b = (float)(134f / 255f);
                GoodMaterial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                BriksMatirial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                break;
            case 1:
                r = (float)(0f / 255f);
                g = (float)(80f / 255f);
                b = (float)(22f / 255f);
                GoodMaterial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                BriksMatirial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                break;
            case 2:
                r = (float)(141f / 255f);
                g = (float)(142f / 255f);
                b = (float)(0f / 255f);
                GoodMaterial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                BriksMatirial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                break;
            case 3:
                r = (float)(99f / 255f);
                g = (float)(36f / 255f);
                b = (float)(1f / 255f);
                GoodMaterial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                BriksMatirial.SetColor("_Briks_Color", new Vector4(r, g, b, 1));
                break;
        }
        

        UpdateMaterial();
    }

    

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player))return;
        _player = player;
        Vector3 normal = -collision.GetContact(0).normal.normalized;                
        float dot = Vector3.Dot(normal, Vector3.up);
        if (_isDestroing) return;
        if (dot < 0.37) return;
        if (IsGood)
        {
            _player._isPlay = true;            
            _player.Bounce();           
        }
        else
        {
            _player._isPlay = false;
            _player.Die();
        }
        
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
