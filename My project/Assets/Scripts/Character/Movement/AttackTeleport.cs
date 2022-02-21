using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

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

            private float attackDuration = 0.002f;

            private void Update()
            {
                StartCoroutine(Attack());
            }
            IEnumerator Attack()
            {
                if (Input.GetMouseButton(0) && canAttack == true)
                {
                    characterMovement_Script.enabled = false;
                    attackBar_script.attackDurationleft += attackDuration;
                    attackBar_script.SetBarSize(attackBar_script.attackDurationleft);
                    
                }
                if (Input.GetMouseButtonUp(0) || (attackBar_script.attackDurationleft > attackBar_script.attackDurationMax))
                {
                    canAttack = false;
                    attackBar_script.attackDurationleft = 0f;
                    dotweentest_Script.AttackMove();
                    yield return new WaitForSeconds(0.4f);
                    characterMovement_Script.enabled = true;
                    yield return new WaitForSeconds(2f);
                    canAttack = true;
                }
            }
            //This is basically the meat and butter of the attack and movement system
            //First if statement is there to disable the movement and fill the attack duration bar 
            //Second if statemt enables the movement script, and moves the character to the mouse position
            void DestroyObjectDelayed()
            {

            }
        }  
    }
}
