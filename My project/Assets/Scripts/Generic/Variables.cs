using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    internal class CharacterVariables : MonoBehaviour
    {
        //Character Variables 
        internal int characterMaxHealt = 20;
       internal int characterHealt = 20;
       internal float characterSpeed;
       internal int characterDamage = 2;
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
