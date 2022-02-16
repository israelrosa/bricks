using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickModel : MonoBehaviour
{
    private int _health;
    [SerializeField]private int _points = 10;
    [SerializeField]private bool _unbreakable;
    [SerializeField]private Sprite[] _states;




    public int Health { get => _health; set => _health = value; }
    public int Points { get => _points; }
    public bool Unbreakable { get => _unbreakable; }

    public Sprite[] States {get => _states; }
    public Sprite getState(int state) { 
        return this._states[state];
    }
}