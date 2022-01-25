using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHead : MonoBehaviour
{
    [SerializeField] private Sprite[] s;
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleSprite(float health)
    {
        if (health > 66)
        {
            image.sprite = s[2];
        }else if (health > 33)
        {
            image.sprite = s[1];
        }else
        {
            image.sprite = s[0];
        }
    }
}
