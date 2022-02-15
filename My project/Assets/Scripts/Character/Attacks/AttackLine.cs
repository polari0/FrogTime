using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    namespace Character
    {
        internal class AttackLine : MonoBehaviour
        {

            [SerializeField]
            private LineRenderer _renderer;

            [SerializeField]
            private EdgeCollider2D _collider;

            private List<Vector2> _points = new List<Vector2>();

            void Start()
            {
                _collider.transform.position -= transform.position;
            }

            internal int currentPoint;


            void Update()
            {

            }
            internal void SetPosition(Vector2 pos)
            {
                if (!CanAppend(pos)) return;

                _points.Add(pos);

                _renderer.positionCount++;
                _renderer.SetPosition(_renderer.positionCount - 1, pos);

                _collider.points = _points.ToArray();
            }

            private bool CanAppend(Vector2 pos)
            {
                if (_renderer.positionCount == 0) return true;

                return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.resolution;
            }
        }  
    }
}
