using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 泛型单例类，约束MonoBehaviour必须是Singleton类型
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    // Instance定义，外部访问接口
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }
    // 只允许继承类可访问，虚函数方便重写，对instance初始化，若已经存在instance则销毁（销毁重复对象），否则返回单例对象
    protected virtual void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = (T)this;
        }
    }
    // 判断是否存在可访问的单例对象
    public static bool IsInitialized
    {
        get { return instance != null; }
    }
    // 销毁方法，当被调用时则判断是否存在单例对象，若存在则置空
    protected virtual void OnDestory()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
