using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(Rigidbody))]
    public class IP_Base_Rigidbody : MonoBehaviour
    {
        #region Variables
        [Header("Rigidbody Properties")]
        [SerializeField] private float _weightInLbs = 1.0f;

        const float _lbsToKg = 0.454f;

        protected Rigidbody _rigidbody = default;
        protected float _startDrag = 0.0f;
        protected float _startAngularDrag = 0.0f;
        #endregion

        #region Main Methods
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            if (_rigidbody != null)
            {
                _rigidbody.mass = _weightInLbs * _lbsToKg;
                _startDrag = _rigidbody.drag;
                _startAngularDrag = _rigidbody.angularDrag;
            }
        }

        private void FixedUpdate()
        {
            if (_rigidbody == null)
            {
                return;
            }

            HandlePhysics();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics() { }
        #endregion
    }
}