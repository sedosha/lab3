using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab1 : MonoBehaviour
{
    [SerializeField] private float speed;

    public bool Grounded;
    public float Distance = 0.8f;
    public float JumpForce = 10f;
    public float _Gravity = -4f;
    private float GravityScale = 0f;
    private float Antigravity = -10f;

    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, Distance))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        
        Gravity();
    }
    void Gravity()
    {

        if (!Grounded)
        {
            transform.Translate(new Vector3(0, _Gravity, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(0, GravityScale, 0) * Time.deltaTime);
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(new Vector3(0, JumpForce, 0) * Time.deltaTime);
                _Gravity = JumpForce;

            }

        }
        if (!Grounded && transform.position.y >= 15f)
        {
            _Gravity = Antigravity;
            transform.Translate(new Vector3(0, _Gravity, 0) * Time.deltaTime);
        }

    }
}