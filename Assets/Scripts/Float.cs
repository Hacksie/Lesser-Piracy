using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace HackedDesign
{
    public class Float : MonoBehaviour
    {
        [Header("Reference GameObjects")]
        [SerializeField] private Waves waves = null;

        // Update is called once per frame
        void Update()
        {
            var position = this.transform.position;
            position.y = waves.GetHeight(position); //Mathf.Lerp(shipPosition.y, waves.GetHeight(this.transform.position), 5 * Time.fixedDeltaTime);
            this.transform.position = position;            
        }
    }
}