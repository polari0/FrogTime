using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    internal class EnemyAttack : Variables
    {
        [SerializeField]
        private CharacterVariables variables_Script;
        [SerializeField]
        private CharacterAttack attack_Script;

        private void Awake()
        {
            enemyHealt = 10;
            enemyDamage = 1;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player" && attack_Script.canAttack == true)
            {
                variables_Script.characterHealt -= enemyDamage;
                Debug.Log(variables_Script.characterHealt);
            }
            else if (collision.tag == "player" && attack_Script.canAttack == false)
            {
                enemyHealt -= variables_Script.characterDamage;
            }
        }
    } 
}
