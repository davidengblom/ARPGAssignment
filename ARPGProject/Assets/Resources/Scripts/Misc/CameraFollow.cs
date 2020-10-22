using System;
using UnityEngine;

namespace Player.Scripts.Misc
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;

        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}
