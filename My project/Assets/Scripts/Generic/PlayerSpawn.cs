using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    internal class PlayerSpawn : MonoBehaviour
    {
        [SerializeField]
        GameObject playerCharacter;
        private void Awake()
        {
            Instantiate(playerCharacter, Vector3.zero, transform.rotation);
        }
    } 
}
