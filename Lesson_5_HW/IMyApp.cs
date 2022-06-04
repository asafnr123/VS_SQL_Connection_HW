using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_HW
{
    internal interface IMyApp
    {
        void PrintMenu();
        void CreateEntity();
        void GetEntityDetails();
        void UpdateEntityDetails();
        void DeleteEntity();
        void PrintAllEntities();
        string GetUserOption();
        string GetUserEntity();
        int GetElementId();



    }
}
