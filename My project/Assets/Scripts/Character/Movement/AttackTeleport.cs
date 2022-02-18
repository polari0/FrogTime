using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    namespace Character
    {
        public class AttackTeleport : MonoBehaviour
        {

            [SerializeField]
            private CharacterMovement characterMovement_Script;
            [SerializeField]
            private Rigidbody2D player;
            [SerializeField]
            private AttackBar attackBar_script;
            [SerializeField]
            private AttackCollisionDectection attColDec_Script;
            [SerializeField]
            private GameObject line;

            private Vector3 mousePosition;
            Vector2 position = new Vector2(0f, 0f);

            private float attackDuration = 0.002f;

            private void Start()
            {

            }
            private void Update()
            {
                StartCoroutine(Attack());
            }
            IEnumerator Attack()
            {
                if (Input.GetMouseButton(0))
                {
                    characterMovement_Script.enabled = false;
                    attackBar_script.attackDurationleft += attackDuration;
                    attackBar_script.SetBarSize(attackBar_script.attackDurationleft);
                    Debug.Log(attackBar_script.attackDurationleft);
                    
                }
                if (Input.GetMouseButtonUp(0) || (attackBar_script.attackDurationleft > attackBar_script.attackDurationMax) || (attColDec_Script.attackContinue = false))
                {
                    mousePosition = Input.mousePosition;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    player.position = mousePosition;
                    attackBar_script.attackDurationleft = 0f;
                    yield return new WaitForSeconds(.1f);
                    characterMovement_Script.enabled = true;
                    attColDec_Script.attackContinue = true;
                    DestroyObjectDelayed();
                }
            }
            //This is basically the meat and butter of the attack and movement system
            //First if statement is there to disable the movement and fill the attack duration bar 
            //Second if statemt enables the movement script, and telepports the character to the mouse position then destroys the attack line. 
            void DestroyObjectDelayed()
            {

            }
        }  
    }
}
