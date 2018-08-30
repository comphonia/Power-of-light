using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour {

    public int cost;
    public int sellAmount;

    bool mouseIsOver = false; 
    bool isSelected = false;

    protected virtual void Update()
    {
        if(isSelected && !mouseIsOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSelected = false;
                Debug.Log("is selected no more"); 
            }
        }
    }

    private void OnMouseEnter()
    {
        mouseIsOver = true; 
    }

    private void OnMouseExit()
    {
        mouseIsOver = false; 
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isSelected)
        {
            Debug.Log("selected"); 
            isSelected = true;
            return; 
        }
        else if (isSelected && Input.GetMouseButtonDown(0))
        {
            Debug.Log("handled");
            isSelected = false; 
            StartCoroutine(Move(true)); 
        }
        else if (isSelected && Input.GetMouseButtonDown(1))
        {
            Debug.Log("sell");
            Sell(); 
        }
    }

    public IEnumerator Move (bool value)
    {
        yield return new WaitForSeconds(0.2f);
        if (value) PlacementController.HandleObject(gameObject);
        yield break; 
    }

    public void Sell()
    {
        GameMaster.instance.Gold += sellAmount; 
        Destroy(gameObject);
    }
}
