using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace FrogTime
{
    namespace Character
    {
        public class DotweenTest : MonoBehaviour
        {
            [SerializeField]
            private Rigidbody2D player;

            private Vector3 _mouseCurrentPos;
            internal float attackLenght = 3f;

            // Start is called before the first frame update

            private void Start()
            {

            }
            private void Update()
            {
                _mouseCurrentPos = Input.mousePosition;
                _mouseCurrentPos = Camera.main.ScreenToWorldPoint(_mouseCurrentPos);
            }

            internal void AttackMove()
            {
                player.transform.DOLocalMove(_mouseCurrentPos, 0.2f, false).SetEase(Ease.Flash);
            }
        }  
    }
}
