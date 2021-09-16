using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public event UnityAction GameOver;

    [SerializeField] private IntaractionGameObjects _collisionChecker;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isTimer;
    [SerializeField] private float _time;

    private void OnEnable()
    {
        _collisionChecker.CollisionEnemy += CollisionObject;
    }

    private void OnDisable()
    {
        _collisionChecker.CollisionEnemy -= CollisionObject;
    }

    private void Update()
    {
        if (_isTimer)
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                _isTimer = false;
                _speed /= 2;
            }
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void CollisionObject(GameObject gameObject)
    {
        if (gameObject.GetComponent<Enemy>())
        {
            Destroy(gameObject);
            CheckingGameOver(gameObject.name);
        }
        else
        {
            if (gameObject.GetComponent<SpeedObject>())
            {
                _speed *= 2;
                _isTimer = true;
                _time = 2;
            }
        }
    }

    private void CheckingGameOver(string nameObject)
    {
        GameObject[] result = GameObject.FindGameObjectsWithTag(nameObject);

        if (result.Length <= 1)
        {
            GameOver?.Invoke();
            enabled = false;
        }
    }
}
