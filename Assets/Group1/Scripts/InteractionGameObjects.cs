using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionGameObjects : MonoBehaviour
{
    public event UnityAction<GameObject> CollisionEnemy;

    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject[] _speedObjects;
    [SerializeField] private Movement _movement;

    private float _distance = 0.2f;

    private void OnEnable()
    {
        _movement.GameOver += ActivateGameOverScreen;
    }

    private void OnDisable()
    {
        _movement.GameOver -= ActivateGameOverScreen;
    }

    private void Update()
    {
        CheckCollisionWithPlayer(_enemies);
        CheckCollisionWithPlayer(_speedObjects);
    }

    private void CheckCollisionWithPlayer(GameObject[] gameObjects)
    {
        foreach (var gameObj in gameObjects)
        {
            if (gameObj == null)
                continue;

            if (Vector3.Distance(_player.gameObject.gameObject.GetComponent<Transform>().position, 
                gameObj.gameObject.gameObject.transform.position) < _distance)
            {
                CollisionEnemy?.Invoke(gameObj);
            }
        }
    }

    private void ActivateGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }
}
