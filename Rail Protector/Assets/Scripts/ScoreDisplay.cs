using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI _score;
    public TextMeshProUGUI _time;
    public TextMeshProUGUI _deaths;
    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Score: " + 0;
        _time.text = "Time: " + 0.0f;
        _deaths.text = "Deaths: " + 0;

    }

    // Update is called once per frame
    void Update()
    {
        _score.text = "Score: " + GameManager.instance.score;
        _time.text = "Time: " + GameManager.instance.timer;
        _deaths.text = "Deaths: " + GameManager.instance.deathCount;
    }
}
