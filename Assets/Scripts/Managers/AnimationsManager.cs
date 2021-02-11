using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController sprint;
    public RuntimeAnimatorController gather;
    Animator animationController;
    public int currentId;

    void Start()
    {
        animationController = GetComponent<Animator>();
        currentId = 0;
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
    }

    public int getAnimation()
    {
        return currentId;
    }
    
}
