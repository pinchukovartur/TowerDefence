using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.0001f;

    [SerializeField]
    private Vector2 _colisionSize = new Vector2(0.4f, 0.4f);

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

        if (IsColision())
        {
            _target.Damage();
            Destroy(gameObject);
        }

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

    bool IsColision() {
        var targetPosition = _target.transform.position;
        var targetSize = _target.GetSize();
        var bullPosition = _target.transform.position;
        var bulletSize = _colisionSize;
        var bulletPosition = transform.position;

        return targetPosition.x < bulletPosition.x + bulletSize.x &&
               targetPosition.x + targetSize.x > bulletPosition.x &&
               targetPosition.y < bulletPosition.y + bulletSize.y &&
               targetPosition.y + targetSize.y > bulletPosition.y;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(_colisionSize.x, _colisionSize.y, 1));
    }


}
