using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public const int K_STARS_NUMBER = 3;
    
    public static bool GAME_STARTED = false;


    GameObject playerController;

    private void Awake()
    {

        if (!GAME_STARTED)
            StartCoroutine(WaitForCounter());
        else
        {
            GetComponents<AudioSource>().ToList().ForEach(audio => audio.Play());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player");
        playerController.SetActive(GAME_STARTED);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForCounter()
    {
        GAME_STARTED = false;
        SceneManager.LoadScene("Counter", LoadSceneMode.Additive);
        yield return new WaitForSeconds(3f);
        GAME_STARTED = true;
    }
}
