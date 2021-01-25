using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class EnemyController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform shipModel;
        [SerializeField] private Waves waves = null;

        [Header("Settings")]
        [SerializeField] private float baseForwardSpeed = 10.0f;

        public void UpdateBehaviour()
        {
            ShipFloat();
        }

        public void FixedUpdateBehaviour()
        {
            Logger.Log(this, "FixedUpdate");
            if (GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                //UpdateWaveHeight();
                // Melee();
                // Fire();
                // Look();
                Movement();
            }
        }

        private void Movement()
        {
            Logger.Log(this, "Movement");
            var position = this.transform.position;
            //position.y = waves.GetHeight(this.transform.position);

            position = position + (this.transform.forward * baseForwardSpeed * Time.fixedDeltaTime);
            
            rigidbody.MovePosition(position);


        }

        private void ShipFloat()
        {
            var shipPosition = this.transform.position;
            shipPosition.y = waves.GetHeight(this.transform.position);// Mathf.Lerp(shipPosition.y, waves.GetHeight(this.transform.position), Time.fixedDeltaTime);

            shipModel.position = shipPosition;
        }

    }
}
