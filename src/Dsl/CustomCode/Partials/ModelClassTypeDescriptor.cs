﻿using System;
using System.ComponentModel;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Design;

namespace Sawczyn.EFDesigner.EFModel
{
   public partial class ModelClassTypeDescriptor
   {
      private DomainDataDirectory storeDomainDataDirectory;

      /// <summary>
      ///    Returns the property descriptors for the described ModelClass domain class, adding tracking property
      ///    descriptor(s).
      /// </summary>
      private PropertyDescriptorCollection GetCustomProperties(Attribute[] attributes)
      {
         // Get the default property descriptors from the base class  
         PropertyDescriptorCollection propertyDescriptors = base.GetProperties(attributes);

         // Get a reference to the model element that is being described.  
         ModelClass modelClass = ModelElement as ModelClass;

         //Add the descriptor for the tracking property.  
         if (modelClass != null)
         {
            storeDomainDataDirectory = modelClass.Store.DomainDataDirectory;

            /********************************************************************************/

            DomainPropertyInfo databaseSchemaPropertyInfo = storeDomainDataDirectory.GetDomainProperty(ModelClass.DatabaseSchemaDomainPropertyId);
            DomainPropertyInfo isDatabaseSchemaTrackingPropertyInfo = storeDomainDataDirectory.GetDomainProperty(ModelClass.IsDatabaseSchemaTrackingDomainPropertyId);

            // Define attributes for the tracking property/properties so that the Properties window displays them correctly.  
            Attribute[] databaseSchemaAttributes =
            {
               new DisplayNameAttribute("Database Schema"),
               new DescriptionAttribute("The schema to use for table creation. Overrides default schema for model if present."),
               new CategoryAttribute("Database")
            };

            propertyDescriptors.Add(new TrackingPropertyDescriptor(modelClass, databaseSchemaPropertyInfo, isDatabaseSchemaTrackingPropertyInfo, databaseSchemaAttributes));

            /********************************************************************************/

            DomainPropertyInfo namespacePropertyInfo = storeDomainDataDirectory.GetDomainProperty(ModelClass.NamespaceDomainPropertyId);
            DomainPropertyInfo isNamespaceTrackingPropertyInfo = storeDomainDataDirectory.GetDomainProperty(ModelClass.IsNamespaceTrackingDomainPropertyId);

            // Define attributes for the tracking property/properties so that the Properties window displays them correctly.  
            Attribute[] namespaceAttributes =
            {
               new DisplayNameAttribute("Namespace"),
               new DescriptionAttribute("Overrides default namespace"),
               new CategoryAttribute("Code Generation")
            };

            propertyDescriptors.Add(new TrackingPropertyDescriptor(modelClass, namespacePropertyInfo, isNamespaceTrackingPropertyInfo, namespaceAttributes));
         }

         // Return the property descriptors for this element  
         return propertyDescriptors;
      }
   }
}
