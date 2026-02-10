using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea_1
{
    public enum StatusStudent
    {
        Inactive,
        Active,
        Graduate,
        Suspended
    }
    public class Student : Communitymembers
    {
        public int studentenrollment { get; set; }
        public  StatusStudent status { get; set; }

        public bool Activo()
        {
            return status == StatusStudent.Active;
    } }
}
