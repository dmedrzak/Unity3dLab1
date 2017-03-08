using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform sphere;

	void Update ()
    {
        //pobieranie komponent fizyki z naszej kuli
        Rigidbody rigidbody = sphere.GetComponent<Rigidbody>();

        //obliczenie nowej pozycji dla kamery 
        Vector3 vector = new Vector3(0, 5f, -7f);
        //pobieramy prędkość kuli        
        float velocity = rigidbody.velocity.sqrMagnitude;
        //zmieniamy odległość kamery tak aby zależała od prędkości kuli
        vector *= (1f+velocity / 250);

        //obliczamy nową pozycje kamery
        Vector3 newPosition = sphere.position + vector;


        //Za pomocą transformacji Lerp nadajemy płynne poruszanie się kamerze
        transform.position = Vector3.Lerp(transform.position,newPosition,Time.deltaTime*2f);

        //zmuszamy kamere aby patrzyła w środek naszej kuli
        transform.LookAt(sphere);
	}
}
