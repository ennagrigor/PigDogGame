using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinishLine : MonoBehaviour
{
    [SerializeField] public Text _YouWonText;
    [SerializeField] private AudioClip Cheer;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _YouWonText.gameObject.SetActive(false);
        transform.position = new Vector3(3.9f, 6.3f, 0);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Cheer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerPig")
        {
            _YouWonText.gameObject.SetActive(true);
            other.transform.GetComponent<Mover>().Win();
            audioSource.Play();

        }
        
    }
}
