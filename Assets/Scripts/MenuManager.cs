using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private GameManager gameManager;
    private Text headerText; 
    private Text playerScore; 
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        headerText = GameObject.Find("HeaderText").GetComponent<Text>();
        playerScore = GameObject.Find("PlayerScore").GetComponent<Text>();
        if(this.gameManager.gameOver) {
            headerText.text = "GAME OVER";
            playerScore.gameObject.SetActive(true);
            playerScore.text = gameManager.userName + ": " + gameManager.score;
        } else if (this.gameManager.win) {
            headerText.text = "VOCÊ GANHOU!";
            playerScore.gameObject.SetActive(true);
            playerScore.text = gameManager.userName + ": " + gameManager.score;
        } else {
            playerScore.gameObject.SetActive(false);
            headerText.text = "INÍCIO";
        }
    }

    // Update is called once per frame
    public void Play()
    {
        gameManager.NewGame();
    }

    public void SetUserName(string name) {
        this.gameManager.SetUserName(name);
    }

    public void SetEmail(string email) {
        this.gameManager.SetEmail(email);
    }
}
