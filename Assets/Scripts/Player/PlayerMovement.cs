using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        #region Joystick

        private Vector2 joystickOrigin;
        private Vector2 joystickPosition;

        public void JoystickMovement(float Speed)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector3 touchScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        joystickOrigin = touchScreenPosition;
                        break;
                    case TouchPhase.Ended:
                        joystickOrigin = Vector2.zero;
                        joystickPosition = Vector2.zero;
                        break;
                }

                joystickPosition = touchScreenPosition;
            }

            Vector2 offset = joystickPosition - joystickOrigin;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            rb.AddForce((new Vector3(direction.x, 0, direction.y) * -1) * Speed, ForceMode.Force);
        }

        #endregion
    }
}