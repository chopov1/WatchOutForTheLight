using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    ObjectPooler pooler;
    public Vector2 directionToShoot;
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {

        pooler = ObjectPooler.instance;
        pooler.poolDictionaryCreated += setProjectileProperties;
        
    }

    private void setProjectileProperties()
    {
        foreach(GameObject obj in pooler.poolDictionary["Enemy"])
        {
            Projectile p = obj.GetComponent<Projectile>();
            p.direction = directionToShoot;
            p.moveSpeed = projectileSpeed;
        }
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            spawnEnemy();
        }
    }

    public void spawnEnemy()
    {
        pooler.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
    }
}
