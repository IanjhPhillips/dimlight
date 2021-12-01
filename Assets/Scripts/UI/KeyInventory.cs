using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInventory : MonoBehaviour
{
    [SerializeField] Text redCountText;
    [SerializeField] Image redSprite;
    [SerializeField] Text greenCountText;
    [SerializeField] Image greenSprite;
    [SerializeField] Text orangeCountText;
    [SerializeField] Image orangeSprite;
    [SerializeField] Text blueCountText;
    [SerializeField] Image blueSprite;

    public static KeyInventory keyInventory;

    private void Awake()
    {
        keyInventory = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInventoryIcons(List<Key.KeyColor> keys)
    {
        int redCount = 0;
        int blueCount = 0;
        int greenCount = 0;
        int orangeCount = 0;

        Color red = new Color(redSprite.color.r, redSprite.color.g, redSprite.color.b, 1f);
        Color redFaded = new Color(redSprite.color.r, redSprite.color.g, redSprite.color.b, 0.25f);

        Color blue = new Color(blueSprite.color.r, blueSprite.color.g, blueSprite.color.b, 1f);
        Color blueFaded = new Color(blueSprite.color.r, blueSprite.color.g, blueSprite.color.b, 0.25f);

        Color green = new Color(greenSprite.color.r, greenSprite.color.g, greenSprite.color.b, 1f);
        Color greenFaded = new Color(greenSprite.color.r, greenSprite.color.g, greenSprite.color.b, 0.25f);

        Color orange = new Color(orangeSprite.color.r, orangeSprite.color.g, orangeSprite.color.b, 1f);
        Color orangeFaded = new Color(orangeSprite.color.r, orangeSprite.color.g, orangeSprite.color.b, 0.25f);

        foreach (Key.KeyColor kc in keys)
        {
            switch(kc)
            {
                case Key.KeyColor.red:
                    redCount++;
                    break;
                case Key.KeyColor.blue:
                    blueCount++;
                    break;
                case Key.KeyColor.green:
                    greenCount++;
                    break;
                case Key.KeyColor.orange:
                    orangeCount++;
                    break;
                default:
                    break;

            }
        }

        redCountText.text = "" + redCount;
        redCountText.color = redCount > 0 ? Color.white : Color.grey;
        redSprite.color = redCount > 0 ? red : redFaded;

        blueCountText.text = "" + blueCount;
        blueCountText.color = blueCount > 0 ? Color.white : Color.grey;
        blueSprite.color = blueCount > 0 ? blue : blueFaded;

        greenCountText.text = "" + greenCount;
        greenCountText.color = greenCount > 0 ? Color.white : Color.grey;
        greenSprite.color = greenCount > 0 ? green : greenFaded;

        orangeCountText.text = "" + orangeCount;
        orangeCountText.color = orangeCount > 0 ? Color.white : Color.grey;
        orangeSprite.color = orangeCount > 0 ? orange : orangeFaded;


    }


}
