using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class movement : MonoBehaviour
{
    public GameObject Apple;
    public GameObject Body;
    public GameObject Snake;

    public int score = 0;
    private int idk = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (idk == 0)//haut
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0 , 0, 10);
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().Rotate(1, 1, 90);
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().Rotate(1, 1, -90);
                idk = 2;
            }

        }
        if (idk == 1)//gauche
        {

            GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().Rotate(1, 1, -90);
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().Rotate(1, 1, 90);
                idk = 3;
            }
        }
        if (idk == 2)//droite
        {

            GetComponent<Rigidbody>().velocity = new Vector3(10,0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().Rotate(1, 1, 90);
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().Rotate(1, 1, -90);
                idk = 3;
            }

        }
        if (idk == 3)//bas
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().Rotate(1, 1, -90);
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().Rotate(1, 1, 90);
                idk = 2;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "apple")
        {
            score++;
            var position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            Instantiate(Apple, position, Quaternion.identity);

            //if(gameObject.)


            if (idk == 0)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x, 0, GetComponent<Transform>().position.z - 1);
                GameObject body = Instantiate(Body, pos, Quaternion.identity,Snake.GetComponent<Transform>());
            }
            if (idk == 1)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x + 1, 0, GetComponent<Transform>().position.z );
                GameObject body = Instantiate(Body, pos, Quaternion.identity, Snake.GetComponent<Transform>());
            }
            if (idk == 2)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x - 1, 0, GetComponent<Transform>().position.z);
                GameObject body = Instantiate(Body, pos, Quaternion.identity, Snake.GetComponent<Transform>());
            }
            if (idk == 3)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x , 0, GetComponent<Transform>().position.z + 1);
                GameObject body = Instantiate(Body, pos, Quaternion.identity, Snake.GetComponent<Transform>());
            }
        }
    }
}
