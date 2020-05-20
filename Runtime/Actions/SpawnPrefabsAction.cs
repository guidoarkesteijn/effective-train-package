using StateMachine.Core.Actions;
using UnityEngine;

namespace StateMachine.Actions
{
    public class SpawnPrefabsAction : BaseAction
    {
        [SerializeField] private GameObject[] prefabs = null;

        private GameObject[] spawnedPrefabs;

        public override void Start()
        {
            SpawnPrefabs(prefabs);
        }

        public override void Stop()
        {
            DestroyInstances();
        }

        private void SpawnPrefabs(GameObject[] prefabs)
        {
            spawnedPrefabs = new GameObject[prefabs.Length];
            for (int i = 0; i < prefabs.Length; i++)
            {
                GameObject prefab = prefabs[i];
                GameObject instance = Object.Instantiate(prefab);
                DontDestroyOnLoad(instance);
                spawnedPrefabs[i] = instance;
            }
        }

        private void DestroyInstances()
        {
            for (int i = 0; i < spawnedPrefabs.Length; i++)
            {
                GameObject instance = spawnedPrefabs[i];
                Destroy(instance);
            }
        }
    }
}