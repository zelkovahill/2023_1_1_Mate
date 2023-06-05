using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnType : MonoBehaviour
{
public BTNType currentType;

    public void OnBtnClick()
    {
    switch(currentType)
    {
    case BTNType.New:
    Debug.Log("새게임");
    
    break;
    
        case BTNType.Continue:
            Debug.Log("이어하기");
        break;
}
}
}
