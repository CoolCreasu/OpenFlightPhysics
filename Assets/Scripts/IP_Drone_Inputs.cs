using UnityEngine;
using UnityEngine.InputSystem;

namespace IndiePixel
{
    [RequireComponent(typeof(PlayerInput))]
    public class IP_Drone_Inputs : MonoBehaviour
    {
        #region Variables
        private Vector2 _cyclic = Vector2.zero;
        private float _pedals = 0.0f;
        private float _throttle = 0.0f;

        public Vector2 Cyclic { get => _cyclic; }
        public float Pedals { get => _pedals; }
        public float Throttle { get => _throttle; }
        #endregion

        #region Input Methods
        private void OnCyclic(InputValue value)
        {
            _cyclic = value.Get<Vector2>();
        }

        private void OnPedals(InputValue value)
        {
            _pedals = value.Get<float>();
        }

        private void OnThrottle(InputValue value)
        {
            _throttle = value.Get<float>();
        }
        #endregion
    }
}