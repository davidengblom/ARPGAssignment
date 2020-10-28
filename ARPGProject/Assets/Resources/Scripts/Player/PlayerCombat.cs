using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Resources.Scripts.Enemy;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Resources.Scripts
{
    public enum CombatState { Attacking, Idle }
    [RequireComponent(typeof(PlayerController))]
    public class PlayerCombat : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        private PlayerController master;
        public CombatState combatState;
        
        [Header("Player Info")]
        public int maxHealth = 100;
        public int damage = 10;
        public float attackSpeed = 0.2f;
        public float attackRange = 5f;

        private bool _attacking;

        [Header("Debugging")]
        public Transform target;

        public Vector3 enemyToPlayer;
        public Vector3 steerTarget;

        private void Awake()
        {
            master = GetComponent<PlayerController>();
            combatState = CombatState.Idle;
        }
        

        private void Update()
        {
            
            switch (combatState)
            {
                case CombatState.Attacking:
                    target = master.pInput.hit.transform;
                    if (Vector3.Distance(target.position, transform.position) > attackRange)
                    {
                        enemyToPlayer = transform.position - target.position;
                        steerTarget = target.position + enemyToPlayer.normalized * attackRange;
                        master.pMovement.agent.destination = steerTarget;
                    }
                    else
                    {
                        if(!_attacking)
                            StartCoroutine(Attack());

                    }
                    break;
                
                case CombatState.Idle:
                    StopCoroutine(Attack());
                    _attacking = false;
                    target = null;
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerator Attack()
        {
            var info = target.GetComponent<EnemyInfo>();
            _attacking = true;
            while (_attacking)
            {
                info.TakeDamage(damage);
                Debug.Log("Did damage!");
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
}
