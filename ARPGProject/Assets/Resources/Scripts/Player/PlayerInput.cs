using System;
using System.Diagnostics;
using Resources.Scripts.Enemy;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Resources.Scripts
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerInput : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        private PlayerController master;

        // ReSharper disable once InconsistentNaming
        public RaycastHit hit;
        
        private void Awake()
        {
            master = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
                MouseInput();
        }

        private void MouseInput()
        {
            var ray = master.mainCam.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit, master.mainCam.farClipPlane)) return;

            var hitLayer = hit.transform.gameObject.layer;
            switch (hitLayer)
            {
                case 8: //Layer 8 == Ground Layer
                    master.pCombat.combatState = CombatState.Idle;
                    master.pMovement.agent.destination = hit.point;
                    break;
                case 10: //Layer 10 == Enemy Layer
                    master.pCombat.combatState = CombatState.Attacking;
                    break;
                default:
                    return;
            }
        }
    }
}
