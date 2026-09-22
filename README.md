# <h1 align="center">Solar System 3D Simulator Documentation</h1>
<h2 align="center" dir="auto"><strong><code>Unity Engine Simulation Project</code></strong></h2>


<div class="Header Image">
  <a align="center" draggable="false" href="https://www.youtube.com/watch?v=uzDSGSeMU78&t=4s"><img width="800" height="450" alt="Orbit Velocity Mass Fixed Mars and Jupiter Added" src="https://github.com/user-attachments/assets/34290e4b-f34b-4bca-ad1f-0c73c457e532" /></a>
</div>

<h2 align="center" dir="auto"> Overview </h2>
<h2 align="center" dir="auto"><strong>Genre: <code>Simulation</code></strong></h2>
<h3><b>Introduction</b></h3>
<p dir="auto">This Solar System Simulator project simulates real-world gravitational physics using Unity's physics. It demonstrates Newton and Kepler’s laws in a 3D simulation. The project was developed in Unity and uses NASA's APOD API (Astronomy Picture of the Day) to display photos taken in real-time each day.
</p>
<br>
<h3><b>Design</b></h3>
<p dir="auto">The project design is a replica of our solar system with all planets in orbit order. I also designed custom shaders and gathered textures from solarsystemscope.com to make the planets look somewhat similar to their real counterparts. I also used an outside space skybox to help create a more space aesthetic for the scene of the project. Splines were placed around the project to help assist viewers in getting a better look at each individual planet and our sun, so it would be easier to view and read any topics and information on the planets.</p>
<img width="800" height="450" alt="Solar System Model" src="https://github.com/user-attachments/assets/92e1c49a-803f-4d1b-97cb-6f7d89b0b1c7" />



<br>
<h3><b>Development</b></h3>
<p dir="auto">The solar system is designed to calculate all the GameObjects in the scene that derive from the CelestialBody.cs class into an array list. This was necessary for the calculations because the script runs the array list within a nested foreach loop and determines whichever gameObjects has the higher mass (M1) between two bodies; based on that, the body with the lower mass (M2) will move towards the body with the higher mass (M1).
<br>
  <pre><code>
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


                    float UniversalGravitation = (G * (m1 * m2) / (r * r));

                    body1.GetComponent<Rigidbody>().AddForce((body2.transform.position - body1.transform.position).normalized * UniversalGravitation);

                }

            }
        }
    }
    
  </code></pre>
 Kepler’s orbital velocity formula is implemented using nested foreach loops that compare each celestial body against every other body. The function ensures body1 (M1) and body2 (M2) are not the same object before calculating orbital velocity. The more massive body uses M2 as the reference point, continuously facing it while applying the calculated orbital velocity along its transform.right direction. This tangential force causes the object to move in an arc or circular orbit around the other body, with M2’s mass contributing to the orbital velocity calculation.</p>
<br>
<h3><b>Technical Art</b></h3>
<p dir="auto">I designed a planetary shader that displays the planet's base image and height map to give the sphere body depth. I also create an atmosphere shader using the fresnel node to help assist in creating the effect of an atmosphere. This was helpful in displaying a close to similar replica of the planet models.
 <br>
  
<img width="800" height="450" alt="Earth_and_Sun_Motion" src="https://github.com/user-attachments/assets/ea4ecf2b-9835-4ff5-b112-ca2787c0f72c" />





