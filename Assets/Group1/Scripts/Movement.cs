using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public event UnityAction GameOver;

    public float spEed;
    public bool timer;
    public float time;

    private void Update(){
        if (timer)
        {
            time -= Time.deltaTime;
            if(time < 0)
   {
                timer = false;
                spEed /= 2;
            }
        }

        GameObject[] result = GameObject.FindGameObjectsWithTag("Enemy");

        if(result.Length == 0)
        {
            GameOver?.Invoke();
            enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, spEed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -spEed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-spEed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(spEed * Time.deltaTime, 0, 0);
    }

    public void SendMEssage(GameObject b)
    {


        if(b.name == "Enemy")
        {
            Destroy(b);
        }if(b.name == "speed")
        {
            spEed *= 2;
            timer = true;
            time = 2;



        }
    }
}
