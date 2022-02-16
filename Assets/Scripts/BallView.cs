using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallView : MonoBehaviour
{
    private BallController _ballController;
    Text life;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        _ballController = GetComponent<BallController>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // verify game object type to take damage
        if (collision.gameObject.tag == "enemy")
        {
            
            BrickView _brickView = collision.gameObject.GetComponent<BrickView>();
            BrickModel _brickModel = collision.gameObject.GetComponent<BrickModel>();
            bool isBrickBroken = _brickView.PerformTakeDamage(1);
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(isBrickBroken) {
                gameManager.SetScore(_brickModel.Points);
            } else {
                gameManager.SetScore(-1);
            }
            score = GameObject.Find("Score").GetComponent<Text>();
            score.text = "Pontos: " + gameManager.score.ToString();
        }
        
        if (collision.gameObject.tag == "Finish")
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.DecreaseLive();
            gameManager.SetScore(-10);

            score = GameObject.Find("Score").GetComponent<Text>();
            score.text = "Pontos: " + gameManager.score.ToString();

            life = GameObject.Find("Life").GetComponent<Text>();
            life.text = gameManager.lives.ToString();
            

            _ballController.ResetBall();
            FindObjectOfType<PlayerController>().ResetPlayer();
            FindObjectOfType<AudioManager>().Play("lifeLost");
        }

        if (collision.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("bump");
        }

        // moviment ball change when player crash
        if (collision.gameObject.tag == "Player")
        {
            _ballController.CalcBallAngleReflect(collision);
            FindObjectOfType<AudioManager>().Play("playerHit");

            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.SetScore(-1);

            score = GameObject.Find("Score").GetComponent<Text>();
            score.text = "Pontos: " + gameManager.score.ToString();
        }
        else
        {
            // loads normal angle
            _ballController.PerfectAngleReflect(collision);
        }

        
    }
}
