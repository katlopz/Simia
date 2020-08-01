using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class OpeningExposition : MonoBehaviour
{
    Text scroll;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        scroll = GetComponentInChildren<Text>();
        y = -600;
    }

    // Update is called once per frame
    void Update()
    {
        if (y < 825)
        {
            scroll.transform.position = new Vector2(transform.position.x, y);
            y += 0.3f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}
