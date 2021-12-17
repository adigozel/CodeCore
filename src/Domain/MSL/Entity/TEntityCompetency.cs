using System;
using System.Collections.Generic;

namespace MSL
{
    public class TEntityCompetency
    {
        public TEntityCompetency()
        {

        }
        public TEntityCompetency(string name,bool isDefault)
        {
            this.Name = name;
            this.IsDefault = isDefault;
        }

        public TEntityCompetency( string name, string repositoryName, string descriptionField, bool isDefault ) {
            Name = name;
            RepositoryName = repositoryName;
            DescriptionField = descriptionField;
            IsDefault = isDefault;
        }

        public string Name { get; set; }
        public string RepositoryName { get; set; }
        public string DescriptionField { get; set; }
        public bool IsDefault { get; set; }
    }
}
