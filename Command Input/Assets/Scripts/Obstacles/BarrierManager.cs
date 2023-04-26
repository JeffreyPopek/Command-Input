using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour
{
    //public static BarrierManager Instance { get; private set; }
    [SerializeField] private Switches[] redSwitchList;
    
    [SerializeField] private Switches[] blueSwitchList;

    private LayerMask wallLayer = 3;
    private LayerMask notWallLayer = 7;
    // private int wallLayer = LayerMask.NameToLayer("Default");
    // private int notWallLayer = LayerMask.NameToLayer("Wall");
    

    private void Update()
    {
        SwitchWallsLogic();
    }

    public void SwitchWallsLogic()
    {
        switch (Player.Instance.redBarriersActive)
        {
            case true:
            {
                foreach (Switches element in redSwitchList)
                {
                    element.gameObject.layer = notWallLayer;
                }
            
                foreach (Switches element in blueSwitchList)
                {
                    element.gameObject.layer = wallLayer;
                }

                break;
            }
            case false:
            {
                foreach (Switches element in redSwitchList)
                {
                    element.gameObject.layer = wallLayer;
                }
            
                foreach (Switches element in blueSwitchList)
                {
                    element.gameObject.layer = notWallLayer;
                }

                break;
            }
        }
    }
}
