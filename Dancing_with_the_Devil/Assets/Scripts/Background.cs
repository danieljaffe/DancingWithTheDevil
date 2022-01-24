using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] backgrounds;

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

    [YarnCommand("background")]
    public void change(int num)
    {
        image.sprite = backgrounds[num];
    }
}
