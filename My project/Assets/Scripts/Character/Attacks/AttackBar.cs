using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    namespace Character
    {
        public class AttackBar : MonoBehaviour
        {

            [SerializeField]
            private Transform attackBar;


            internal float attackDurationleft = 0f;
            internal float attackDurationMax = 1f;


            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }

            internal void SetBarSize(float sizeNormalized)
            {
                attackBar.localScale = new Vector3(1f, sizeNormalized, 0f);
            }
        } 
    }
}
//This script just fills and empties the attack Bar at constant rate. 