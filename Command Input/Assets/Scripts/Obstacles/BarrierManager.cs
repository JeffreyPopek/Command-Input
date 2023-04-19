using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour
{
    [SerializeField] private Switches[] redSwitchList;
    
    [SerializeField] private Switches[] blueSwitchList;

    public LayerMask wallLayer;   
    public LayerMask notWallLayer;    



    private void Awake()
    {

    }

    private void Update()
    {
        if (Player.Instance.redBarriersActive == true)
        {
            foreach (Switches element in redSwitchList)
            {
                gameObject.layer = notWallLayer;
            }
            
            foreach (Switches element in blueSwitchList)
            {
                gameObject.layer = wallLayer;
            }

        }
        
        else if (Player.Instance.redBarriersActive == false)
        {
            foreach (Switches element in redSwitchList)
            {
                gameObject.layer = wallLayer;
            }
            
            foreach (Switches element in blueSwitchList)
            {
                gameObject.layer = notWallLayer;
            }
        }

    }
}
