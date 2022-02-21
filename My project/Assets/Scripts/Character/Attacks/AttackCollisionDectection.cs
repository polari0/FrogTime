using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    namespace Character
    {
        internal class AttackCollisionDectection : MonoBehaviour
        {
            internal bool attackContinue = true;

            private void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.gameObject.tag == "map")
                {
                    attackContinue = false;
                }
            } 

        }  
    }
}
