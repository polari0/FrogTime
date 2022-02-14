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

            private Vector3 mousePosition;
            Vector2 position = new Vector2(0f, 0f);

            private void Update()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    characterMovement_Script.enabled = false;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    mousePosition = Input.mousePosition;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    position = mousePosition;
                    characterMovement_Script.enabled = true;

                }
            }
        }  
    }
}
