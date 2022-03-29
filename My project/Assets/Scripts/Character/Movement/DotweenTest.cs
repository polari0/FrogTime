using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Unity.Netcode;

namespace FrogTime
{
    namespace Character
    {
        public class DotweenTest : NetworkBehaviour
        {
            //References to required components and other variables 
            [SerializeField]
            private Rigidbody2D player;

            private Vector3 mouseCurrentPos;
            internal float attackLenght = 3f;
            private float playerSize;
            private float distance = 2f;

            public LayerMask colliderWith;

            Vector3 hit2D;


            private void Start()
            {
                playerSize = player.GetComponent<CapsuleCollider2D>().size.x/2;
            }

            //Checks the mouse position each frame and turns it to wrorld point. 
            private void Update()
            {
                mouseCurrentPos = Input.mousePosition;
                mouseCurrentPos = Camera.main.ScreenToWorldPoint(mouseCurrentPos);

                RaycastHit2D hit = Physics2D.Raycast(player.position, mouseCurrentPos, distance, colliderWith);
                if (hit != null)
                {
                    hit2D = hit.point; //- hit.normal * playerSize;
                    print(hit.transform.name);

                }
                else
                {
                    hit2D = mouseCurrentPos;
                    Debug.Log("Didnthit");
                }
            }

            private void FixedUpdate()
            {

            }

            internal void AttackMove()
            {
                player.transform.DOLocalMove(hit2D, 0.2f, false);
            }
        }  
    }
}
