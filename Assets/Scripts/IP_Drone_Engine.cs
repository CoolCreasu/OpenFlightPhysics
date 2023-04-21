using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(BoxCollider))]
    public class IP_Drone_Engine : MonoBehaviour, IEngine
    {
        #region Variables
        [Header("Engine Properties")]
        [SerializeField] private float _maxPower = 4.0f;

        [Header("Propeller Properties")]
        [SerializeField] private Transform _propeller = default;
        [SerializeField] private float _propellerRotationSpeed = 0.0f;
        #endregion

        #region Interface Methods
        public void InitEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rigidbody, IP_Drone_Inputs input)
        {
            //Debug.Log($"Running Engine: {gameObject.name}");
            Vector3 upVec = transform.up;
            upVec.x = 0.0f;
            upVec.z = 0.0f;
            float diff = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * diff;

            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rigidbody.mass * Physics.gravity.magnitude + finalDiff) + (input.Throttle * _maxPower)) / 4f;

            rigidbody.AddForce(engineForce, ForceMode.Force);

            HandlePropellers();
        }

        private void HandlePropellers()
        {
            if (_propeller == null)
            {
                return;
            }

            _propeller.Rotate(Vector3.up, _propellerRotationSpeed);
        }
        #endregion
    }
}