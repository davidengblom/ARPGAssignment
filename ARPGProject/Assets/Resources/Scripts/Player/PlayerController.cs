using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public PlayerMovement movement;

        private void Awake()
        {
            movement = GetComponent<PlayerMovement>();
        }
    }
}
