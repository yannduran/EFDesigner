//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Testing
{
   public partial class BParentCollection
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected BParentCollection()
      {
         BChildCollection = new System.Collections.ObjectModel.ObservableCollection<BChild>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="_bchildrequired"></param>
      public BParentCollection(BChild _bchildrequired)
      {
         if (_bchildrequired == null) throw new ArgumentNullException(nameof(_bchildrequired));
         BChildRequired = _bchildrequired;

         BChildCollection = new ObservableCollection<BChild>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="_bchildrequired"></param>
      public static BParentCollection Create(BChild _bchildrequired)
      {
         return new BParentCollection(_bchildrequired);
      }

      // Persistent properties

      /// <summary>
      /// Identity, Required, Indexed
      /// </summary>
      public int Id { get; set; }

      // Persistent navigation properties

      /// <summary>
      ///  // Required
      /// </summary>
      public virtual BChild BChildRequired { get; set; }  // Required
      public virtual ICollection<BChild> BChildCollection { get; set; } 
      public virtual BChild BChildOptional { get; set; } 
   }
}

