using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public static CollisionChecker controller;

    public GameObject GameOverScreen;
    public GameObject Player;
    public GameObject[] Enemies;

    private void Start()
    {
        controller = this;
    }

    private void End()
    {
        GameOverScreen.SetActive(true);
    }

    private void Update(){
        foreach (var b in Enemies)
        {
            if (b == null)
                continue;

                if (Vector3.Distance(Player.gameObject.gameObject.GetComponent<Transform>().position, b.gameObject.gameObject.transform.position) < 0.2f)
                {
                    Player.SendMessage("SendMEssage", b);
                }

        }
    }
}
