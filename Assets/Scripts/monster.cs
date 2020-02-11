using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    [SerializeField] private Transform _path;
    private Transform[] _points;
    private int _currentPoint;

    public int Damage;
    public float Speed;

    private void Start()
    {
        _points = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<player>().ApplyDamage(Damage);
        }
    }
}
