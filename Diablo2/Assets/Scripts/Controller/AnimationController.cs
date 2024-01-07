
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController ins;

    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
