using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider SpawnArea;
    public GameObject[] FruitPrefab;

    public float MinSpawnDelay = 0.25f;
    public float MaxSpawnDelay = 1F;

    public float MinAngle = -15f;
    public float MaxAngle = 15f;

    public float MinForce = 18f;
    public float MaxForce = 22f;

    public float MaxLifeTime = 5f;

    private void Awake()
    {
        SpawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while(enabled)
        {
            GameObject Prefab = FruitPrefab[Random.Range(0, FruitPrefab.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x);
            position.y = Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);
            position.z = Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(MinAngle, MaxAngle));

            GameObject fruit = Instantiate(Prefab, position, rotation);
            Destroy(fruit, MaxLifeTime);

            float force = Random.Range(MinForce, MaxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(MinSpawnDelay, MaxSpawnDelay));
        }


    }
}
