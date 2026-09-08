using System;
using UnityEngine;

namespace Nova.SolarSystem
{
    public class CameraController : MonoBehaviour
    {
       [SerializeField] private CelestialBody planetObject;

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(planetObject.transform);
        }
    }
}
