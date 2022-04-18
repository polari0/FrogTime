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
        private PointCounter pointCounter_script;

        [SerializeField]
        AIMSteeringFilter steering_component;
        [SerializeField]
        AIMSteeringPerceiver perciever_component;

        public int enemyDamage = 1;
        public int enemyHealt = 10;

        private void Awake()
        {
            steering_component = GetComponent<AIMSteeringFilter>();
            perciever_component = FindObjectOfType<AIMSteeringPerceiver>();

        }

        private void Start()
        {
            steering_component.SteeringPerceiver = perciever_component;
            variables_Script = FindObjectOfType<CharacterVariables>();
            attack_Script = FindObjectOfType<CharacterAttack>();
            pointCounter_script = FindObjectOfType<PointCounter>();
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
                pointCounter_script.UpdateScore();
                Destroy(this.gameObject);
            }
        }
    } 
}
