using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private int _scorePerHit = 12;

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
    public void ScoreHit()
    {
        _score += _scorePerHit;
        _scoreText.text = _score.ToString();
    }


}
