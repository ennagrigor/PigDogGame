using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private int _lives = 3;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -3.99f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertivalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertivalInput * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            animator.Play("Pig Walking");
        }
        else if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow)))
        {
            animator.Play("pig walking upDown");
        }
        else
        {
            animator.Play("Idle");
        }


        //setting boundries for player
        if (transform.position.y >= 6)
            {
                transform.position = new Vector3(transform.position.x, 6, 0);
            }
            else if (transform.position.y <= -4)
            {
                transform.position = new Vector3(transform.position.x, -4, 0);
            }
            if (transform.position.x >= 9.2f)
            {
                transform.position = new Vector3(9.2f, transform.position.y, 0);
            }
            else if (transform.position.x <= -9.2f)
            {
                transform.position = new Vector3(-9.2f, transform.position.y, 0);
            }

        
    }
    public void Damage()
    {
            _lives -= 1;
            // check if the player is dead
            if (_lives < 1)
            {
                //Starts over from the begining with 3 lives
                _lives = 3;
                transform.position = new Vector3(0, -3.99f, 0);

            }

        }

        public void Win()
        {
            Destroy(this.gameObject);
        }

    }   

