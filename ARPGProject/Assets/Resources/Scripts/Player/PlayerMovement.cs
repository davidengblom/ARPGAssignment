using System;
using UnityEngine;
using UnityEngine.AI;

namespace Resources.Scripts
{
    internal enum PlayerState { Idle, Moving };
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerController _controller;
        
        [HideInInspector] public string currentState; //To be able to refer to _state in custom inspector.
        [HideInInspector] public NavMeshAgent agent;  //To be able to manipulate agent in custom inspector.
        
        private PlayerState _state;
        private int _ground;

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();
        }

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _state = PlayerState.Idle;
            _ground = LayerMask.GetMask("Ground");
        }

        private void Update()
        {
            UpdatePlayerState();
            
            if (Input.GetMouseButton(0))
                SetDestination();
        }

        private void SetDestination()
        {
            var ray = _controller.mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, _controller.mainCam.farClipPlane, _ground))
                agent.destination = hit.point;
        }

        private void UpdatePlayerState()
        {
            _state = agent.velocity != Vector3.zero ? PlayerState.Moving : PlayerState.Idle;
            currentState = _state.ToString();
        }
    }
}