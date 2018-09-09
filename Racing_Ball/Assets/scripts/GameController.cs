using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour {

    public Text CrystalCounterText;
    public Text CountDownText;
    public Text EndText;

    public AudioClip StartGameAudio;
    public AudioClip CountDownAudio;
    public AudioClip LoseAudio;
    public AudioClip WinAudio;

    void Start ()
    {
        UpdateCrystalCounterText();

        EndText.enabled = false;

        StartCoroutine(CountDownCoroutine());
    }
	
	void Update ()
    {
  
	}

    IEnumerator CountDownCoroutine()
    {
        var audio = GetComponent<AudioSource>();
        audio.clip = CountDownAudio;
        FindObjectOfType<Ball>().CanMove = false;
        CountDownText.enabled = true;

        for(int i=5; i>0; i--)
        {
            CountDownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
            if (i != 1)
                audio.Play();

        }
        audio.clip = StartGameAudio;
        audio.Play();

        CountDownText.text = "START!";
        FindObjectOfType<Ball>().CanMove = true;
        yield return new WaitForSeconds(1f);

        CountDownText.enabled = false;

    }

    void DisableBallMovement()
    {
        var ball = FindObjectOfType<Ball>();
        ball.CanMove = false;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
       
    }

    public void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>();

        var crystalCounter = crystals.Length;
        var crystalsInactive = crystals.Count(Crystal => !Crystal.Activ);

        var text = crystalsInactive + " / " + crystalCounter;
        CrystalCounterText.text = text;
    }

    public void CheckIfEndOfGame()
    {
        if (FindObjectsOfType<Crystal>().All(crystal => !crystal.Activ)) 
        {
            WinGame();

        }
        else
        {
            LoseGame();

        }

    }

    private void WinGame()
    {
        var audio = GetComponent<AudioSource>();

        DisableBallMovement();
        EndText.enabled = true;
        EndText.text = "YOU WIN";
        audio.clip = WinAudio;
        audio.Play();
    }

    public void LoseGame()
    {
        var audio = GetComponent<AudioSource>();

        DisableBallMovement();
        EndText.enabled = true;
        EndText.text = "YOU LOSE";
        audio.clip = LoseAudio;
        audio.Play();
    }
}
