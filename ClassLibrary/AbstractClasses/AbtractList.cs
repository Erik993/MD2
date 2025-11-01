using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Library;
using System.Text.Json;
using ClassLibrary.Models;

namespace AbstractClasses;


// Generics <T> allows to works with Employees, ITSupports, Tickets and Assignments
public abstract class AbstractList<T>
{
    public List<T> Items { get; set; } = new List<T>();

    public void Add(T item) => Items.Add(item);
    public List<T> GetAll() => Items;

    /*
    public virtual void Print()
    {
        //WriteLine("Printing all the elements");
        WriteLine($"{typeof(T).Name} Collection has {Items.Count} items.");
        for (int i = 0; i < Items.Count; i++)
        {
            WriteLine($"{i + 1} {Items[i]}");
        }
        WriteLine("-------------------------------------");
    }*/

    public void Reset()
    {
        Items.Clear();
        //WriteLine("Data has been deleted");
    }
}
