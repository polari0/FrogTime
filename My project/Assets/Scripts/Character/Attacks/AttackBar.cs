using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrogTime
{
    namespace Character
    {
        public class AttackBar : MonoBehaviour
        {

            [SerializeField]
            private Image attackBar;

            private Slider slider;

            internal float attackDurationleft = 0f;
            internal float attackDurationMax = 1f;

            private float fillValue;

            private void Awake()
            {
                slider = GetComponent<Slider>();
            }
            private void Update()
            {
                //fillValue = attackDurationleft;

                slider.value = attackDurationMax;
            }

            internal void SetBarSize(float sizeNormalized)
            {

            }
        } 
    }
}
//This script just fills and empties the attack Bar at constant rate. Rate is Defined in attack teleprot Script. 