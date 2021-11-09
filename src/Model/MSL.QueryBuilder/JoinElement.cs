using System;
using System.Collections.Generic;

namespace MSL.QueryBuilder
{
    public class JoinElement
    {
        ICollection<JoinElement> children;

        public JoinElement(string fieldName,TField referenceField,TEntity refenrenceEntity)
        {
            FieldName = fieldName;
            ReferenceField = referenceField;
            ReferenceEntity = refenrenceEntity;
            children = new List<JoinElement>();
        }

        public string FieldName { get; set; }
        public TField ReferenceField { get; set; }
        public TEntity ReferenceEntity { get; set; }
        public JoinElement Parent { get; set; }
        public IEnumerable<JoinElement> Children => children;
        public void AddChild(JoinElement childElement)
        {
            this.children.Add(childElement);

            childElement.Parent = this;
        }

        public JoinElement AddChild(string fieldName,TField referenceField, TEntity refenrenceEntity)
        {
            var element = new JoinElement(fieldName,referenceField, refenrenceEntity);
            AddChild(element);
            return element;
        }

        public JoinElement FindChildElement(string fieldName)
        {
            foreach (var child in Children)
            {
                if (child.FieldName == fieldName)
                    return child;
            }

            return null;
        }
    }

}
