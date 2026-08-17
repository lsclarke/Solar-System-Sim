using UnityEngine;

public class Mercury : CelestialBody
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Earth earth = GetComponent<Earth>();
        GetComponent<Rigidbody>().mass = mass;

        mass = 82 % earth.mass;

        transform.localScale = new Vector3(mass, mass, mass);
        SayMyName();
    }

}
