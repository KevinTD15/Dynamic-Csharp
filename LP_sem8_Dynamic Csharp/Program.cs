using System;
using System.Dynamic;
using System.Collections.Generic;

namespace LP_sem8_Dynamic_Csharp
{
    public static class Factory
    {
        public static CreatePerson New { get { return new CreatePerson(); } }
    }
    public class CreatePerson
    {
        public Person Person { get { return new Person(); } }
    }
    #region Ejercicio 1
    //public class Person
    //{
    //    public string FirstName;
    //    public string LastName;

    //    public Person() { }

    //    public Person(string FirstName, string LastName)
    //    {
    //        this.FirstName = FirstName;
    //        this.LastName = LastName;
    //    }
    //    public string this[string attribute]
    //    {
    //        get
    //        {
    //            switch (attribute)
    //            {
    //                case "FirstName":
    //                    return this.FirstName;
    //                case "LastName":
    //                    return this.LastName;
    //                default:
    //                    return string.Empty;
    //            }
    //        }
    //        set
    //        {
    //            if(attribute == "FirstName")
    //                this.FirstName = value;
    //            if (attribute == "LastName")
    //                this.LastName = value;                       
    //        }
    //    }
    //}
    //static public class FluentInterfacePerson
    //{
    //    public static Person FirstName(this Person person, string fName)
    //    {
    //        person.FirstName = fName;
    //        return person;
    //    }
    //    public static Person LastName(this Person person, string lName)
    //    {
    //        person.LastName = lName;
    //        return person;
    //    }
    //} //Metodo extendido de persona
    //static public class FluentInterfaceCreatePerson
    //{
    //    public static Person Person(this CreatePerson New, string FirstName, string LastName)
    //    {
    //        return new Person(FirstName, LastName);
    //    }
    //}
    #endregion
    class Person: DynamicObject
    {
        public string FirstName;
        public string LastName;
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var Name = binder.Name;
            if (properties.ContainsKey(Name))
            {
                result = properties[Name];
                return true;
            }
            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!TryGetMember(binder, out value))
            {
                properties[binder.Name] = value;
                return true;
            }
           
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            return base.TryGetIndex(binder, indexes, out result);
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            return base.TrySetIndex(binder, indexes, value);
        }
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
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

            //var p1 = Factory.New.Person(FirstName: "Louis");

        }
    }
}
