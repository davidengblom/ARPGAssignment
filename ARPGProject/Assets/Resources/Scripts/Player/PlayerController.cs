using UnityEngine;

namespace Resources.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        internal PlayerMovement pMovement;
        // ReSharper disable once InconsistentNaming
        internal PlayerCombat pCombat;
        // ReSharper disable once InconsistentNaming
        internal PlayerInput pInput;

        public int groundLayer;
        public int enemyLayer;

        public Camera mainCam;

        private void Awake()
        {
            mainCam = Camera.main;
            groundLayer = LayerMask.NameToLayer("Ground");
            enemyLayer = LayerMask.NameToLayer("Enemy");
            
            pMovement = GetComponent<PlayerMovement>();
            pCombat = GetComponent<PlayerCombat>();
            pInput = GetComponent<PlayerInput>();
        }
    }
}
