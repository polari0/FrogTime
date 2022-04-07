using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
        internal class CharacterMovement : CharacterVariables
        {
            //[SerializeField]
            //private CharacterVariables variables_Script;

            Vector2 mousePosition;
            Rigidbody2D rb;
            Vector2 position = new Vector2(0f, 0f);

            internal float moveSpeed = characterMoveSpeed;

            private void Start()
            {
                rb = GetComponent<Rigidbody2D>();
            }
            private void Update()
            {
                if (hasMovementSpeedChanged == true)
                {
                    moveSpeed = characterMoveSpeed;
                }
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            }
            private void FixedUpdate()
            {
                rb.MovePosition(position);
            }
        }
}
//Simple script that makes the character move at constant speed towards the mouse position. 