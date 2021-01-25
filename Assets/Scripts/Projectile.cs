using System.Text;
using UnityEngine;

namespace HackedDesign
{
    public class Projectile : MonoBehaviour
    {
        public GameObject owner;
        [SerializeField] private Rigidbody rigidbody;

        public void Launch(GameObject owner, Vector3 velocity, float spin)
        {
            this.owner = owner;
            rigidbody.angularVelocity = Random.onUnitSphere * spin;
            rigidbody.velocity = velocity;

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject != owner && other.CompareTag("Player"))
            {
                Ship s = other.GetComponent<Ship>();
                s.AddChest(1);
                rigidbody.velocity = Vector3.zero;
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }

        private void Update()
        {
            if(this.transform.position.y < 0 && this.owner != null && !this.owner.CompareTag("Mermaid"))
            {
                Logger.Log(this, "Spawn Mermaid");
                GameManager.Instance.MermaidPool.Spawn(this.owner, this.transform.position);
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
                
            }
        }

    }
}