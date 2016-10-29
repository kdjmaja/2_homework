using System;

namespace Zad_1
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException() : base("Item with same ID already in base.")
        {
        }
    }
}
