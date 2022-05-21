using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField]
    GameObject leaf;
    [SerializeField]
    GameObject apple;
    float randomNumber;
    private void OnEnable()
    {
         randomNumber = Random.Range(1, 100);

        if (randomNumber <= 82)
        {
            leaf.SetActive(true);
        }
        else
        {
            apple.SetActive(true);
        }

    }


}
