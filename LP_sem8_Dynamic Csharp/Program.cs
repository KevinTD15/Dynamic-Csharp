using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Reflection;

namespace LP_sem8_Dynamic_Csharp
{
    #region Factory para Ejercicio 1 y 2
    public static class Factory
    {
        public static CreatePerson New => new CreatePerson();
    }
    public class CreatePerson
    {
        public Person Person => new Person();
    }
    #endregion
    #region Ejercicio 1
    public class Person
    {
        public string FirstName;
        public string LastName;

        public Person() { }

        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public string this[string attribute]
        {
            get
            {
                switch (attribute)
                {
                    case "FirstName":
                        return this.FirstName;
                    case "LastName":
                        return this.LastName;
                    default:
                        return string.Empty;
                }
            }
            set
            {
                if (attribute == "FirstName")
                    this.FirstName = value;
                if (attribute == "LastName")
                    this.LastName = value;
            }
        }
    }
    static public class FluentInterfacePerson
    {
        public static Person FirstName(this Person person, string fName)
        {
            person.FirstName = fName;
            return person;
        }
        public static Person LastName(this Person person, string lName)
        {
            person.LastName = lName;
            return person;
        }
    }
    //Metodo extendido de persona
    static public class FluentInterfaceCreatePerson
    {
        public static Person Person(this CreatePerson New, string FirstName, string LastName)
        {
            return new Person(FirstName, LastName);
        }
    }
    #endregion
    #region Ejercicio 2
    //public class Person: DynamicObject
    //{
    //    public string FirstName;
    //    public string LastName;

    //    Dictionary<string, object> properties = new Dictionary<string, object>();

    //    public override bool TryGetMember(GetMemberBinder binder, out object result)
    //    {
    //        return properties.TryGetValue(binder.Name, out result);
    //    }
    //    public override bool TrySetMember(SetMemberBinder binder, object value)
    //    {
    //          properties[binder.Name] = value;
    //          return true;

    //    }
    //    public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
    //    {
    //        string index = (string)indexes[0];
    //        return properties.TryGetValue(index, out result);
    //    }
    //    public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
    //    {
    //        string index = (string)indexes[0];

    //        if (properties.ContainsKey(index))
    //            properties[index] = value;
    //        else
    //            properties.Add(index, value);
    //        return true;
    //    }
    //    public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
    //    {
    //        if ((args.Length == 3) &&
    //        (args[0].GetType() == typeof(string)) &&
    //        (args[1].GetType() == typeof(string)) &&
    //        (args[2].GetType() == typeof(Person)))
    //        {
    //            //If the property already exists,
    //            // its value is changed.
    //            // Otherwise, a new property is created.
    //            if (properties.ContainsKey("FirstName"))
    //                properties["FirstName"] = args[0];
    //            else
    //                properties.Add("FirstName", args[0]);

    //            if (properties.ContainsKey("LastName"))
    //                properties["LastName"] = args[1];
    //            else
    //                properties.Add("LastName", args[1]);

    //            if (properties.ContainsKey("Manager"))
    //                properties["Manager"] = args[2];
    //            else
    //                properties.Add("Manager", args[2]);

    //            result = true;
    //            return true;
    //        }
    //        else
    //        {
    //            // If the number of arguments is wrong,
    //            // or if arguments are of the wrong type,
    //            // the method returns false.
    //            result = false;
    //            return false;
    //        }
    //    }
    //    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    //    {
    //        Type dictType = typeof(Dictionary<string, object>);
    //        try
    //        {
    //            result = dictType.InvokeMember(
    //                         binder.Name,
    //                         BindingFlags.InvokeMethod,
    //                         null, properties, args);
    //            return true;
    //        }
    //        catch
    //        {
    //            result = null;
    //            return false;
    //        }
    //    }
    //}
    #endregion
    #region Ejercicio 3
    //public class Factory
    //{
    //    private static InstanceCreaor creator = new InstanceCreaor();
    //    public static dynamic New => creator;
    //}
    //public class InstanceCreaor : DynamicObject
    //{
    //    public override bool TryGetMember(GetMemberBinder binder, out object result)
    //    {
    //        var myClassType = Assembly.GetExecutingAssembly().GetTypes();
    //        foreach (var item in myClassType)
    //        {
    //            if (item.Name == binder.Name)
    //            {
    //                result = Activator.CreateInstance(item);
    //                return true;
    //            }
    //        }
    //        result = null;
    //        return false;
    //    }
    //}
    //public class Teacher
    //{
    //    string name;
    //    string subject;
    //    string salary;
    //    public string Name { get { return name; } set { name = value; } }
    //    public string Salary { get { return salary; } set { salary = value; } }
    //    public string Subject { get { return subject; } set { subject = value; } }
    //}
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region Ejercicio 1
            ////Ejercicio 1

            //var p1 = Factory.New.Person;
            //p1.FirstName = "Louis";
            //p1.LastName = "Dejardin";
            //Console.WriteLine("La persona 1 se llama: {0} {1}", p1.FirstName, p1.LastName);

            //var p2 = Factory.New.Person;
            //p2["FirstName"] = "Louis";
            //p2["LastName"] = "Dejardin";
            //Console.WriteLine("La persona 2 se llama: {0} {1}", p2.FirstName, p2.LastName);

            //var p3 = Factory.New.Person.FirstName("Louis").LastName("Dejardin");
            //Console.WriteLine("La persona 3 se llama: {0} {1}", p3.FirstName, p3.LastName);

            //var p4 = Factory.New.Person(FirstName: "Louis", LastName: "Dejardin");
            //Console.WriteLine("La persona 4 se llama: {0} {1}", p4.FirstName, p4.LastName);
            #endregion

            #region Ejercicio 2
            //Ejercicio 2

            //var person = Factory.New.Person(
            //    FirstName: "Louis",
            //    LastName: "Dejardin",
            //    Manager: New.Person(
            //        FirstName: "Bertrand", 
            //        LastName: "Le Roy"));

            //var p = Factory.New.Person
            //    (
            //    FirstName: "Louis",
            //    LastName: "Dejardin",
            //    Manager: New.Person(
            //        FirstName: "asd",
            //        LastName: "dsa"));

            //p(FirstName:"Louis", LastName:"Dejardin", Manager:d);
            //Console.WriteLine(p["FirstName"]);

            #endregion

            #region Ejercicio 3
            //Ejercicio 3

            //var p5 = Factory.New.Teacher;
            //p5.Name = "Robert";
            //p5.Subject = "Qhemistry";
            //p5.Salary = "3500";


            //Console.WriteLine("Tipo: {3} \n Nombre: {0} \n Asignatura: {1} \n Salario: {2}", p5.Name, p5.Subject, p5.Salary, p5.GetType());
            #endregion
        }
    }
}
