using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(IP_Drone_Inputs))]
    public class IP_Drone_Controller : IP_Base_Rigidbody
    {
        #region Variables
        [Header("Control Properties")]
        [SerializeField] private float _minMaxPitch = 30.0f;
        [SerializeField] private float _minMaxRoll = 30.0f;
        [SerializeField] private float _yawPower = 4.0f;
        [SerializeField] private float _lerpSpeed = 2.0f;

        private IP_Drone_Inputs _input = default;
        private List<IEngine> _engines = new List<IEngine>();

        private float _finalPitch = 0.0f;
        private float _finalRoll = 0.0f;
        private float _yaw = 0.0f;
        private float _finalYaw = 0.0f;
        #endregion

        #region Main Methods
        private void Start()
        {
            _input = GetComponent<IP_Drone_Inputs>();
            _engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
        }
        #endregion

        #region Custom Methods
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();
        }

        protected virtual void HandleEngines()
        {
            //_rigidbody.AddForce(Vector3.up * (_rigidbody.mass * Physics.gravity.magnitude));
            foreach (IEngine engine in _engines)
            {
                engine.UpdateEngine(_rigidbody, _input);
            }
        }

        protected virtual void HandleControls()
        {
            float pitch = _input.Cyclic.y * _minMaxPitch;
            float roll = -_input.Cyclic.x * _minMaxRoll;
            _yaw = _yaw + _input.Pedals * _yawPower;

            _finalPitch = Mathf.Lerp(_finalPitch, pitch, Time.deltaTime * _lerpSpeed);
            _finalRoll = Mathf.Lerp(_finalRoll, roll, Time.deltaTime * _lerpSpeed);
            _finalYaw = Mathf.Lerp(_finalYaw, _yaw, Time.deltaTime * _lerpSpeed);

            Quaternion rot = Quaternion.Euler(_finalPitch, _finalYaw, _finalRoll);
            _rigidbody.MoveRotation(rot);
        }
        #endregion
    }
}