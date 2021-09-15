using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private Movement _movement;

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
        foreach (var enemy in Enemies)
        {
            if (enemy == null)
                continue;

                if (Vector3.Distance(Player.gameObject.gameObject.GetComponent<Transform>().position, enemy.gameObject.gameObject.transform.position) < 0.2f)
                {
                    Player.SendMessage("SendMEssage", enemy);
                }

        }
    }

    private void ActivateGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }
}
