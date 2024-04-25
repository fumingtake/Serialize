using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serialize
{
    public enum EnumA
    {
        [Remark(1.1)]
        a,
        [Remark(1.2)]
        b,
    }
    public class Class4
    {
        public Class4() { }
        public int Age { get; set; }
        public SerializableDictionary<string, string> Record { get; set; }
        public SerializableDictionary<EnumA, double> Record2 { get; set; } = new SerializableDictionary<EnumA, double>
        { { EnumA.b, 5.5 }, {EnumA.a, 4.4 } };
    }
    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(double remark)
        {
            this._Remark = remark;
        }

        private double _Remark;

        public double GetRemark(Enum value)
        {
            //反射、リフレクションを利用。ネットで調べてください
            //valueのタイプを取得
            Type type = value.GetType();
            //フィールドを取得
            FieldInfo field = type.GetField(value.ToString());
            //フィールドにRemarkAttributeが定義されていれば
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute =
                    (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute._Remark;
            }
            else
            {
                return 1;
            }
        }
    }
}
