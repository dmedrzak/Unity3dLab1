using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float speed = 10f;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        count = 0;
        SetCountText();      
    }

	void Update ()
    {
        //pobranie fizyki komponentu kuli
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        //tworzymy zmienną kierunku zainicjalizowaną wartością zero,
        //oznacza to że jeżeli nie nacisniemy zadnego klawisza to nienastąpi zmiana kierunku ruchu kuli
        Vector3 direction = Vector3.zero;

        //zmiana kierunku ruchu 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = -Vector3.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector3.left;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = -Vector3.forward;
        }

        rigidbody.AddTorque(direction * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        if (other.gameObject.tag == "PickUp2")
        {
            other.gameObject.SetActive(false);
            count += 4;
            SetCountText();
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
