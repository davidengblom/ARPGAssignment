using UnityEngine;
using UnityEngine.AI;

namespace Player.Movement
{
    internal enum PlayerState { Idle, Moving };
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector] public string currentState;
        [HideInInspector] public NavMeshAgent agent;
        
        private PlayerState _state;
        private LayerMask _ground;
        private Camera _mainCam;
        
        private void Start()
        {
            _mainCam = Camera.main;
            _state = PlayerState.Idle;
            agent = GetComponent<NavMeshAgent>();
            _ground = LayerMask.NameToLayer("Ground");
        }

        private void Update()
        {
            UpdatePlayerState();
            
            if (Input.GetMouseButton(0))
                CastRay();
        }

        private void CastRay()
        {
            var ray = Physics.Raycast(_mainCam.ScreenPointToRay(Input.mousePosition), out var hit, 99999f);
            if (!(hit.transform is null) && ray && hit.transform.gameObject.layer == _ground)
                agent.destination = hit.point;
        }

        private void UpdatePlayerState()
        {
            _state = agent.velocity != Vector3.zero ? PlayerState.Moving : PlayerState.Idle;
            currentState = _state.ToString();
        }
    }
}
