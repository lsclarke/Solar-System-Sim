using UnityEngine;

public class SolarSystem : MonoBehaviour
{

    public long G = 0;
    public CelestialBody[] bodies;

    private void Start()
    {
        bodies = FindObjectsOfType<CelestialBody>();
        OrbitalVelocity();
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    public bool isGreater(CelestialBody body1, CelestialBody body2)
    {
        return body1.mass > body2.mass;
    }

    private void Gravity()
    {
        foreach (CelestialBody body1 in bodies)
        {
            foreach (CelestialBody body2 in bodies)
            {
                if (!body1.Equals(body2))
                {
                    float m1 = body1.mass;
                    float m2 = body2.mass;
                    float r = Vector3.Distance(body1.transform.position, body2.transform.position);

                    //Universal Gravitation Formula
                    float UniversalGravitation = (G * (m1 * m2) / (r * r));

                    body1.GetComponent<Rigidbody>().AddForce((body2.transform.position - body1.transform.position).normalized * UniversalGravitation);

                }

            }
        }
    }

    private void OrbitalVelocity()
    {
        foreach (CelestialBody body1 in bodies)
        {
            foreach (CelestialBody body2 in bodies)
            {
                if (!body1.Equals(body2))
                {
                    float m2 = body2.mass;
                    float r = Vector3.Distance(body1.transform.position, body2.transform.position);

                    body1.transform.LookAt(body2.transform);

                    //Orbital Velocity Formula
                    float orbitalVelocity = Mathf.Sqrt((G * m2) / r);

                    body1.GetComponent<Rigidbody>().linearVelocity += body1.transform.right * orbitalVelocity;
                }

            }
        }
    }
}
