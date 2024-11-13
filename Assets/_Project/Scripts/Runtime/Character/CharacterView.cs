using Unity.VisualScripting;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    protected CharacterModel _model;

    public virtual void Initialize(CharacterModel model)
    {
        _model = model;
    }
}
