
namespace CDOM
{

    public class TDataType
    {

        public TDataType(DataTypes type)
        {
            this.Type = type;
        }

        public TDataType(DataTypes type,bool isNullable)
        {
            this.Type = type;
            this.IsNullable = isNullable;
        }


        public DataTypes Type { get;  set; }
        public bool IsNullable { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as TDataType;

            if (other == null)
                return false;

            return other.Type == Type
                && other.IsNullable == IsNullable;
        }

    }
    public class TDataType<T> : TDataType where T : class
    {
        public TDataType(DataTypes type): base(type)
        {
        }
    }

}
