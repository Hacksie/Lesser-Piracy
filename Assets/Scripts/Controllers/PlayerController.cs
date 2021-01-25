#nullable enable
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace HackedDesign
{
    public class PlayerController : AbstractController
    {
        [Header("GameObjects")]
        [SerializeField] private Camera? lookCam;
        [SerializeField] private Transform? cameraGimbal;
        [SerializeField] private Transform? cursor;
        [SerializeField] private Waves? waves = null;


        [Header("Settings")]
        [SerializeField] private float rotateSpeed = 20.0f;


        private float rotateDirection = 0;
        private float turnDirection = 0;
        private Vector2 mousePosition = Vector2.zero;
        private Ship? us = null;

        public override float TurnDirection { get { return this.turnDirection; } }

        void Awake()
        {
            this.us = GetComponent<Ship>();
        }

        void Update()
        {
            UpdateCursor();
            UpdateCameraGimbal();
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
                us?.Launch();
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
                rotateDirection = 0f;
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

        public void SetCameraGimbal(Vector3 rotation)
        {
            if (cameraGimbal != null)
            {
                cameraGimbal.rotation = Quaternion.Euler(rotation);
            }
        }

        private void UpdateCursor()
        {
            if (lookCam == null || cursor == null || waves == null)
            {
                return;
            }

            var plane = new Plane(Vector3.up, 0f);
            var ray = lookCam.ScreenPointToRay(mousePosition);
            float enter = 0f;

            Vector3 position = cursor.position;

            if (plane.Raycast(ray, out enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                position = hitPoint;
            }

            position.y = waves.GetHeight(position);
            cursor.position = position;
        }

        private void UpdateCameraGimbal()
        {
            cameraGimbal?.Rotate(0f, rotateDirection * rotateSpeed * Time.deltaTime, 0f);
        }

    }
}