using System.Text;
using UnityEngine;

namespace HackedDesign
{
    public class Mermaid : MonoBehaviour
    {
        [SerializeField] private float attackDelay = 1.0f;
        [SerializeField] private Transform origin;
        [SerializeField] private GameObject chest;

        private GameObject target;
        private float angerTime = 0;
        private bool fired = false;

        public void Anger(GameObject target)
        {
            this.target = target;
            this.angerTime = Time.time;
            Destroy(this.gameObject, 5);
        }

        void Update()
        {
            if (this.target != null)
            {
                this.transform.LookAt(this.target.transform, Vector3.up);
            }

            // FIXME: Use float component
            var pos = this.transform.position;
                pos.y = GameManager.Instance.Waves.GetHeight(pos);
                this.transform.position = pos;

            if(!fired && Time.time > (this.angerTime + attackDelay))
            {
                GameManager.Instance.ProjectilePool.Launch(this.gameObject, origin.position, this.target.transform.position + (this.target.transform.forward * 25f), 2.0f); // FIXME: Account for ship speed
                fired = true;
                chest.SetActive(false);
            }
        }
    }
}