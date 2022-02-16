using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    private BrickModel _brickModel;
    private string numberBricks;
    public BrickModel BrickModel { get => _brickModel; set => _brickModel = value; }
    public SpriteRenderer spriteRenderer { get; private set; }

    void Awake() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _brickModel = GetComponent<BrickModel>();
        _brickModel.Health = _brickModel.States.Length;
        this.spriteRenderer.sprite = _brickModel.getState(_brickModel.Health - 1);
    }

    // Update is called once per frame
    public bool TakeDamage(int damage)
    {
        if(!_brickModel.Unbreakable) {
            _brickModel.Health -= damage;

            if (_brickModel.Health <= 0) {
                gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Play("broken");
                return true;
            } else {
                this.spriteRenderer.sprite = _brickModel.getState(_brickModel.Health - 1);
                FindObjectOfType<AudioManager>().Play("brickHit");
                return false;
            } 
        } else {
            FindObjectOfType<AudioManager>().Play("bump");
            return false;
        }
    }
}
