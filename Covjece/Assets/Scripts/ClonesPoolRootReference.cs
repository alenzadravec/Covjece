using UnityEngine;
[CreateAssetMenu(fileName = "ClonesPoolRootReference(Camera)", menuName = "Covjece/Scriptable references/Clones pool root reference variable")]
public class ClonesPoolRootReference : ScriptableReference
{
    
    [SerializeField] ClonesPoolType _clonesPoolType;
    [SerializeField] Transform _clonesRootTR;


    public Transform ClonesRootTR
    {
        get
        {
            return _clonesRootTR;
        }
    }
    public ClonesPoolType ClonesPoolType
    {
        get
        {
            return _clonesPoolType;
        }
    }

    public void SetClonesRoot(Transform p_transform)
    {
        _clonesRootTR = p_transform;
    }

    public void SetClonesPoolType(ClonesPoolType p_poolType)
    {
        _clonesPoolType = p_poolType;
    }
}
