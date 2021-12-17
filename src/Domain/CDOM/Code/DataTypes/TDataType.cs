
namespace CDOM
{

    public abstract class TDataType:Code
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
    public abstract class TDataType<T> : TDataType where T : class
    {
        public TDataType(DataTypes type): base(type)
        {
        }
    }

}
