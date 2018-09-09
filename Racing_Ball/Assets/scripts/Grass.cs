using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name != "ball") return;
        FindObjectOfType<GameController>().LoseGame();
    }
}
