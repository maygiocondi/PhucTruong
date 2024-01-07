using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : PoolingSupply<Enemy>
{
    static public EnemySpawner ins;


    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private const float SpawnDelay = 0.1f;
    //[SerializeField] private EffectSpawner effectSpawner;
    [SerializeField] private float SpawnCooldown;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] Transform[] spawnPos; 
    public List<Enemy> enemies = new List<Enemy>();

    private float spawnTimer = 0;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > SpawnDelay)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float xOffset = GetRandomRange(1, 15);
        float zOffset = GetRandomRange(1, 15);

        int randIndex = Random.Range(0, spawnPos.Length);

        var playerPos = spawnPos[randIndex].position;

        var tempPos = new Vector3(playerPos.x + xOffset, 100, playerPos.z + zOffset);

        Ray ray = new Ray(tempPos, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, groundMask))
        {
            tempPos.y = hit.point.y;

            if (enemies.Count >= 40)
                return;
            var enemy = GetSupply(tempPos, Quaternion.identity);    
            enemies.Add(enemy);


            //var effect = effectSpawner.GetSupply();
            //effect.transform.position = tempPos;
            //effect.Play();
            //StartCoroutine(SetEffectInactive(effect));
        }
    }

    public float GetRandomRange(float minimumDistance, float maximumDistance)
    {
        var random = Random.Range(0, 2);
        var negativeDistance = Random.Range(-maximumDistance, -minimumDistance);
        var positiveDistance = Random.Range(maximumDistance, minimumDistance);
        if (random == 0)
        {
            return negativeDistance;
        }
        else
        {
            return positiveDistance;
        }
    }

    //public override Enemy GetSupply()
    //{
    //    //return base.GetSupply();
    //    var supply = pool.FirstOrDefault(t => t.IsDead);
    //    if (supply == null)
    //    {
    //        supply = Instantiate(prefab);
    //        pool.Add(supply);
    //    }
    //    supply.SetAliveState();
    //    supply.gameObject.SetActive(false);

    //    StartCoroutine(SetEnemyActive(supply));
    //    return supply;
    //}

    //IEnumerator SetEnemyActive(Enemy enemy)
    //{
    //    yield return new WaitForSeconds(SpawnDelay);
    //    enemy.gameObject.SetActive(true);
    //}

}
