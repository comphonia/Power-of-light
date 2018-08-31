using UnityEngine.UI; 
using UnityEngine;

public class ConstructionPanel : MonoBehaviour {

    [SerializeField] Button spotlightButton;
    [SerializeField] int spotlightCost; 
    [SerializeField] Button mirrorButton;
    [SerializeField] int mirrorCost;
    [SerializeField] Button generatorButton;
    [SerializeField] int generatorCost;

    PlacementController pc;

    private void Awake()
    {
        pc = GetComponent<PlacementController>(); 

        spotlightButton.onClick.AddListener(delegate { BuildSpotlight(); });
        mirrorButton.onClick.AddListener(delegate { BuildMirror(); });
        generatorButton.onClick.AddListener(delegate { BUildGenerator(); });
    }

    void BuildSpotlight()
    {
        if (spotlightCost <= GameMaster.instance.Gold)
        {
            pc.HandleNewObject(0);
        }
        else Debug.Log("It costs too much!"); 
    }

    void BuildMirror()
    {
        if (mirrorCost <= GameMaster.instance.Gold)
        {
            pc.HandleNewObject(1);
        }
        else Debug.Log("It costs too much!");
    }

    void BUildGenerator()
    {
        if (generatorCost <= GameMaster.instance.Gold)
        {
            pc.HandleNewObject(2);
        }
        else Debug.Log("It costs too much!");
    }

}
