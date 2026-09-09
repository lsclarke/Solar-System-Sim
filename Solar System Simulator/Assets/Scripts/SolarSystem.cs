using UnityEngine;

public class SolarSystem : MonoBehaviour
{

    public long G = 0;
    public CelestialBody[] bodies;

    //Before the first frame/execution the script instance will set find all instances that derive from the CelestialBody.cs and apply the Orbital Velocity Formula on each object in the list.
    private void Start()
    {
        bodies = FindObjectsOfType<CelestialBody>();
        OrbitalVelocity();
    }

    //At every fixed frame the gravity will be called
    private void FixedUpdate()
    {
        Gravity();
    }

    //Determines what mass is greater and will return true or false.
    public bool isGreater(CelestialBody body1, CelestialBody body2)
    {
        return body1.mass > body2.mass;
    }


    /// <summary>
    /// Applies Newton's Law of Universal Gravitation by using a nested foreach loop that runs through all elements in the list and compares it to another element within the secon list.
    /// The function then checks if body1 (M1) is equal to body2 (M2) which is not true. Since it is not true the funtion will then go to the next set of code and create a UniversalGravitation variable.
    /// This variable will be the force applied to body1 (M1) due to it having the higher mass, and the force will be the distacne between M1 and M2 multiplied by the UniversalGravitation variable causing 
    /// body2 (M2) to move closer towards body1 (M1)
    /// </summary>

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

                    //Distance
                    float r = Vector3.Distance(body1.transform.position, body2.transform.position);

                    //Universal Gravitation Formula
                    float UniversalGravitation = (G * (m1 * m2) / (r * r));

                    body1.GetComponent<Rigidbody>().AddForce((body2.transform.position - body1.transform.position).normalized * UniversalGravitation);

                }

            }
        }
    }

    /// <summary>
    /// Applies Keplers law of Orbital Velocity Formula by using a nested foreach loop that runs through all elements in the list and compares it to another element within the secon list.
    /// The function then checks if body1 (M1) is equal to body2 (M2) which is not true. Since it is not true the funtion will then go to the next set of code and create a orbitalVelocity variable.
    /// The object with the greater mass body1 (M1) will look at body (M2). This will keep the object's forward direction to constantly face the object. 
    /// Body1 (M1) will add the orbitalVelocity multiplied by the transform.right direction. This will cause it to move in a more arc/circular motion.
    /// </summary>
    /// 
    private void OrbitalVelocity()
    {
        foreach (CelestialBody body1 in bodies)
        {
            foreach (CelestialBody body2 in bodies)
            {
                if (!body1.Equals(body2))
                {
                    float m2 = body2.mass;

                    //Distance
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
