using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace HackedDesign
{
    public class PlayerController : AbstractController
    {
        [Header("GameObjects")]
        [SerializeField] private Camera? lookCam;
        [SerializeField] private Transform cameraGimbal;
        [SerializeField] private Transform cursor;
        [SerializeField] private Waves waves = null;


        [Header("Settings")]
        [SerializeField] private float rotateSpeed = 20.0f;


        private float rotateDirection = 0;
        private float turnDirection = 0;
        private Vector2 mousePosition = Vector2.zero;
        private Ship us;

        public override float TurnDirection { get { return this.turnDirection; } }

        void Awake()
        {
            this.us = GetComponent<Ship>();
        }

        void Update()
        {
            UpdateCursor();

            cameraGimbal.Rotate(0, rotateDirection * rotateSpeed * Time.deltaTime, 0);
            //cameraGimbal.rotation = Quaternion.Euler(0, , 0);
        }

        public void TurnEvent(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                return;
            }
            this.turnDirection = context.ReadValue<float>();
        }

        public void FireEvent(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                return;
            }
            if (context.performed)
            {
                us.Launch();
                //launch.Invoke();
            }
        }

        public void LookEvent(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                return;
            }
            if (context.started)
            {
                rotateDirection = context.ReadValue<float>();
            }
            else if (context.canceled)
            {
                rotateDirection = 0;
            }
        }

        public void MousePositionEvent(InputAction.CallbackContext context)
        {
            if (!GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                return;
            }
            mousePosition = context.ReadValue<Vector2>();
        }



        private void UpdateCursor()
        {
            var plane = new Plane(Vector3.up, 0);
            var ray = lookCam.ScreenPointToRay(mousePosition);
            float enter = 0.0f;

            Vector3 position = cursor.position;

            if (plane.Raycast(ray, out enter))
            {
                //Get the point that is clicked
                Vector3 hitPoint = ray.GetPoint(enter);

                //Move your cube GameObject to the point where you clicked
                position = hitPoint;
            }

            position.y = waves.GetHeight(position);

            cursor.position = position;
        }

    }
}