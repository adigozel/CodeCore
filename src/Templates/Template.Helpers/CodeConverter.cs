using System;
using CDOM;
using MSL;

namespace Template.Helpers
{
    public static class CodeConverter
    {
        private static TDataType ToSimpleDataType(TDSLDataType dsltype)
        {
            TDataType dataType = null;

            if (dsltype.BaseType == TDSLBaseTypes.Binary)
            {
                dataType = new BinaryDataType();
            }
            else if (dsltype.BaseType == TDSLBaseTypes.Bool)
            {
                dataType = new BoolDataType();
            }
            else if (dsltype.BaseType == TDSLBaseTypes.Guid)
            {
                dataType = new GuidDataType();
            }
            else if (dsltype.BaseType == TDSLBaseTypes.DateTime)
            {
                dataType =  new DateTimeDataType();
            }
            else if (dsltype.BaseType == TDSLBaseTypes.Text)
            {
                dataType =  new StringDataType(Convert.ToInt32(dsltype.Parameters["length"]));
            }
            else if (dsltype.BaseType == TDSLBaseTypes.Number)
            {
                dataType =  new DecimalDataType(Convert.ToInt32(dsltype.Parameters["precision"]), Convert.ToInt32(dsltype.Parameters["scale"]));
            }
            else if (dsltype.BaseType == TDSLBaseTypes.Integer)
            {
                var storage = Convert.ToInt32(dsltype.Parameters["storage"]);

                if (storage == 16)
                {
                    dataType = new ShortDataType();
                }
                else if (storage == 32)
                {
                    dataType = new IntDataType();
                }
                else if(storage==64)
                {
                    dataType = new LongDataType();
                }
                else
                    throw new Exception("Integer storage type cannot be different from 16,32,64 ");
            }

            if (dataType != null)
            {
                dataType.IsNullable = dsltype.IsNullable;
            }

            return dataType;
        }

        public static TDataType ToEntityClassDataType(TDSLDataType dsltype)
        {
            TDataType dataType = ToSimpleDataType(dsltype);

            if (dataType == null)
            {
                //if (dsltype.BaseType == TDSLBaseTypes.Collection)
                //{
                //    var collectionEntityName = dsltype.Parameters["collection_entity"].ToString();

                //    dataType = new ClassDataType(CodeBuilder.EnurableGenericType(collectionEntityName));
                //}
                //else
                if (dsltype.BaseType == TDSLBaseTypes.Reference)
                {
                    dataType = new GuidDataType();
                }
                else if (dsltype.BaseType == TDSLBaseTypes.Option)
                {
                    dataType = new EnumDataType()
                    {
                        EnumType = dsltype.Parameters["option"].ToString()
                    };
                }
                else
                {
                    throw new Exception($"DSL doesn't suppored {dsltype.BaseType.ToString()} type!");
                }

                dataType.IsNullable = dsltype.IsNullable;
            }

            return dataType;

        }

        public static TDataType ToDTODataType(TDSLDataType dsltype)
        {
            TDataType dataType = ToSimpleDataType(dsltype);

            if (dataType == null)
            {
                //if (dsltype.BaseType == TDSLBaseTypes.Collection)
                //{
                //    var collectionEntityName = dsltype.Parameters["collection_entity"].ToString();

                //    dataType = new ClassDataType(CodeBuilder.CollectionGenericType($"{collectionEntityName}DTO"));
                //}
                //else 
                if (dsltype.BaseType == TDSLBaseTypes.Reference)
                {
                    dataType = new GuidDataType();
                }
                else if (dsltype.BaseType == TDSLBaseTypes.Option)
                {
                    dataType = new StringDataType(100);
                }
                else if (dsltype.BaseType == TDSLBaseTypes.Custom)
                {
                    dataType = new ClassDataType(dsltype.Parameters["custom_type"].ToString());
                }
                else 
                {
                    throw new Exception($"DSL doesn't suppored {dsltype.BaseType.ToString()} type!");
                }

                dataType.IsNullable = dsltype.IsNullable;
            }

            return dataType;

        }

        public static TDataType ToDAODataType(TDSLDataType dsltype)
        {
            TDataType dataType = ToSimpleDataType(dsltype);

            if (dataType == null)
            {
                if (dsltype.BaseType == TDSLBaseTypes.Reference || dsltype.BaseType == TDSLBaseTypes.Collection)
                {
                    dataType = new GuidDataType();
                }
                else if (dsltype.BaseType == TDSLBaseTypes.Option)
                {
                    dataType = new StringDataType(100);
                }
                else
                {
                    throw new Exception($"DSL doesn't suppored {dsltype.BaseType.ToString()} type!");
                }

                dataType.IsNullable = dsltype.IsNullable;
            }

            return dataType;
        }

        public static TProperty ToEntityProperty(TField entityField)
        {
            var dataType = ToEntityClassDataType(entityField.DataType);

            string propertyName = null;

            TGetAccessor getAccessor = new TGetAccessor(AccessModifier.none);
            TSetAccessor setaccessor = new TSetAccessor(AccessModifier.none);


            if (entityField.DataType.BaseType == TDSLBaseTypes.Reference)
            {
                propertyName = $"{entityField.Name}Id";
            }
            //else if (entityField.DataType.BaseType == TDSLBaseTypes.Collection)
            //{
            //    getAccessor.Content = $"return {CodeTraditions.Private_Variable_Name(entityField.Name)};";
            //    setaccessor.Content = $"{CodeTraditions.Private_Variable_Name(entityField.Name)}=value.ToList();";
            //    propertyName = entityField.Name;
            //}
            else
            {
                propertyName = entityField.Name;
            }

            var property = new TProperty(AccessModifier.@public, dataType, propertyName);

            property.GetMethod = getAccessor;

            property.SetMethod = setaccessor;

            return property;
        }

        public static TProperty ToDTOProperty(TDSLDataType dsldataType,string fieldName)
        {
            var classdataType = ToDTODataType(dsldataType);

            string propertyName = null;

            if (dsldataType.BaseType == TDSLBaseTypes.Reference)
            {
                propertyName = $"{fieldName}Id";
            }
            else
            {
                propertyName = fieldName;
            }

            return new TProperty(AccessModifier.@public, classdataType, propertyName);
        }

        public static TProperty ToQueryDAOProperty(TQueryField queryField)
        {
            var dataType = ToDAODataType(queryField.DataType);

            var name = queryField.Name;

            if (queryField.BaseType == TDSLBaseTypes.Reference)
            {
                name = $"{queryField.Name}Id";
            }
            else if (queryField.BaseType == TDSLBaseTypes.Collection)
            {
                name = $"{queryField.Name}CollectionId";
            }

            return new TProperty(AccessModifier.@public, dataType, name);
        }

        //public static TVariable ToEntityCollectionVariable(TEntityField dslField)
        //{
        //    var collectionEntityName = dslField.DataType.Parameters["collection_entity"].ToString();

        //    var variable = new TVariable
        //        (
        //            AccessModifier.@private,
        //            new ClassDataType(CodeBuilder.ListGenericType(collectionEntityName)),
        //            CodeTraditions.Private_Variable_Name(dslField.Name)
        //        );

        //    return variable;
        //}
      
       
    }
}
