using UnityEngine;

namespace Resources.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        internal PlayerMovement Movement;
        internal PlayerCombat Combat;

        public int groundLayer;
        public int enemyLayer;

        public Camera mainCam;

        private void Awake()
        {
            mainCam = Camera.main;
            groundLayer = LayerMask.GetMask("Ground");
            enemyLayer = LayerMask.GetMask("Enemy");
            
            Movement = GetComponent<PlayerMovement>();
            Combat = GetComponent<PlayerCombat>();
        }
    }
}
