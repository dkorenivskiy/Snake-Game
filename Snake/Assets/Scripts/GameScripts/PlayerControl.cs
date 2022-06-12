using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public delegate void PlayerDelegate();
    public event PlayerDelegate OnScoreIncrement;
    public event PlayerDelegate OnGameOverMenu;

    public Transform TailPrefab;
    public bool StopSnake;

    private Animator _animator;
    private Vector2 _rotation = new Vector2();
    private HeadRotation _headRotation = HeadRotation.up;
    private List<Transform> _snakeTails;

    enum HeadRotation
    {
        up,
        down,
        right,
        left
    }

    private void Start()
    {
        StopSnake = false;

        _rotation = Vector2.up;
        _animator = GetComponent<Animator>();

        _snakeTails = new List<Transform>();
        _snakeTails.Add(this.transform);
        _snakeTails.Add(TailPrefab);
    }

    private void Update()
    {
        if (StopSnake == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_headRotation != HeadRotation.down)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    _rotation = Vector2.up;
                    _headRotation = HeadRotation.up;
                    _animator.Play("HeadWalk");

                    this.transform.position = new Vector3()
                    {
                        x = this.transform.position.x,
                        y = this.transform.position.y + 1,
                        z = this.transform.position.z
                    };
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (_headRotation != HeadRotation.up)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 180);
                    _rotation = Vector2.down;
                    _headRotation = HeadRotation.down;
                    _animator.Play("HeadWalk");


                    this.transform.position = new Vector3()
                    {
                        x = this.transform.position.x,
                        y = this.transform.position.y - 1,
                        z = this.transform.position.z
                    };
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_headRotation != HeadRotation.right)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 90);
                    _rotation = Vector2.left;
                    _headRotation = HeadRotation.left;
                    _animator.Play("HeadWalk");

                    this.transform.position = new Vector3()
                    {
                        x = this.transform.position.x - 1,
                        y = this.transform.position.y,
                        z = this.transform.position.z
                    };
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_headRotation != HeadRotation.left)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, -90);
                    _rotation = Vector2.right;
                    _headRotation = HeadRotation.right;
                    _animator.Play("HeadWalk");

                    this.transform.position = new Vector3()
                    {
                        x = this.transform.position.x + 1,
                        y = this.transform.position.y,
                        z = this.transform.position.z
                    };
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (StopSnake == false)
        {
            for (int i = _snakeTails.Count - 1; i > 0; i--)
            {
                _snakeTails[i].transform.position = MovingForward(_snakeTails[i - 1]);
            }

            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x + _rotation.x),
                Mathf.Round(this.transform.position.y + _rotation.y),
                1f);
        }
    }

    private Vector3 MovingForward(Transform target)
    {
        return new Vector3(
            Mathf.Round(target.position.x),
            Mathf.Round(target.position.y),
            1f
            );
    }

    public void Grow()
    {
        Transform newTail = Instantiate(TailPrefab);
        newTail.position = MovingForward(_snakeTails[_snakeTails.Count - 1].transform);

        _snakeTails.Add(newTail);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rubin")
        {
            Grow();
            OnScoreIncrement.Invoke();
        }

        if (other.tag == "WallsHorizontal")
        {
            transform.position = transform.position.x > 0 ? new Vector3() { x = -1f * transform.position.x + 1, y = transform.position.y, z = transform.position.z }
                                                          : new Vector3() { x = -1f * transform.position.x - 1, y = transform.position.y, z = transform.position.z };
        }

        if (other.tag == "WallsVertical")
        {
            transform.position = transform.position.y > 0 ? new Vector3() { x = transform.position.x, y = -1f * transform.position.y + 1, z = transform.position.z }
                                                         : new Vector3() { x = transform.position.x, y = -1f * transform.position.y - 1, z = transform.position.z };
        }

        if (other.tag == "Tail")
        {
            _rotation = Vector2.zero;
            _animator.Play("SnakeDead");

            StopSnake = true;

            OnGameOverMenu.Invoke();
        }
    }
}
