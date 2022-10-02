using Unity.VisualScripting;

using UnityEngine;


namespace Assets.Scripts
{
    public class Platform : MonoBehaviour
    {
        public GameObject platform;
        public Sector[] sectors;
        public BoxCollider PlatformCollider;
                
        
        private AudioSource _platformBreak;
        private Rigidbody _sectorRigibody;

        private void Awake()
        {
            _platformBreak = GetComponent<AudioSource>();                       
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                player.CurrentPlatform = this;
            }
            
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other == null) return;
            if (other.TryGetComponent(out Player player))
            {                
                player._currentScore +=3*player.Game.LevelIndex;
            }

            foreach (Sector sector in sectors)
            {
                _sectorRigibody = sector.AddComponent<Rigidbody>();
                //_sectorRigibody.isKinematic = true;
                
                _sectorRigibody.mass = 1f;
                sector.BriksBlow.Play();
                sector._isDestroing = true;

            }
            _platformBreak.Play();
            PlatformCollider.enabled = false;
            Invoke("PlatformDestroing",0.2f);
        }


        private void PlatformDestroing()
        {            
            
            platform.SetActive(false);
            _platformBreak.Stop();
        }
    }
}