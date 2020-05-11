using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayData : MonoBehaviour
{
    public int _playerClonesSize;
    public int _pathNodesSize;

    [SerializeField] private string[] _name;
    [SerializeField] private GameObject[] _playerCharacterPrefabObject;
    [SerializeField] private GameObject[] _nodesCharacterPrefabObject;
    [SerializeField] private Vector3[] _characterStartingPosition;
    [SerializeField] private Vector3[] _characterStartingRotation;
    [SerializeField] private Vector3[] _nodeStartingPosition;
    [SerializeField] private Vector3[] _nodeStartingRotation;
    public GameObject[] PlayerClone;
    public GameObject[] PathNodes;
    public Vector3[] charStartPos;

    public void SettingInspectorValues()
    {
        var AllPlayerClones=new GameObject();
        AllPlayerClones.name = "AllPlayerClones";
        AllPlayerClones.transform.parent = GameObject.Find("MainRootClones").transform;

        var AllPathNodes = new GameObject();
        AllPathNodes.name = "AllPathNodes";
        AllPathNodes.transform.parent = GameObject.Find("MainRootClones").transform;


        for (int i=0 ; i < _playerClonesSize; i++)
        {
            _playerCharacterPrefabObject[i].name = _name[i];
            PlayerClone[i] = GameObject.Instantiate(_playerCharacterPrefabObject[i]);
            PlayerClone[i].transform.parent = GameObject.Find("AllPlayerClones").transform;
            PlayerClone[i].transform.localPosition = _characterStartingPosition[i];
            PlayerClone[i].transform.rotation = Quaternion.Euler(_characterStartingRotation[i]);
            charStartPos[i] = PlayerClone[i].transform.localPosition;
        }

        for (int i = 0; i < _pathNodesSize; i++)
        {
            //Debug.Log(i);
            _nodesCharacterPrefabObject[i].name = i.ToString();
            PathNodes[i] = GameObject.Instantiate(_nodesCharacterPrefabObject[i]);
            PathNodes[i].transform.parent = GameObject.Find("AllPathNodes").transform;
            PathNodes[i].transform.localPosition = _nodeStartingPosition[i];
            PathNodes[i].transform.rotation = Quaternion.Euler(_nodeStartingRotation[i]);
        }
    }

    private void Start()
    {
        SettingInspectorValues();
    }
}
