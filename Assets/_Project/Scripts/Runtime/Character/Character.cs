using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UIElements.Experimental;
using R3;

public abstract class Character : MonoBehaviour
{
    protected CharacterModel _model;
    protected CharacterView _view;

    public virtual void Construct(CharacterModel model, CharacterView view)
    {
        _model = model;
        _view = view;
    }

    /*     public virtual void ApplyDamage(float damage)
        {
            //_model.Stats[StatID.CURRENT_HEALTH].BaseValue.Value -= damage;
            Debug.Log($"Player - damage: {damage}");
        } */
=======

public class Character : MonoBehaviour
{

>>>>>>> Stashed changes
}
