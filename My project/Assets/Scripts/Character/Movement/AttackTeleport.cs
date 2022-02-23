using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

//SUGGEST NAME CHANGES PLEASE

namespace FrogTime
{
    namespace Character
    {
        public class AttackTeleport : NetworkBehaviour
        {

            [SerializeField]
            private CharacterMovement characterMovement_Script;
            [SerializeField]
            private DotweenTest dotweentest_Script;
            [SerializeField]
            private AttackBar attackBar_script;
            [SerializeField]
            private GameObject line;

            private bool canAttack = true;

            //These 2 controll how fast and ofter you attack 
            private float attackDuration = 0.002f;
            private float attackRegeneration = 0.002f;

            private void Update()
            {
                StartCoroutine(Attack());
            }
            //Checks if you can attack, and runs the logic on how often you can attack Im pretty sure there are ways to optimize this but that is for later me to puzzel about.
            IEnumerator Attack()
            {
                if (Input.GetMouseButton(0) && canAttack == true)
                {
                    characterMovement_Script.enabled = false;
                    attackBar_script.attackDurationMax -= attackDuration;
                }
                if (Input.GetMouseButtonUp(0) || (attackBar_script.attackDurationMax <= 0))
                {
                    canAttack = false;
                    dotweentest_Script.AttackMove();
                    StartCoroutine(RegenerateAttackBar());
                    yield return new WaitForSeconds(0.4f);
                    characterMovement_Script.enabled = true;
                    canAttack = true;
                }
            }

            IEnumerator RegenerateAttackBar()
            {
                if(Input.GetMouseButtonUp(0) && attackBar_script.attackDurationMax <= 1)
                {
                    while (attackBar_script.attackDurationMax <= 1)
                    {
                        attackBar_script.attackDurationMax += attackRegeneration;
                        yield return new WaitForSeconds(0.01f);
                        if(attackBar_script.attackDurationMax >= 1)
                        {
                            StopCoroutine(RegenerateAttackBar());
                        }
                    }
                }
            }
        }  
    }
}
