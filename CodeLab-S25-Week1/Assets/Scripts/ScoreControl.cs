using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreCounterPlayerOne, scoreCounterPlayerTwo;
    
    private int playerOneScore, playerTwoScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        
        scoreCounterPlayerOne.text = "Player One Score: " + playerOneScore;
        scoreCounterPlayerTwo.text = "Player Two Score: " + playerTwoScore;

        WASDController.PlayerCollectsCoin += UpdateScore;
    }

    private void UpdateScore(string playerName)
    {
        if (playerName == "PlayerOne")
        {
            playerOneScore += 1;
            scoreCounterPlayerOne.text = "Player One Score: " + playerOneScore;
        }
        else if(playerName == "PlayerTwo")
        {
            playerTwoScore += 1;
            scoreCounterPlayerTwo.text = "Player Two Score: " + playerTwoScore;
        }
    }


    private void OnDestroy()
    {
        WASDController.PlayerCollectsCoin -= UpdateScore;
        
    }
}
