using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    TextMeshProUGUI textmesh;
    AudioSource counterAudio;

    float currTime = 0f;
    int timer = 3;

    // Start is called before the first frame update
    void Start()
    {
        textmesh = GameObject.FindGameObjectWithTag("Counter")?.GetComponentInChildren<TextMeshProUGUI>();
        counterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textmesh == null || counterAudio == null)
            return;

        if (timer == -1f)
        {
            StartGame();
            return;
        }

        if (timer == 0f)
        {
            textmesh.fontSize = 450;
            textmesh.text = "¡GO!";
            currTime += Time.deltaTime * 2f;
        }

        if (currTime > 1f)
        {
            timer--;
            currTime = 0f;
            if (timer > 0)
            {
                textmesh.text = timer.ToString();
                counterAudio.Play();
            }
        }

        currTime += Time.deltaTime;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
    }

    public void StartCounter()
    {
        SceneManager.LoadScene("Counter", LoadSceneMode.Single);
    }

    public void ReStart()
    {
        GameController.GAME_STARTED = false;
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

}
