using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.0001f;

    private Tower _target;


    public void Init(Tower target) {
        _target = target;
    }


    void Start()
    {
        
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (currentPosition.x > _target.transform.position.x) {
            currentPosition.x -= _speed;
        }
        if (currentPosition.x < _target.transform.position.x)
        {
            currentPosition.x += _speed;
        }
        if (currentPosition.y > _target.transform.position.y)
        {
            currentPosition.y -= _speed;
        }
        if (currentPosition.y < _target.transform.position.y)
        {
            currentPosition.y += _speed;
        }
        transform.position = currentPosition;

        /*if ((Mathf.Abs(currentPosition.x) - Mathf.Abs(_target.transform.position.x) < 0.002f)) {
            _target.Damage();
            Destroy(gameObject);
            return;
        }
        if ((Mathf.Abs(currentPosition.y) - Mathf.Abs(_target.transform.position.y) < 0.002f)) {
            _target.Damage();
            Destroy(gameObject);
            return;
        }*/
    }
}
