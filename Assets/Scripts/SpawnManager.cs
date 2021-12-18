using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;

    private const int num = 30;

    private const float xRange = 4f;
    private const float zRange = 4f;
    private const float yPos = 13f;

    private const float time = .5f;
    private const float repeatRate = .5f;

    void Start()
    {
        InvokeRepeating("RandomSpawn", time, repeatRate);

        for (int i = 0; i < num; i++)
        {
            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        int index = Random.Range(0, prefabs.Count);

        Instantiate(prefabs[index], RandomPos(), prefabs[index].transform.rotation);
    }

    private Vector3 RandomPos()
    {
        float xPos = Random.Range(-xRange, xRange);
        float zPos = Random.Range(-zRange, zRange);

        return new Vector3(xPos, yPos, zPos);
    }
}
