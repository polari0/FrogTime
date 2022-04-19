using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrogTime
{
    internal class CharacterStats : CharacterVariables
    {
        [SerializeField]
        GameObject death_Message;
        [SerializeField]
        CharacterMovement characterMovement_script;
        [SerializeField]
        CharacterAttack characterAttack_Script;
        [SerializeField]
        Image healtBar;
        [SerializeField]
        Slider healtBarSlider;

        private float fillValue;
        //private void Awake()
        //{
        //    characterMaxHealt = 20;
        //    characterHealt = 20;
        //    characterDamage = 2;
        //}


        private void Update()
        {
            fillValue = characterHealt / characterMaxHealt;
            healtBarSlider.value = fillValue;

            if (characterHealt <= 0)
            {
                death_Message.SetActive(true);
                characterAttack_Script.enabled = false;
                characterMovement_script.enabled = false;
            }
        }


        internal void SetBarSize(float sizeNormalized)
        {

        }
    } 
}
