using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public event UnityAction GameOver;

    [SerializeField] private CollisionChecker _collisionChecker;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isTimer;
    [SerializeField] private float _time;

    private void OnEnable()
    {
        _collisionChecker.CollisionEnemy += CollisionAction;
    }

    private void OnDisable()
    {
        _collisionChecker.CollisionEnemy -= CollisionAction;
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

        CheckingGameOver();

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void CollisionAction(GameObject gameObject)
    {
        if (gameObject.name == "Enemy")
        {
            Destroy(gameObject);
        }
        if (gameObject.name == "speed")
        {
            _speed *= 2;
            _isTimer = true;
            _time = 2;
        }
    }

    private void CheckingGameOver()
    {
        GameObject[] result = GameObject.FindGameObjectsWithTag("Enemy");

        if (result.Length == 0)
        {
            GameOver?.Invoke();
            enabled = false;
        }
    }
}
