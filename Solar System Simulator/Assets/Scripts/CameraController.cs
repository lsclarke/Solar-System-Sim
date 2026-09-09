using System;
using UnityEngine;

namespace Nova.SolarSystem
{
    public class CameraController : MonoBehaviour
    {
       [SerializeField] private CelestialBody planetObject;

        //Every frame focus on the LookAt target.
        void Update()
        {
            transform.LookAt(planetObject.transform);
        }
    }
}
