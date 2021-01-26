using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using System.Collections.Generic;


namespace HackedDesign
{
    public class AIController : AbstractController
    {
        [Header("GameObjects")]
        [SerializeField] private Transform target;
        [SerializeField] private Transform goal;

        [Header("Settings")]
        [SerializeField] private float fireSpeed = 2.75f;
        [SerializeField] private float lookAheadDistance = 50.0f;
        [SerializeField] private float lookAheadRadius = 5.0f;
        [SerializeField] private LayerMask layerMask;

        private float turnDirection = 0;

        public override float TurnDirection { get { return turnDirection; } }

        private float lastFire = 0;
        private Ship us;
        private Ship targetShip;
        private int turnChoice = 0;

        void Awake()
        {
            this.us = GetComponent<Ship>();
            lastFire += UnityEngine.Random.value; // FIXME: Don't start this till we're ready to play
            turnChoice = Mathf.Sign(this.transform.position.x) < 0 ? 1 : -1; // Set this once, we'll always turn the same direction, to stop fighting around the middle
        }

        public void Update()
        {
            if (!GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                return;
            }

            UpdateTurnDirection();

            if (Time.time > (lastFire + fireSpeed))
            {
                lastFire = Time.time;
                List<Ship> targets = new List<Ship>(GameManager.Instance.Ships);

                targets.Remove(us);

                int decision = UnityEngine.Random.Range(0, 4);
                switch (decision)
                {
                    case 0:
                        // Attack the leader
                        targetShip = targets.OrderByDescending(s => s.transform.position.z).First();
                        Logger.Log(this, "Attack the leader ", targetShip.name);
                        break;
                    case 1:
                        // Attack with least chests
                        targetShip = targets.OrderBy(s => s.CurrentChests).First();
                        Logger.Log(this, "Attack with least ", targetShip.name);
                        break;
                    case 2:
                        // Attack nearest
                        targetShip = targets.OrderBy(s => (us.transform.position - s.transform.position).magnitude).First();
                        Logger.Log(this, "Attack nearest ", targetShip.name);
                        break;
                    case 3:
                    default:
                        // Attack random
                        targetShip = targets[Random.Range(0, targets.Count)];
                        Logger.Log(this, "Attack random ", targetShip.name);
                        break;
                        // attack last that attacked us
                }

                if (targetShip != null)
                {
                    Vector2 r = Random.insideUnitCircle;
                    target.position = targetShip.transform.position + (targetShip.transform.forward * (15 + targetShip.CurrentSpeed)) + new Vector3(r.x, 0, r.y);
                    us.Launch();
                }

            }


        }

        public void UpdateTurnDirection()
        {
            RaycastHit hit;

            if (Physics.SphereCast(this.transform.position, lookAheadRadius, this.transform.forward, out hit, lookAheadDistance, layerMask))
            {
                float angle = -1 * Vector3.SignedAngle(this.transform.forward, hit.point, Vector3.up);
                Logger.Log(this, "Avoiding");
                if (turnDirection == 0)
                {
                    turnDirection =  Mathf.Clamp(angle, -1, 1);
                }
            }
            else
            {
                // FIXME: Count down a short perioid after turning to stop thrashing.
                //turnDirection = 0;
                float angle = Vector3.SignedAngle(this.transform.forward, this.goal.position, Vector3.up);
                //Logger.Log(this, "Racing toward goal ", angle.ToString());
                turnDirection = Mathf.Clamp(angle, -1, 1);
                //FIXME: Turn toward goal
                //turn
            }


        }
    }
}