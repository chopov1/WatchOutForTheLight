using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    ObjectPooler pooler;
    public Vector2 directionToShoot;
    public float projectileSpeed;
    bool assignSecondPos = false;
    public Vector2 Displacement;
    bool active = true;
    public float dispenseRate = 2;
    // Start is called before the first frame update
    void Start()
    {

        pooler = ObjectPooler.instance;
        pooler.poolDictionaryCreated += setProjectileProperties;
        StartCoroutine(spawnEnemies());
    }
    private void setProjectileProperties()
    {
        foreach(GameObject obj in pooler.poolDictionary["Platform"])
        {
            Projectile p = obj.GetComponent<Projectile>();
            p.direction = directionToShoot;
            p.moveSpeed = projectileSpeed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
        }
    }
    public void spawnEnemy()
    {
        if(assignSecondPos == false)
        {
            pooler.SpawnFromPool("Platform", transform.position, Quaternion.identity);
            assignSecondPos = true;
            return;
        }
        pooler.SpawnFromPool("Platform", (Vector2)transform.position + Displacement, Quaternion.identity);
        assignSecondPos=false;
        return;
    }

    IEnumerator spawnEnemies()
    {
        while (active)
        {
            yield return new WaitForSeconds(dispenseRate);

            spawnEnemy();
        }
    }
}
