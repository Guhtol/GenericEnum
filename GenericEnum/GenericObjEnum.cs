using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEnum
{
    public class GenericObjEnum<T> where T : struct, IConvertible
    {
        public string Descricao { get; private set; }
        public string Text { get; private set; }
        public int Value { get; private set; }
        public T ElementEnum { get; private set; }

        public static explicit operator GenericObjEnum<T>(T model)
        {

            var result = new GenericObjEnum<T>();

            result.Descricao = GenericEnums<T>.RetornaDescricaoEnum(model);
            result.ElementEnum = GenericEnums<T>.RetornaEnum(model.ToString());
            result.Value = GenericEnums<T>.RetornaValor(model);
            result.Text = GenericEnums<T>.RetornaTexto(model);

            return result;
        }
    }
}
