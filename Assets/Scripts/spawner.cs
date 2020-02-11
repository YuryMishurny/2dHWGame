using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject MonsterPref;
    public float StartTimeBtwStart;
    public int[] XSpawnPosition;

    private float _timeBtwStart = 0;

    void Update()
    {
        if (_timeBtwStart <= 0)
        {
            int rand = Random.Range(0, XSpawnPosition.Length);
            Instantiate(MonsterPref, new Vector2(XSpawnPosition[rand], transform.position.y), Quaternion.identity);
            _timeBtwStart = StartTimeBtwStart;
        }
        else
        {
            _timeBtwStart -= Time.deltaTime;
        }
    }
}
