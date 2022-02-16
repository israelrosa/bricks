using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallController ball { get; private set; }
    public PlayerController player { get; private set; }
    public BrickModel[] bricks { get; private set; }
    public int score = 0;
    public int level = 0;
    public int lives = 3;
    public string userName;
    public string email;
    public bool gameOver;
    public bool win;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void Start() {
        SceneManager.LoadScene("Menu");
    }

    public void NewGame() {
        score = 0;
        lives = 3;
        gameOver = false;
        win = false;

        LoadLevel(1);
    }

    private void LoadLevel(int level) {
        if(level > 3) {
            this.Win();
        } else {
            this.level = level;
            SceneManager.LoadScene("Level" + level);
            if(level != 1) {
                FindObjectOfType<AudioManager>().Play("success");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode) {
        this.ball = FindObjectOfType<BallController>();
        this.player = FindObjectOfType<PlayerController>();
        this.bricks = FindObjectsOfType<BrickModel>();
    }

    private void GameOver() {
        SceneManager.LoadScene("Menu");
        gameOver = true;
    }

    private void Win() {
        SceneManager.LoadScene("Menu");
        win = true;
    }

    public void SetScore(int score) {
        this.score += score;

        if (this.Cleared()) {
            LoadLevel(level + 1);
        }
    }

    public void DecreaseLive() {
        if(this.lives > 1) {
            this.lives--;
            ResetLevel();
        } else {
            this.GameOver();
        }
    }

    private void ResetLevel() {
        player.ResetPlayer();
        ball.ResetBall();
    }

    private bool Cleared() {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].Unbreakable) {
                return false;
            }
        }

        return true;
    }

    public void SetUserName(string name) {
        this.userName = name;
    }

    public void SetEmail(string email) {
        this.email = email;
    }
}
