using UnityEngine;
using Autofac;

public class Bootstrapper : MonoBehaviour {

    void Awake()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<MenuManager>().As<IMenuManager>().SingleInstance();
        DependencyResolver.Container = builder.Build();
    }
}