using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    namespace Character
    {
        internal class DrawManager : MonoBehaviour
        {
            private Camera _cam;
            [SerializeField]
            private AttackLine linePrefab;

            internal const float resolution = 0.1f;

            private AttackLine currentLine;
            void Start()
            {
                _cam = Camera.main;
            }

            void Update()
            {
                Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

                if (Input.GetMouseButtonDown(0))
                {
                    currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
                }
                if (Input.GetMouseButton(0))
                {
                    currentLine.SetPosition(mousePos);
                }
            }
        }
    } 
}
