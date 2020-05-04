using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayData : MonoBehaviour
{
    public int _size;

    [SerializeField] private string[] _name;
    [SerializeField] private GameObject[] _characterPrefabObject;
    [SerializeField] private Vector3[] _characterStartingPosition;
    [SerializeField] private Vector3[] _characterStartingRotation;
       

    private void SettingInspectorValues()
    {
        var AllPlayerClones=new GameObject();
        AllPlayerClones.name = "AllPlayerClones";
        AllPlayerClones.transform.parent = GameObject.Find("MainRootClones").transform;

        for (int i = 0; i < _size; i++)
        {
            var PlayerClone = GameObject.Instantiate(_characterPrefabObject[i]);
            PlayerClone.transform.parent = GameObject.Find("AllPlayerClones").transform;
            PlayerClone.transform.localPosition = _characterStartingPosition[i];
            PlayerClone.transform.rotation = Quaternion.Euler(_characterStartingRotation[i]);
        }
    }

    private void Start()
    {
        SettingInspectorValues();
    }
}
