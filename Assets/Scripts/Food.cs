using UnityEngine;

public class Food : MonoBehaviour
{
    private int maxFrutasComidas = 10;
    private int frutasComidas = 0;
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
            if (frutasComidas < maxFrutasComidas)
            {
                frutasComidas++;
            }
            else
            {
                GameObject newFruit = Instantiate(this.gameObject);
                frutasComidas++;
                maxFrutasComidas *= 2;
            }
        }
    }
}
