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

            //Checks the mouse position each frame and turns it to wrorld point. 
            private void Update()
            {
                mouseCurrentPos = Input.mousePosition;
                mouseCurrentPos = Camera.main.ScreenToWorldPoint(mouseCurrentPos);
            }
            //Do tween that moves character from current position to mouse position and fast base I still haveto turn this into attack and do some other stuff but it works for testing. 
            internal void AttackMove()
            {
                player.transform.DOLocalMove(mouseCurrentPos, 0.2f, false).SetEase(Ease.Flash);
            }
        }  
    }
}
