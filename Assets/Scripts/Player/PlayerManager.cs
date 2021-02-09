using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float PlayerSpeed = 10.0f;

        [Header("Movement Types")]
        public MovementTypes ActiveMovementType = MovementTypes.JOYSTICK;

        private PlayerMovement playerMovement;

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            switch (ActiveMovementType)
            {
                case MovementTypes.JOYSTICK:
                    playerMovement.JoystickMovement(PlayerSpeed);
                    break;
            }
        }
    }

    public enum MovementTypes
    {
        JOYSTICK
    }
}