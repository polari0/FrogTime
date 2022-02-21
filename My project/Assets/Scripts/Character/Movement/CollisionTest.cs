using UnityEngine;
using System.Collections;


//This script can be Safely ignored For the most part it was test to do some stuff and copy pasted from internet. 
//It remains to be seen if I do something with it
namespace FrogTime
{
    namespace Character
    {
        public class CollisionTest : MonoBehaviour
        {
            void Update()
            {
                Vector3 Point;
                Vector3 Start = new Vector3(0, 100, 0); // This is defined to be some arbitrary point far away from the collider.
                Vector3 Goal = transform.position; // This is the point we want to determine whether or not is inside or outside the collider.
                Vector3 Direction = Goal - Start; // This is the direction from start to goal.
                Direction.Normalize();
                int Itterations = 0; // If we know how many times the raycast has hit faces on its way to the target and back, we can tell through logic whether or not it is inside.
                Point = Start;


                while (Point != Goal) // Try to reach the point starting from the far off point.  This will pass through faces to reach its objective.
                {
                    RaycastHit hit;
                    if (Physics.Linecast(Point, Goal, out hit)) // Progressively move the point forward, stopping everytime we see a new plane in the way.
                    {
                        Itterations++;
                        Point = hit.point + (Direction / 100.0f); // Move the Point to hit.point and push it forward just a touch to move it through the skin of the mesh (if you don't push it, it will read that same point indefinately).
                    }
                    else
                    {
                        Point = Goal; // If there is no obstruction to our goal, then we can reach it in one step.
                    }
                }
                while (Point != Start) // Try to return to where we came from, this will make sure we see all the back faces too.
                {
                    RaycastHit hit;
                    if (Physics.Linecast(Point, Start, out hit))
                    {
                        Itterations++;
                        Point = hit.point + (-Direction / 100.0f);
                    }
                    else
                    {
                        Point = Start;
                    }
                }
                if (Itterations % 2 == 0)
                {
                    print("Point is Outside");
                }
                if (Itterations % 2 == 1)
                {
                    print("Point is Inside");
                }
            }
        }

    }
}
