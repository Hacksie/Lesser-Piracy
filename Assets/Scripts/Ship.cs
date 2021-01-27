using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace HackedDesign
{
    [RequireComponent(typeof(AbstractController))]
    public class Ship : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private AbstractController controller;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform shipModel;
        [SerializeField] private Transform cannonOrigin;
        [SerializeField] private ParticleSystem explosionParticles;
        [SerializeField] private AudioSource fireSFX;
        [SerializeField] private AudioSource collectSFX;

        [Header("Reference GameObjects")]
        [SerializeField] private Transform cannonTarget;
        [SerializeField] private ProjectilePool projectilePool;

        [Header("Settings")]
        [SerializeField] private Vector3 startPosition = Vector3.zero;
        [SerializeField] private float baseForwardSpeed = 20.0f;
        [SerializeField] private float chestForwardSpeed = -1.0f;
        [SerializeField] private float baseTurnSpeed = 10.0f;
        [SerializeField] private int chests = 5;
        [SerializeField] private int startingChests = 5;
        [SerializeField] private float projectileTime = 2.0f;
        [SerializeField] private float fireSpeed = 3.0f;


        [SerializeField] private UnityEvent crash;

        private float lastFireTime = 0;

        public int CurrentChests { get { return chests; } }
        public float CurrentSpeed { get; private set; }
        public bool CurrentLaunchState { get { return Time.time > (lastFireTime + fireSpeed); } }
        //private float turnDirection = 0;
        //private Vector2 mousePosition = Vector2.zero;



        public void LateUpdateBehaviour()
        {

        }

        public void UpdateBehaviour()
        {

        }

        public void FixedUpdateBehaviour()
        {
            if (GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                Movement();
                ShipTurn();
            }
        }

        public void Reset()
        {
            this.transform.position = startPosition;
            this.transform.rotation = Quaternion.identity;
            this.chests = startingChests;
            this.lastFireTime = 0;
        }

        public void Begin()
        {
            lastFireTime = Time.time;
        }

        public void Launch()
        {
            if (this.chests > 0 && Time.time > (lastFireTime + fireSpeed))
            {
                lastFireTime = Time.time;
                this.chests--;
                projectilePool.Launch(this.gameObject, cannonOrigin.position, cannonTarget.position, projectileTime);
                if (fireSFX != null)
                {
                    fireSFX.Play();
                }
                if (explosionParticles != null)
                {
                    explosionParticles.Play(true);
                }
            }
        }

        public void AddChest(int count)
        {
            Logger.Log(this, "Gained a chest :(");
            this.chests += count;
            if (this.chests < 0) this.chests = 0;
            if (collectSFX != null)
            {
                collectSFX.Play();
            }

        }

        private void Movement()
        {
            var position = this.transform.position;
            CurrentSpeed = Mathf.Clamp(baseForwardSpeed + (chests * chestForwardSpeed), 0, baseForwardSpeed);
            position = position + (this.transform.forward * CurrentSpeed * Time.fixedDeltaTime);
            rb.MovePosition(position);
        }

        private void ShipTurn()
        {
            Quaternion deltaRotation = Quaternion.Euler(0, controller.TurnDirection * baseTurnSpeed * Time.fixedDeltaTime, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
            shipModel.localRotation = Quaternion.Euler(0, 0, -controller.TurnDirection * 2); // FIXME: lerp me
        }

        private void OnTriggerEnter(Collider other)
        {
            if (GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                if (other.CompareTag("Player"))
                {
                    crash.Invoke();
                }

                if (other.CompareTag("Obstacle"))
                {
                    crash.Invoke();
                }
            }
        }
    }
}