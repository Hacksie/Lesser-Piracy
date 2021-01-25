using System.Text;
using UnityEngine;

namespace HackedDesign
{
    public class MermaidPool : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private Mermaid mermaidPrefab;
        [SerializeField] private Waves waves = null;


        public void Awake()
        {
            parent = this.transform;
        }

        public void Spawn(GameObject attacker, Vector3 position)
        {
            position.y = 0.0f;
            Mermaid m = Instantiate(mermaidPrefab, position, Quaternion.identity, this.parent);
            m.Anger(attacker, this.waves);
            //Destroy(m.gameObject, 5);
        }        
    }
}