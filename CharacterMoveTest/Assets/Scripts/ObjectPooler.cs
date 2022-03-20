using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public bool isDoublePool;
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler instance;

    public delegate void ObjectPoolerEventHandler();
    public event ObjectPoolerEventHandler poolDictionaryCreated;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            
                for(int i =0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

            poolDictionary.Add(pool.tag, objectPool);
        }
        if(poolDictionaryCreated != null)
        poolDictionaryCreated();
    }

    public GameObject SpawnFromPool(string tag, Vector2 pos, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            GameObject gameObjectToSpawn = poolDictionary[tag].Dequeue();

            gameObjectToSpawn.SetActive(true);
            gameObjectToSpawn.transform.position = pos;
            gameObjectToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(gameObjectToSpawn);

            return gameObjectToSpawn;
        }
        else
        {
            Debug.LogWarning("pool with tag " + tag + " doesnt exist.");
            return null;
        }
    }

}
