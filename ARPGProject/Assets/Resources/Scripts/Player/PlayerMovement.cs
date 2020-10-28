using System;
using UnityEngine;
using UnityEngine.AI;

namespace Resources.Scripts
{
    internal enum PlayerState { Idle, Moving };
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        private PlayerController master;
        
        [HideInInspector] public string currentState; //To be able to refer to _state in custom inspector.
        [HideInInspector] public NavMeshAgent agent;  //To be able to manipulate agent in custom inspector.
        
        private PlayerState _state;

        private void Awake()
        {
            master = GetComponent<PlayerController>();
        }

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _state = PlayerState.Idle;
        }

        private void Update()
        {
            UpdatePlayerState();
        }
        
        private void UpdatePlayerState()
        {
            _state = agent.velocity != Vector3.zero ? PlayerState.Moving : PlayerState.Idle;
            currentState = _state.ToString();
        }
    }
}