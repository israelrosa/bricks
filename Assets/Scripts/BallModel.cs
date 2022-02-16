using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallModel : MonoBehaviour
{
    [SerializeField] private float _power;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    public float Power { get => _power; set => _power = value; }

    public float Speed { get => _speed; set => _speed = value; }

    public Vector2 Direction { get => _direction; set => _direction = value; }
}
