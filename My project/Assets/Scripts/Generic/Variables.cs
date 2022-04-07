using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    internal class Variables : MonoBehaviour
    {
        //Enemy Variables
        internal int enemyHealt;
        internal int enemyDamage;
    }
    internal class CharacterVariables : MonoBehaviour
    {
       //Character Variables 
       internal int characterHealt;
       internal float characterSpeed;
       internal int characterDamage;
       internal static float characterMoveSpeed = 0.1f;
       internal bool hasMovementSpeedChanged = false;
       internal void ChangeMovementSpeed()
        {
            if(hasMovementSpeedChanged == false)
            {
		        hasMovementSpeedChanged = true; 
            }
       }
    } 
}
