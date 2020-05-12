using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    Animator animator = null;
    [SerializeField] private AudioClip barkSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = barkSound;
    }

    // Update is called once per frame
    void Update()
    {
        //moving the car to the right (using the z axis so it's down)
        transform.Translate(Vector3.right  * _speed * Time.deltaTime);
        
        //animator.Play("Dog Run");

        //setting boundries for car moving and going back to move again 
        if (transform.position.x >= 10)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
            animator.Play("Dog Run");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerPig")
        {
            other.transform.GetComponent<Mover>().Damage();
            animator = GetComponent<Animator>();
            animator.Play("Explosion");
            audioSource.Play();

           
           
        }
       
    }
}
