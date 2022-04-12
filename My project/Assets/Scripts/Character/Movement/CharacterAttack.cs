using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SUGGEST NAME CHANGES PLEASE

namespace FrogTime
{
        internal class CharacterAttack : MonoBehaviour
        {
            //[SerializeField]
            //private DotweenTest dotweentest_Script;
            [SerializeField]
            private AttackBar attackBar_script;
            [SerializeField]
            private CharacterMovement movement_script;

            internal bool canAttack = true;
            internal bool isAttacking = false;

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
                    isAttacking = true;
                    //characterMovement_Script.enabled = false;
                    attackBar_script.attackDurationMax -= attackDuration;
                    movement_script.moveSpeed = 1f;
                }
                if (Input.GetMouseButtonUp(0) || (attackBar_script.attackDurationMax <= 0))
                {
                    isAttacking = false;
                    canAttack = false;
                    //dotweentest_Script.AttackMove();
                    StartCoroutine(RegenerateAttackBar());
                    movement_script.moveSpeed = 0.1f;
                    canAttack = true;
                    yield return null;
                    //characterMovement_Script.enabled = true;
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
