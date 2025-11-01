using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Interfaces.Library;

internal interface IDataManager
{
    // Print all elements in the collection as text
    //void Print();

    //save the collection data to a file
    void Save();

    //load the collection data from a file
    void Load();

    //create test data
    void CreateTestData(int count);

    //delete all data
    void Reset();
}

