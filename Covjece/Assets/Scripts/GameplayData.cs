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
    public GameObject[] PlayerClone;  

    public void SettingInspectorValues()
    {
        var AllPlayerClones=new GameObject();
        AllPlayerClones.name = "AllPlayerClones";
        AllPlayerClones.transform.parent = GameObject.Find("MainRootClones").transform;

        for (int i = 0; i < _size; i++)
        {
            PlayerClone[i] = GameObject.Instantiate(_characterPrefabObject[i]);
            _characterPrefabObject[i].name = _name[i];
            PlayerClone[i].transform.parent = GameObject.Find("AllPlayerClones").transform;
            PlayerClone[i].transform.localPosition = _characterStartingPosition[i];
            PlayerClone[i].transform.rotation = Quaternion.Euler(_characterStartingRotation[i]);
        }
    }

    private void Start()
    {
        SettingInspectorValues();
    }
}
