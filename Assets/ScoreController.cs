using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public List<GameObject> starts;
    public Sprite emptyStart;
    public TextMeshProUGUI timeTMesh;

    public float levelTime;

    public int currentStar;
    public float timeThresholdToLoseStar;

    public float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentStar = GameController.K_STARS_NUMBER - 1;
        timeThresholdToLoseStar = levelTime / (GameController.K_STARS_NUMBER + 1);
    }

    // Update is called once per frame
    void Update()
    {
        levelTime -= Time.deltaTime;
        timeTMesh.text = ((int)levelTime+1).ToString();

        if (currentStar < 0)
            return;

        if ( currentTime >= timeThresholdToLoseStar )
        {
            starts[currentStar].GetComponent<Image>().sprite = emptyStart;
            currentTime = 0f;
            currentStar--;
        }

        currentTime += Time.deltaTime;


    }
}
