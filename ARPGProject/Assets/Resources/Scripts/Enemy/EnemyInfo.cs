using UnityEngine;

namespace Resources.Scripts.Enemy
{
    public class EnemyInfo : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;

        public BoxCollider meleeRange;

        private void Start()
        {
            meleeRange = GetComponent<BoxCollider>();
        }
    }
}
