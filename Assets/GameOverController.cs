using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Collider2D colliderLeft, colliderRight;
    Collider2D player;

    bool playSound = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colliderLeft.bounds.Intersects(player.bounds) || colliderRight.bounds.Intersects(player.bounds))
            StartCoroutine(WaitForLose());
    }

    IEnumerator WaitForLose()
    {
        if (!playSound)
        {
            GetComponent<AudioSource>().Play();
            playSound = true;
        } 

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Losser");
        playSound = false;
    }
}
