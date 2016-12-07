using Autofac;
public class DependencyResolver{
    public static IContainer Container { get; set; }
    public static object Resolve { get; internal set; }

}