using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public bool Activ = true;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.rotation = Quaternion.Euler(45f, Time.timeSinceLevelLoad * 60f, 45f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!Activ) return;
        if (other.name != "ball") return;

        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        //GetComponent<AudioSource>().Play();
        //GetComponent<Renderer>().enabled() = false;

        Activ = false;

        var textChange = FindObjectOfType<GameController>();
        textChange.UpdateCrystalCounterText();

        //FindObjectOfType<GameController>().UpdateCrystalCounterText();
    }
}
