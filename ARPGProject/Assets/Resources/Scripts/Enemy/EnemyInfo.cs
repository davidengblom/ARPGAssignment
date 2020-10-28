using System;
using System.ComponentModel;
using UnityEngine;

namespace Resources.Scripts.Enemy
{
    public class EnemyInfo : MonoBehaviour
    {
        public PlayerController player;
        
        public int maxHealth = 100;
        public int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            switch (currentHealth - damage <= 0)
            {
                case true:
                    player.pCombat.target = null; //Left of last session here, fix this shit bro
                    player.pCombat.combatState = CombatState.Idle;
                    Destroy(gameObject);
                    break;
                case false:
                    currentHealth -= damage;
                    break;
            }
        }
    }
}
