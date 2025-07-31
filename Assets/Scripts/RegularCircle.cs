using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class RegularCircle : BaseCircle //INHERITANCE
{
    [SerializeField] private Image image;
    private int colorCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorCount = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void RandomizeColor()
    {
        int i = Random.Range(1, 3);
    }

    public override void SetColor(Color color)
    {
        this.image.color = color;
    }

    public void CycleColors()
    {
        switch (colorCount)
        {
            case 1:
                image.color = Color.red;
                break;
            case 2:
                image.color = Color.yellow;
                break;
            case 3:
                image.color = Color.green;
                break;
            default:
                break;
        }
        colorCount++;
        if (colorCount > 3)
        {
            colorCount = 0;
        }
    }
}
