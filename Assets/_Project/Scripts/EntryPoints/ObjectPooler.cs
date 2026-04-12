using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ObjectPooler : MonoBehaviour
{
    private Pool _pool = new Pool();
    private GameObject _prefab;
    public List<Pool> pools;

    private GameObject objectToSpawn;
    //private Coroutine _initialParameters;
    //private EnemyParameters _enemyParameters;
    private int _countEnemy;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    private Queue<GameObject> objectPool;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public Queue<GameObject> objectPool;
        public int i;
    }

    public static ObjectPooler Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void StartObjectPooler()
    {
        Debug.Log("запуск StartObjectPooler из StateMachine после EnemySpawner или скрипта в котором понятно какие объекты будут на карте");
        //if (_enemyParameters == null)
        //_enemyParameters = GameObject.Find("EnemyParameters").GetComponent<EnemyParameters>();
        FillPrefab();
        PoolDictionary();
    }

    private void PoolDictionary()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.name = obj.name + i;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                pool.i = i;
            }
            pool.objectPool = objectPool;
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    private void FillPrefab()
    {
        List<(string, GameObject, int)> array = new List<(string, GameObject, int)>();


        //if (_enemyParameters.YesEnemy("Enemy_01_S"))
        //{
        //    _prefab = Instantiate(Resources.Load("Enemies/Enemy_01_S", typeof(GameObject))) as GameObject;
        //    _prefab.SetActive(false);
        //    array.Add(("Enemy_01_S", _prefab, 50));
        //}
        //if (_enemyParameters.YesEnemy("Enemy_02_S"))
        //{
        //    _prefab = Instantiate(Resources.Load("Enemies/Enemy_02_S", typeof(GameObject))) as GameObject;
        //    _prefab.SetActive(false);
        //    array.Add(("Enemy_02_S", _prefab, 50));
        //}

        for (var i = 0; i < array.Count; i++)
        {
            Pool _pools = new Pool();
            _pools.tag = array[i].Item1;
            _pools.prefab = array[i].Item2;
            _pools.size = array[i].Item3;
            pools.Add(_pools);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            poolDictionary[tag].Enqueue(objectToSpawn);
        }

        return objectToSpawn;
    }
    //Enemy 
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, bool enemy)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            poolDictionary[tag].Enqueue(objectToSpawn);
            //objectToSpawn.gameObject.GetComponent<Enemy>().SetSettingParameters();
        }

        return objectToSpawn;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, GameObject spawnPoint)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            poolDictionary[tag].Enqueue(objectToSpawn);
            //objectToSpawn.gameObject.GetComponent<Hero>().SetSpawnPoint(spawnPoint);
        }

        return objectToSpawn;
    }

    //Для обычной пули (Для врага)
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, int damageHP) // string tag, позиция, куда повернута картинка
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            //objectToSpawn.gameObject.GetComponent<DmgRangeEnemy>().SetDamageHP(damageHP);
            poolDictionary[tag].Enqueue(objectToSpawn);
        }
        return objectToSpawn;
    }
    public GameObject SpawnFromPoolEnemyBlast(string tag, Vector3 position, Quaternion rotation, int damageHP, bool cutArmor) // string tag, позиция, куда повернута картинка
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            if (cutArmor)
            {
                //objectToSpawn.gameObject.GetComponent<DmgEnemyBlast>().SetDamageHP(damageHP);
                //objectToSpawn.gameObject.GetComponent<DmgEnemyBlast>().SetCutArmor(cutArmor);
            }
            else
            {
                //objectToSpawn.gameObject.GetComponent<DmgEnemyBlast>().SetDamageHP(damageHP);
            }
            poolDictionary[tag].Enqueue(objectToSpawn);
        }
        return objectToSpawn;
    }

    public GameObject SpawnFromPoolEnemyBlastDmg(string tag, Vector3 position, Quaternion rotation, int damageHP, bool cutArmor) // string tag, позиция, куда повернута картинка
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            if (cutArmor)
            {
                //objectToSpawn.gameObject.GetComponent<ImpactBlast>().SetDamageHP(damageHP);
                //objectToSpawn.gameObject.GetComponent<ImpactBlast>().SetCutArmor(cutArmor);
            }
            else
            {
                //objectToSpawn.gameObject.GetComponent<ImpactBlast>().SetDamageHP(damageHP);
            }
            poolDictionary[tag].Enqueue(objectToSpawn);
        }
        return objectToSpawn;
    }

    public GameObject SpawnFromPoolBlast(string tag, Vector3 position, Quaternion rotation, int damageHP, int whichDamage, GameObject damager, bool cutArmor) // string tag, позиция, куда повернута картинка
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            if (cutArmor)
            {
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetDamageHP(damageHP);
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetCutArmor(cutArmor);

                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetDamageHP(damageHP);
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetDamager(damager);
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetWhichDamage(whichDamage);
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetCutArmor(cutArmor);
            }
            else
            {
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetDamageHP(damageHP);
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetDamager(damager);
                //objectToSpawn.gameObject.GetComponent<DmgBlast>().SetWhichDamage(whichDamage);
            }
            poolDictionary[tag].Enqueue(objectToSpawn);
        }
        return objectToSpawn;
    }

    public GameObject SpawnFromPoolBlastDmg(string tag, Vector3 position, Quaternion rotation, int damageHP, int whichDamage, GameObject damager, bool cutArmor) // string tag, позиция, куда повернута картинка
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        objectToSpawn = poolDictionary[tag].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            if (cutArmor)
            {
                //objectToSpawn.gameObject.GetComponent<ImpactBlastHero>().SetDamageHP(damageHP);
                //objectToSpawn.gameObject.GetComponent<ImpactBlastHero>().SetDamager(damager);
                //objectToSpawn.gameObject.GetComponent<ImpactBlastHero>().SetWhichDamage(whichDamage);
                //objectToSpawn.gameObject.GetComponent<ImpactBlastHero>().SetCutArmor(cutArmor);
            }
            else
            {
                //objectToSpawn.gameObject.GetComponent<ImpactBlastHero>().SetDamageHP(damageHP);
                //objectToSpawn.gameObject.GetComponent<ImpactBlastHero>().SetDamager(damager);
                //objectToSpawn.gameObject.GetComponent<ImpactBlastHero>().SetWhichDamage(whichDamage);
            }
            poolDictionary[tag].Enqueue(objectToSpawn);
        }
        return objectToSpawn;
    }


    public GameObject SpawnFromPoolHero(string tag, Vector3 position, Quaternion rotation,
    int damageHP, int whichDamage, GameObject damager) // string tag, позиция, куда повернута картинка 
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        //objectToSpawn.gameObject.GetComponent<DmgRangeHero>().SetDamageHP(damageHP);
        //objectToSpawn.gameObject.GetComponent<DmgRangeHero>().SetDamager(damager);
        //objectToSpawn.gameObject.GetComponent<DmgRangeHero>().SetWhichDamage(whichDamage);

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public GameObject SpawnFromPoolSlow(string tag, Vector3 position, Quaternion rotation,
    int damageHP, int whichDamage, int speedPercent, GameObject damager) // string tag, позиция, куда повернута картинка 
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        //objectToSpawn.gameObject.GetComponent<DmgSlow>().SetDamageHP(damageHP);
        //objectToSpawn.gameObject.GetComponent<DmgSlow>().SetDamager(damager);
        //objectToSpawn.gameObject.GetComponent<DmgSlow>().SetWhichDamage(whichDamage);
        //objectToSpawn.gameObject.GetComponent<DmgSlow>().SetSpeed(speedPercent);

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public GameObject SpawnFromPoolTP(string tag, Vector3 position, Quaternion rotation,
  int damageHP, int whichDamage, GameObject damager, bool tp) // string tag, позиция, куда повернута картинка 
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        //objectToSpawn.gameObject.GetComponent<DmgTP>().SetDamageHP(damageHP);
        //objectToSpawn.gameObject.GetComponent<DmgTP>().SetDamager(damager);
        //objectToSpawn.gameObject.GetComponent<DmgTP>().SetWhichDamage(whichDamage);
        //objectToSpawn.gameObject.GetComponent<DmgTP>().SetTP(tp);

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

}