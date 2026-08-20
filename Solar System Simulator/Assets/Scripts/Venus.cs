using UnityEngine;

public class Venus : CelestialBody
{
    [SerializeField]
    private Earth earth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().mass = mass;

        mass = 400f *  (82 / earth.mass);

        transform.localScale = new Vector3(mass, mass, mass);
        SayMyName();
    }
}
