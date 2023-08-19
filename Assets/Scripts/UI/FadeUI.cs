using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeUI : MonoBehaviour
{
    public GameObject[] elements;
    public Action DeathScreenTrigger;

    private bool canFade = true;
    [SerializeField] private bool startTransparent;
    // Start is called before the first frame update
    void Start()
    {
        if(startTransparent)
        {
            for (int j = 0; j < elements.Length; j++)
            {
                elements[j].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                elements[j].SetActive(false);
            }
        }
        
    }
    private void OnEnable()
    {
        DeathScreenTrigger += FadeScreen;
    }
    private void OnDisable()
    {
        DeathScreenTrigger -= FadeScreen;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void FadeScreen()
    {
        if (canFade)
        {
            for (int j = 0; j < elements.Length; j++)
            {
                elements[j].SetActive(true);
            }
            StartCoroutine(Fade());
            canFade = false;
        }
    }
    IEnumerator Fade()
    {
        for (float i = 0; i <= 255; i += Time.deltaTime)
        {
            // set color with i as alpha
            for (int j = 0; j < elements.Length; j++)
            {
                elements[j].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }

            

        }
        
    }


}
