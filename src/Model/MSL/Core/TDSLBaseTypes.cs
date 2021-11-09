namespace MSL
{
    public enum TDSLBaseTypes
    {
        @Entity,
        @Query,
        @Guid,
        @Text,//length
        @Number,//precision,scale
        @Integer,//storage
        @DateTime,
        @Bool,
        @Option, // option
        @Reference, //reference_entity
        @Collection, //collection_entity
        @Binary,
        @Custom
    }

    /*
@Guid = 1,
@Text = 2,
@Number = 3,
@DateTime = 4,
@Bool = 5,
@Option = 6,
@Reference = 7,
@Collection = 8,     
@Binary  
     */

}
