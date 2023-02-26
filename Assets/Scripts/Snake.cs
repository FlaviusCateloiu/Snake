using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //Video del Snake: https://www.youtube.com/watch?v=U8gUnpeaMbQ
    //Web tambien con Snake: https://noobtuts.com/unity/2d-snake-game
    private static int _maxFrutasComidas = 5;
    private static int _frutasComidas = 0;
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public ParticleSystem particulas;
    private AudioSource _audioSource;
    public GameObject gameOver;
    public TextMeshProUGUI totalPuntosGameOver;
    public Camera mainCamera;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Rotate(_direction, 90);
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Rotate(_direction, -90);
        }
    }
    
    private Vector2 Rotate(Vector2 v, float degrees) {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
    
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        
        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++) 
        {
            Destroy(_segments[i].gameObject);
        }
        
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    private void OutOfBoundsVertical()
    {
        if (this.transform.position.y < 0)
        {
            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x), Mathf.Round((this.transform.position.y * -1) - 1), Mathf.Round(this.transform.position.z));
        }
        else
        {
            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x), Mathf.Round((this.transform.position.y * -1) + 1), Mathf.Round(this.transform.position.z));
        }
    }
    
    private void OutOfBoundsHorizontal()
    {
        if (this.transform.position.x < 0)
        {
            this.transform.position = new Vector3(Mathf.Round((this.transform.position.x * -1) - 1), Mathf.Round(this.transform.position.y), Mathf.Round(this.transform.position.z));
        }
        else
        {
            this.transform.position = new Vector3(Mathf.Round((this.transform.position.x * -1) + 1), Mathf.Round(this.transform.position.y), Mathf.Round(this.transform.position.z));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            _audioSource.Play();
            particulas.Play();
        } else if (other.tag == "Segment")
        {
            Time.timeScale = 0f;
            AudioSource musicScene = mainCamera.GetComponent<AudioSource>();
            musicScene.Stop();
            AudioSource audioGameOver = gameOver.GetComponent<AudioSource>();
            gameOver.SetActive(true);
            totalPuntosGameOver.text = Puntaje.GetPuntos();
            audioGameOver.Play();
        } else if (other.tag == "ObstacleVertical")
        {
            OutOfBoundsVertical();
        } else if (other.tag == "ObstacleHorizontal")
        {
            OutOfBoundsHorizontal();
        }
    }
    
    public void buttonLeft()
    {
        _direction = Rotate(_direction, 90);
    }

    public void buttonRight()
    {
        _direction = Rotate(_direction, -90);
    }
    
    public static int getMaxFrutasComidas()
    {
        return _maxFrutasComidas;
    }

    public static void updateMaxFrutasComidas()
    {
        _maxFrutasComidas *= 2;
    }

    public static int getFrutasComidas()
    {
        return _frutasComidas;
    }

    public static void incrementFrutasComidas(int num)
    {
        _frutasComidas += num;
    }

    public static void resetFrutasComidas()
    {
        _frutasComidas = 0;
    }
}
