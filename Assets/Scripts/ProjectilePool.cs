using System.Text;
using UnityEngine;

namespace HackedDesign
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private Projectile projectilePrefab;

        public void Awake()
        {
            parent = this.transform;
        }

        public void Launch(GameObject owner, Vector3 origin, Vector3 target, float speed)
        {
            //float distance = (target - origin).magnitude;
            Vector3 v = CalculateVelocity(origin, target, speed);

            Projectile p = Instantiate(projectilePrefab, origin, Quaternion.identity, this.parent);
            //Destroy(p.gameObject, speed * 2);
            p.Launch(owner, v, speed);

        }
        

        public Vector3 CalculateVelocity(Vector3 origin, Vector3 target, float time)
        {
            Vector3 distance = target - origin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0f;

            float Sy = distance.y;
            float Sxz = distanceXZ.magnitude;

            float Vxz = Sxz / time;
            float Vy = Sy / time + (-0.5f * Physics.gravity.y * time);


            Vector3 result = distance.normalized;
            result *= Vxz;
            result.y = Vy;
            return result;

        }
    }
}