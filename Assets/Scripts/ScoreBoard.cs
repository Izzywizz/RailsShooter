using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class ScoreBoard : MonoBehaviour
{

    private TextMeshProUGUI _scoreText = null;
    private int _score = 0;


    /// Start is called before the first frame update
    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _scoreText.text = _score.ToString();
    }


    /// <summary>
    /// Adds scorePerHit score to the total score
    /// </summary>
    public void ScoreHit(int scoreGivenWhenHit)
    {
        // Change A
        // Change B

        _score += scoreGivenWhenHit;
        _scoreText.text = _score.ToString();
    }


}
