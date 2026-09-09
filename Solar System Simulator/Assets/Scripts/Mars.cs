using UnityEngine;

namespace Nova.SolarSystem
{
    public class Mars : CelestialBody
    {
        [SerializeField]
        private Earth earth;
        // Before the first frame/execution the script will set the rigidbody mass to equal the public var mass value of planet in the inspector
        void Start()
        {
            GetComponent<Rigidbody>().mass = mass;
        }

        // Every fixed frame the script will set the rigidbody mass to equal the public var mass value of planet in the inspector (Allowing for updates in real-time)
        private void FixedUpdate()
        {
            GetComponent<Rigidbody>().mass = mass;
        }
    }
}
