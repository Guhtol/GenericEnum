using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnum
{ 
        public static class GenericEnums<T> where T : struct, IConvertible
        {
            public static T RetornaEnum(string value)
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            public static T RetornaEnum(int? value)
            {
                return (T)Enum.Parse(typeof(T), value.GetValueOrDefault().ToString());
            }
            public static T RetornaEnum(int value)
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            public static int RetornaValor(T value)
            {
                return Convert.ToInt32(value);
            }
            public static string RetornaTexto(T value)
            {
                return Enum.GetName(typeof(T), value);
            }
            public static string RetornaDescricaoEnum(T value)
            {
                var field = value.GetType().GetField(value.ToString());
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            public static GenericObjEnum<T> RetornaObjeto(string value)
            {
                return (GenericObjEnum<T>)(T)Enum.Parse(typeof(T), value);
            }
            public static GenericObjEnum<T> RetornaObjeto(int value)
            {
                return (GenericObjEnum<T>)(T)Enum.Parse(typeof(T), value.ToString());
            }
            public static GenericObjEnum<T> RetornaObjeto(int? value)
            {
                return (GenericObjEnum<T>)(T)Enum.Parse(typeof(T), value.GetValueOrDefault().ToString());
            }
            public static List<T> RetornaListaEnum()
            {
                var result = new List<T>();

                result.AddRange(Enum.GetValues(typeof(T)).Cast<T>());

                return result;
            }
            public static List<GenericObjEnum<T>> ListaObjeto()
            {

                var lista = RetornaListaEnum();

                var result = lista.Select(t => (GenericObjEnum<T>)t);

                return result.ToList();
            }


        }

}
