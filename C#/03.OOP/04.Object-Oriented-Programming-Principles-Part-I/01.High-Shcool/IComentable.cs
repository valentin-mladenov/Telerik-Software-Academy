using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.High_Shcool
{
    public interface IComentable
    {
        string[] Comment { get; }
        void AddComment(string comment);
    }
}