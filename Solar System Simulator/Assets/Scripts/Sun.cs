using UnityEngine;

public class Sun : CelestialBody
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().mass = mass;
        transform.localScale = new Vector3(mass, mass, mass);
        SayMyName();
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }
}
