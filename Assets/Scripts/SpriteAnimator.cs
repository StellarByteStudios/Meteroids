using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]
    public Sprite[] spritesArray;
    
    public Sprite mainFrame;
    public bool animationOn;
    public bool randomSprites;
    public int currentFrame;
    public float frameRate;
    private float timer;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (randomSprites)
        {
            RandomStartSprite();
        }
    }

    private void Update()
    {
        if (animationOn)
        {
            timer += Time.deltaTime;

            if (timer >= frameRate)
            {
                timer -= frameRate;
                currentFrame = (currentFrame + 1) % spritesArray.Length;
                spriteRenderer.sprite = spritesArray[currentFrame];
            }
        }
        else
        {
            timer = frameRate - 0.0001f;
            currentFrame = 0;
            spriteRenderer.sprite = mainFrame;
        }
    }

    private void RandomStartSprite()
    {
        int spriteNum = UnityEngine.Random.Range(0, spritesArray.Length);
        mainFrame = spritesArray[spriteNum];
    }
}
