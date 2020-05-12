using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] public Text _YouWonText;

    void Start()
    {
        _YouWonText.gameObject.SetActive(false);
    }


    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "finishline")
        {
            _YouWonText.gameObject.SetActive(true);

        }

    }
}
