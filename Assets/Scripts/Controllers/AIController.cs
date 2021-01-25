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

        [Header("Settings")]
        [SerializeField] private float fireSpeed = 2.75f;

        public override float TurnDirection { get { return 0; } }

        private float lastFire = 0;
        private Ship us;
        private Ship targetShip;

        void Awake()
        {
            this.us = GetComponent<Ship>();
            lastFire += UnityEngine.Random.value;
        }

        public void Update()
        {
            if (!GameManager.Instance.CurrentState.PlayerActionAllowed)
            {
                return;
            }

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
    }
}