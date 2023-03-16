// See https://aka.ms/new-console-template for more information


using ClassDemoReflection;
using System.Reflection;

Person person = new Person(2,"Peter");
Console.WriteLine(person);



TryReflection(person);

void TryReflection(object obj)
{
    Type t = obj.GetType();

    Console.WriteLine("Name: " + t.FullName);
    Console.WriteLine("interface: " + t.IsInterface); 
    Console.WriteLine("Class: " + t.IsClass); 
    Console.WriteLine("Base: " + t.BaseType);

    Console.WriteLine(" === Properties ====");
    foreach(var info in t.GetProperties())
    {
        Console.WriteLine(info);
    }

    Console.WriteLine(" === Methods ====");
    foreach (var info in t.GetMethods())
    {
        Console.WriteLine(info);
    }



    Console.WriteLine(" === Call a method ====");
    var setId = t.GetMethods().First(m => m.Name == "set_Id");

    Console.WriteLine("before " + obj);

    setId.Invoke(obj, new object?[] { 7 });

    Console.WriteLine("after " + obj);

    var idprop = t.GetProperty("Id");
    Console.WriteLine($"Name {idprop.Name} and value {idprop.GetValue(obj)}");

}