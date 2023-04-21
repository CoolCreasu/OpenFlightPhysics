using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public interface IEngine
    {
        void InitEngine();
        void UpdateEngine(Rigidbody rigidbody, IP_Drone_Inputs input);
    }
}