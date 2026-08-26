using UnityEngine;

namespace Nova.SolarSystem
{
    public class Uranus : CelestialBody
    {
        [SerializeField]
        private Earth earth;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GetComponent<Rigidbody>().mass = mass;

            //transform.localScale = new Vector3(mass, mass, mass);
            SayMyName();
        }
        private void FixedUpdate()
        {
            GetComponent<Rigidbody>().mass = mass;
        }
    }
}
