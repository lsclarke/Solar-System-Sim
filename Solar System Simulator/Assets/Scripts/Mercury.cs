using UnityEngine;

public class Mercury : CelestialBody
{
    [SerializeField]
    private Earth earth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().mass = mass;

        mass = 500f * (5.5f/earth.mass);

        transform.localScale = new Vector3(mass, mass, mass);
        SayMyName();
    }

}
