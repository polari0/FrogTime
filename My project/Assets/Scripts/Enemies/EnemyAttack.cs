using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

namespace FrogTime
{
    internal class EnemyAttack : MonoBehaviour
    {
        [SerializeField]
        private CharacterVariables variables_Script;
        [SerializeField]
        private CharacterAttack attack_Script;

        [SerializeField]
        AIMPerceiver AIM_Perciever;

        public int enemyDamage = 1;
        public int enemyHealt = 10;

        private void Awake()
        {
            
        }

        private void Start()
        {
            variables_Script = FindObjectOfType<CharacterVariables>();
            attack_Script = FindObjectOfType<CharacterAttack>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && attack_Script.isAttacking == false)
            {
                variables_Script.characterHealt -= enemyDamage;
                Debug.Log(variables_Script.characterHealt + "this is character healt");
                Debug.Log(attack_Script.isAttacking);
            }
            else if (collision.tag == "Player" && attack_Script.isAttacking == true)
            {
                enemyHealt -= variables_Script.characterDamage;
                Debug.Log(enemyHealt + "this is enemy healt");
            }
        }

        private void Update()
        {
            if (enemyHealt <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    } 
}
