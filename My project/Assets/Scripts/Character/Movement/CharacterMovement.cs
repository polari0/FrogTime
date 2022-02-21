using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    namespace Character
    {
        internal class CharacterMovement : MonoBehaviour
        {
            Vector2 mousePosition;
            [SerializeField]
            internal float moveSpeed = 0.3f;
            Rigidbody2D rb;
            Vector2 position = new Vector2(0f, 0f);

            private void Start()
            {
                rb = GetComponent<Rigidbody2D>();
            }
            private void Update()
            {
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
}
