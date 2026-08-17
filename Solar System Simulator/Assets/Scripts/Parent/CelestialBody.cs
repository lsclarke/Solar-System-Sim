using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    //All body characteristics
    public enum c_BodyType 
    { 
        Star, DwarfStar,  Planet, DwarfPlanet, Asteroid
    }
    public c_BodyType celestialBodyType;

    public float mass;

    [TextArea]
    public string composition;

    public void SayMyName()
    {
        Debug.Log($"{name}: {mass}");
    }
}
