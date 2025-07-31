using UnityEngine;
using UnityEngine.UI;

public class LightDisplayManager : MonoBehaviour
{
    [SerializeField] private Image circleImg1;
    [SerializeField] private Image circleImg2;
    [SerializeField] private Image circleImg3;
    private Color color1;
    private Color color2;
    private Color color3;
    [SerializeField] private Button circleBut1;
    [SerializeField] private Button circleBut2;
    [SerializeField] private Button circleBut3;

    public static LightDisplayManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    void Start()
    {
        this.circleImg1.GetComponent<RegularCircle>().SetColor(Color.gray);
        this.circleImg2.GetComponent<RegularCircle>().SetColor(Color.gray);
        this.circleImg3.GetComponent<RegularCircle>().SetColor(Color.gray);
        setRandomizedColors();
    }


    void Update()
    {

    }

    void setRandomizedColors()
    {
        int i = Random.Range(1, 3);
        switch (i)
        {
            case 1:
                color1 = Color.red;
                break;
            case 2:
                color1 = Color.yellow;
                break;
            case 3:
                color1 = Color.green;
                break;
            default:
                break;
        }

        i = Random.Range(1, 3);
        switch (i)
        {
            case 1:
                color2 = Color.red;
                break;
            case 2:
                color2 = Color.yellow;
                break;
            case 3:
                color2 = Color.green;
                break;
            default:
                break;
        }

        i = Random.Range(1, 3);
        switch (i)
        {
            case 1:
                color3 = Color.red;
                break;
            case 2:
                color3 = Color.yellow;
                break;
            case 3:
                color3 = Color.green;
                break;
            default:
                break;
        }
    }

    //ENCAPSULATION
    public Color getColor1()
    {
        return this.color1;
    }
    public Color getColor2()
    {
        return this.color2;
    }
    public Color getColor3()
    {
        return this.color3;
    }

    public Color getColorBut1()
    {
        return this.circleBut1.image.color;
    }
    public Color getColorBut2()
    {
        return this.circleBut2.image.color;
    }
    public Color getColorBut3()
    {
        return this.circleBut3.image.color;
    }

    public void RevealColors()
    {
        circleImg1.color = color1;
        circleImg2.color = color2;
        circleImg3.color = color3;
    }
}
