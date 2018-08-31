using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeBrain : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float waitTime;

    float t = 0;
    float s = 0;

    [SerializeField] bool isAngryShade = false;

    Animator angryAnim;

    private void Start()
    {
        angryAnim = GetComponent<Animator>();
        GetTarget();
    }

    int counter = 0;
    void GetTarget()
    {
        if (isAngryShade == true)
        {
            if (counter < 3)
            {
                StartCoroutine(Brain(ShadeManager.instance.angryWaypoints[counter].transform.position));
                counter++;
            }

        }

        else StartCoroutine(Brain(ShadeManager.instance.WhereTo()));
    }

    IEnumerator Brain(Vector3 target)
    {
        if (isAngryShade == true)
        {
            while (true)
            {
                if (counter == 0) yield return new WaitForSeconds(3);

                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);

                s += moveSpeed * Time.deltaTime;
                if (s > 0.3f) { if (counter == 2) { angryAnim.Play("right-swipe"); }; }
                if (s > 0.31f) { if (counter == 2) { ShadeManager.instance.brokenGlass.SetActive(true); } }
                if (s > 0.51f) { if (counter == 2) { angryAnim.Play("hover1"); } }
                if (s >= 1)
                {
                    s = 0;
                    yield return new WaitForSeconds(waitTime);
                    //move again
                    GetTarget();
                    break;

                }
                yield return null;
            }
        }
        else
        {
            while (true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);

                t += moveSpeed * Time.deltaTime;

                //if reached
                if (t >= 1)
                {
                    t = 0;
                    yield return new WaitForSeconds(waitTime);
                    //move again
                    GetTarget();
                    break;


                }
                yield return null;
            }


        }
    }


}
