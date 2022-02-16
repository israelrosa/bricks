using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private BallModel _ballModel;
    private Rigidbody2D _ballRigibody;

    // Start is called before the first frame update
    void Start()
    {
        _ballModel = GetComponent<BallModel>();
        _ballRigibody = GetComponent<Rigidbody2D>();

        this.ResetBall();
    }

    public void ResetBall() {
        this.transform.position = Vector2.zero;
        _ballRigibody.velocity = Vector2.zero;

        _ballRigibody.velocity = _ballModel.Direction * _ballModel.Speed;
    }

    // Update is called once per frame
    public void PerfectAngleReflect(Collision2D collision)
    {
        Vector2 direction = Vector2.Reflect(_ballModel.Direction, collision.contacts[0].normal);
        AngleChange(direction);
    }

    public void CalcBallAngleReflect(Collision2D colision)
    {
        // calc angle for player reflect
        float playerPixels = 250f * 0.4f;

        // convert sizemto unity scale
        float unityScaleHalfPlayerPixels = playerPixels / 2f / 100f;

        // convert 0 to 120 (player) to 0 to 150 (angle)
        float scaleFactorPut1dot150Range = 150 / playerPixels;

        // calc angle from unity scale (0 > 1.8)
        float angleDegUnityScale = (
            colision.transform.position.x -
            transform.position.x +
            unityScaleHalfPlayerPixels
        ) * scaleFactorPut1dot150Range;

        float angleDeg = angleDegUnityScale * 100f;

        float angleRad = angleDeg * Mathf.PI / 180f;

        Vector2 vetorRetorno = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        AngleChange(vetorRetorno);
    }

    public void AngleChange(Vector2 direcion)
    {
        _ballModel.Direction = direcion;
        _ballRigibody.velocity = _ballModel.Direction * _ballModel.Speed;
    }
}
