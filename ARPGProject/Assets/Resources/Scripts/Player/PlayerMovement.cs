using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

namespace Resources.Scripts
{
    internal enum PlayerState { Idle, Moving };
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector] public string currentState;
        private PlayerState _state = PlayerState.Idle;

        private Camera _mainCam;
        private LayerMask _ground;

        [HideInInspector] public NavMeshAgent agent;

        private void Start()
        {
            _mainCam = Camera.main;
            _state = PlayerState.Idle;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            currentState = _state.ToString(); //To be able to view it in the inspector.
            _state = transform.position != agent.destination ? PlayerState.Moving : PlayerState.Idle;

            if (!Input.GetMouseButton(0)) return;
            if (Physics.Raycast(_mainCam.ScreenPointToRay(Input.mousePosition), out var hit, 99999f))
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    agent.destination = hit.point;
                }
        }
    }
}
