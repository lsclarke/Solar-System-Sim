using UnityEngine;

public class Sun : CelestialBody
{
    // Before the first frame/execution the script will set the rigidbody mass to equal the public var mass value of planet in the inspector
    void Start()
    {
        GetComponent<Rigidbody>().mass = mass;
    }

    // Every fixed frame the script will set the rigidbody velocity to 0 to keep the sun from moving

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }
}
