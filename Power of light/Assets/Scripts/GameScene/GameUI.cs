using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject sideBar;
    [SerializeField] GameObject onscreenAnchor;
    [SerializeField] GameObject offscreenAnchor;
    [SerializeField] GameObject btnOnscreenAnchor;
    [SerializeField] GameObject btnOffscreenAnchor;
    [SerializeField] Sprite[] arrow;
    float t = 0;
    [SerializeField] float sidebarspeed;

    bool hide = false;
    public void HideBar()
    {
        hide = !hide;
        if (hide == true)
        {
            StartCoroutine(LerpOff());
        }
        else
        {
            StartCoroutine(LerpOn());
        }

    }

    IEnumerator LerpOff()
    {
        while (true)
        {
            // animate the position of the game object...
            sideBar.transform.position = Vector2.Lerp(sideBar.transform.position, offscreenAnchor.transform.position, t);
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, btnOffscreenAnchor.transform.position, t);

            // .. and increase the t interpolater
            t += sidebarspeed * Time.deltaTime;
            if (t > sidebarspeed)
            {
                gameObject.GetComponent<Image>().sprite = arrow[0];
                t = 0;
                break;
            }
            yield return null;
        }


    }

    IEnumerator LerpOn()
    {
        while (true)
        {
            // animate the position of the game object...
            sideBar.transform.position = Vector2.Lerp(sideBar.transform.position, onscreenAnchor.transform.position, t);
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, btnOnscreenAnchor.transform.position, t);

            // .. and increase the t interpolater
            t += sidebarspeed * Time.deltaTime;
            if (t > sidebarspeed)
            {
                gameObject.GetComponent<Image>().sprite = arrow[1];
                t = 0;
                break;
            }
            yield return null;
        }


    }
}

