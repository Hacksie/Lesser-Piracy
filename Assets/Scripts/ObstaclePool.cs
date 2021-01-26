using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    public class ObstaclePool : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> obstacles;
        [SerializeField] private float startz = 50;
        [SerializeField] private float endz = 1400;
        [SerializeField] private float randomRadius = 100;
        [SerializeField] private float obstaclesCount = 10;

        private List<GameObject> spawnedObstacles = new List<GameObject>();

        public void SpawnRandomObstacles()
        {
            DestroyObstacles();
            float skip = (endz - startz) / obstaclesCount;

            for (float z = startz; z < endz; z = z + skip)
            {
                var go = Instantiate(obstacles[Random.Range(0, obstacles.Count)], new Vector3(0, 0, z), Quaternion.identity, parent);
                var circle = Random.insideUnitCircle;
                go.transform.position = go.transform.position + (new Vector3(circle.x, 0, circle.y) * Random.Range(0, randomRadius));
                go.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                spawnedObstacles.Add(go);
            }
        }

        public void DestroyObstacles()
        {
            foreach(var ob in spawnedObstacles)
            {
                ob.SetActive(false);
                Destroy(ob);
            }
            spawnedObstacles.Clear();
        }
    }
}