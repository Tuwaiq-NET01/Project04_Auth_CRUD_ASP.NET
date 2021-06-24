using System;
using System.Reflection;

namespace TuwaiqCVMaker.Services
{
    public static class ModelShallowCloner
    {
        public static void Copy(this Object obj1, int startPropertyIndex, object obj2)
        {
            var type = obj1.GetType();
            var toClone = obj2.GetType();

            var fields = type.GetProperties();
            var fieldsToClone = toClone.GetProperties();

            for (int i = startPropertyIndex; i < fields.Length; i++)
                fields[i].SetValue(obj1, fieldsToClone[i].GetValue(obj2));
        }
    }
}