using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class movement : MonoBehaviour
{
    public GameObject Apple;
    public GameObject Body;
    public GameObject Snake;
    public Camera cam;

    [SerializeField]
    private List<GameObject>segments = new List<GameObject>();
    [SerializeField]
    private List<BoxCollider> colliders = new List<BoxCollider>();  

    public int score = 0;
    private int idk = 3;
    private int side = 1;
    // Start is called before the first frame update
    void Start()
    {
        segments.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(side == 1)
        {
            moveFaceUp();
        }

        if (side == 2 )
        {
            moveFaceBack();
        }
        if (side == 3 )
        {
            moveFaceLeft();
        }
        if(side == 4 )
        {
            moveFaceFront();
        }
        if (side == 5)
        {
            moveFaceRight();
        }
        if (side == 6)
        {
            moveFaceDown();
        }


        CheckSize();

    }

  
    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i>0;i--)
        {
            segments[i].transform.position = segments[i-1].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "apple")
        {
            score++;
            BoxCollider spawn =colliders[Random.Range(0,colliders.Count)];
            Bounds bounds = spawn.bounds;

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            float z = Random.Range(bounds.min.z, bounds.max.z);

            var position = new Vector3(x,y,z);
            Instantiate(Apple, position, Quaternion.identity);

            //if(gameObject.)


            if (idk == 0)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x, 0, GetComponent<Transform>().position.z);
                GameObject body = Instantiate(Body, pos, Quaternion.identity,Snake.GetComponent<Transform>());
                segments.Add(body);
            }
            if (idk == 1)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x, 0, GetComponent<Transform>().position.z );
                GameObject body = Instantiate(Body, pos, Quaternion.identity, Snake.GetComponent<Transform>());
                segments.Add(body);
            }
            if (idk == 2)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x, 0, GetComponent<Transform>().position.z);
                GameObject body = Instantiate(Body, pos, Quaternion.identity, Snake.GetComponent<Transform>());
                segments.Add(body);
            }
            if (idk == 3)
            {
                var pos = new Vector3(GetComponent<Transform>().position.x , 0, GetComponent<Transform>().position.z);
                GameObject body = Instantiate(Body, pos, Quaternion.identity, Snake.GetComponent<Transform>());
                segments.Add(body);
            }
        }
    }

    public void CheckSize()
    {
        if (GetComponent<Transform>().position.z > 5.5f && side !=4)
        {
            side = 4;
            return;
        }
        
        if (GetComponent<Transform>().position.x > 5.5f && side != 3)
        {
            side = 3;
            return;
        }
        if (GetComponent<Transform>().position.z < -5.5f && side != 2)
        {
            side = 2;
            return;
        }
        if (GetComponent<Transform>().position.y > 0.0f && side != 1)
        {
            side = 1;
            return;
        }
        if (GetComponent<Transform>().position.x < -5.5f && side != 5)
        {
            side = 5;
            return;
        }
        if (GetComponent<Transform>().position.y < -11.0f && side != 6)
        {
            side = 6;
            return;
        }
    }

    public void moveFaceUp()
    {
        if (idk == 0)//haut
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
        if (idk == 1)//gauche
        {

            GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }
        }
        if (idk == 2)//droite
        {

            GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }

        }
        if (idk == 3)//bas
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
    }

    public void moveFaceDown()
    {
        if (idk == 0)//haut
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
        if (idk == 1)//gauche
        {

            GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }
        }
        if (idk == 2)//droite
        {

            GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }

        }
        if (idk == 3)//bas
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
    }

    public void moveFaceBack()
    {
        if (idk == 0)//haut
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
        if (idk == 1)//gauche
        {

            GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }
        }
        if (idk == 2)//droite
        {

            GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }

        }
        if (idk == 3)//bas
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
    }

    public void moveFaceFront()
    {
        if (idk == 0)//haut
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
        if (idk == 1)//gauche
        {

            GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }
        }
        if (idk == 2)//droite
        {

            GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }

        }
        if (idk == 3)//bas
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
    }

    public void moveFaceLeft()
    {
        if (idk == 0)//haut
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
        if (idk == 1)//gauche
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }
        }
        if (idk == 2)//droite
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }

        }
        if (idk == 3)//bas
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
    }

    public void moveFaceRight()
    {
        if (idk == 0)//haut
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
        if (idk == 1)//gauche
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }
        }
        if (idk == 2)//droite
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
            if (Input.GetKey(KeyCode.W))
            {
                idk = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                idk = 3;
            }

        }
        if (idk == 3)//bas
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
            if (Input.GetKey(KeyCode.A))
            {
                idk = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                idk = 2;
            }

        }
    }

}
