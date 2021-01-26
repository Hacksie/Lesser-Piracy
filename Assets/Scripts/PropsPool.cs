using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    public class PropsPool : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> props;
        [SerializeField] private float startz = 50;
        [SerializeField] private float endz = 1400;
        [SerializeField] private float randomRadius = 100;
        [SerializeField] private float propsCount = 100;

        private List<GameObject> spawnedProps = new List<GameObject>();

        public void SpawnRandomProps()
        {
            DestroyProps();
            float skip = (endz - startz) / propsCount;

            for (float z = startz; z < endz; z = z + skip)
            {
                var go = Instantiate(props[Random.Range(0, props.Count)], new Vector3(0, 0, z), Quaternion.identity, parent);
                var circle = Random.insideUnitCircle;
                go.transform.position = go.transform.position + (new Vector3(circle.x, 0, circle.y) * Random.Range(0, randomRadius));
                go.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                spawnedProps.Add(go);
            }
        }

        public void DestroyProps()
        {
            foreach(var ob in spawnedProps)
            {
                ob.SetActive(false);
                Destroy(ob);
            }
            spawnedProps.Clear();
        }
    }
}