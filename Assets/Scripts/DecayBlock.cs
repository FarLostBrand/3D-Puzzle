using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DecayBlock : MonoBehaviour
{
    public float decayTime = 3;
    public float ColorChangeTime = 1.5f;
    [SerializeField] Color decayOutsideColor;
    [SerializeField] Color decayInsideColor;

    private bool isDecaying = false;
    private Renderer rend;

    void Start()
    {
        rend = transform.GetChild(0).GetComponent<Renderer>();
    }

    void Update()
    {
        if(isDecaying)
        {
            if(decayTime > 0)
            {
                decayTime -= Time.deltaTime;

                if (decayTime <= ColorChangeTime)
                {
                    rend.materials[0].color = decayOutsideColor;
                    rend.materials[1].color = decayInsideColor;
                }
            }
            else
            {
                decayTime = 0;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter()
    {
        isDecaying = true;
    }
}
