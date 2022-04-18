using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


        private void Awake()
        {
            characterHealt = 20;
            characterDamage = 2;
        }


        private void Update()
        {
            if (characterHealt < 0)
            {
                death_Message.SetActive(true);
                characterAttack_Script.enabled = false;
                characterMovement_script.enabled = false;
            }
        }
    } 
}
