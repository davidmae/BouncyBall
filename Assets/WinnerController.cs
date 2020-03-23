using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerController : MonoBehaviour
{
    bool playSound = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(WaitForWin());
    }

    IEnumerator WaitForWin()
    {
        if (!playSound)
        {
            GetComponent<AudioSource>().Play();
            playSound = true;
        }

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Winner");

        playSound = false;
    }
}
