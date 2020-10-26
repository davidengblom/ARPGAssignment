using UnityEngine;
using UnityEngine.AI;

namespace Resources.Scripts
{
    internal enum PlayerState { Idle, Moving };
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector] public string currentState; //To be able to refer to _state in custom inspector.
        [HideInInspector] public NavMeshAgent agent;  //To be able to manipulate agent in custom inspector.
        
        private PlayerState _state;
        private LayerMask _ground;
        private Camera _mainCam;
        
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _mainCam = Camera.main;
            _state = PlayerState.Idle;
            _ground = LayerMask.NameToLayer("Ground");
        }

        private void Update()
        {
            UpdatePlayerState();
            
            if (Input.GetMouseButton(0))
                SetDestination();
        }

        private void SetDestination()
        {
            var ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            var raycast = Physics.Raycast(ray, out var hit, _mainCam.farClipPlane, ~_ground);
            if (raycast)
                agent.destination = hit.point;
        }

        private void UpdatePlayerState()
        {
            _state = agent.velocity != Vector3.zero ? PlayerState.Moving : PlayerState.Idle;
            currentState = _state.ToString();
        }
    }
}