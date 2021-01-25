using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using System.Collections.Generic;


namespace HackedDesign
{
    public class AIController : AbstractController
    {
        public override float TurnDirection { get { return 0; } }
        [SerializeField] private Transform target;
        //[SerializeField] private float targetSwitchSpeed = 1.25f;
        [SerializeField] private float fireSpeed = 2.75f;

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
                float decision = UnityEngine.Random.value;
                List<Ship> targets = new List<Ship>(GameManager.Instance.Ships);

                targets.Remove(us);

                if (decision <= 0.33f)
                {
                    // Attack the leader
                    targetShip = targets.OrderByDescending(s => s.transform.position.z).First();
                    Logger.Log(this, "Attack the leader ", targetShip.name);
                }
                else if (decision > 0.33f && decision <= 0.66f)
                {
                    // Attack with least chests
                    targetShip = targets.OrderBy(s => s.CurrentChests).First();
                    Logger.Log(this, "Attack the least ", targetShip.name);
                }
                else
                {
                    // Attack random
                    targetShip = targets[Random.Range(0, targets.Count)];
                    Logger.Log(this, "Attack random ", targetShip.name);
                }

                // Attack nearest
                // targetShip = targets.OrderBy(s => (us.transform.position - s.transform.position).magnitude).First();
                // attack last that attacked us
                if (targetShip != null)
                {
                    Vector2 r = Random.insideUnitCircle;
                    target.position = targetShip.transform.position + (targetShip.transform.forward * (15 + targetShip.CurrentSpeed)) + new Vector3(r.x, 0, r.y);
                    us.Launch();
                }

            }

            if (targetShip != null)
            {
                // Lerp toward position


                //GameManager.Instance.ProjectilePool.Launch(this.gameObject, origin.position, this.target.transform.position + (this.target.transform.forward * 25f), 2.0f); // FIXME: Account for ship speed
            }
        }
    }
}