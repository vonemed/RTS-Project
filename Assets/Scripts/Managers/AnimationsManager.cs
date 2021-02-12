using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController sprint;
    public RuntimeAnimatorController gather;
    public RuntimeAnimatorController attack;

    Animator animationController;
    public int currentId;

    void Start()
    {
        animationController = GetComponent<Animator>();
        currentId = 1;
    }

    public void setAnimation(int _id)
    {
        currentId = _id;
        if(_id == 1)
        {
            //idle
            animationController.runtimeAnimatorController = idle;
        }

        if(_id == 2)
        {
            //sprint
            animationController.runtimeAnimatorController = sprint;
        }

        if(_id == 3)
        {
            //gather
            animationController.runtimeAnimatorController = gather;
        }
        
        if(_id == 4)
        {
            //attack
            animationController.runtimeAnimatorController = attack;
        }
    }

    public int getAnimation()
    {
        return currentId;
    }
    
}
