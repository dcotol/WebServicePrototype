﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WebServicePrototype.Module.BusinessObjects
{
  [DefaultClassOptions]
  //[ImageName("BO_Contact")]
  //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
  //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
  //[Persistent("DatabaseTableName")]
  // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
  public class Customer : BaseObject
  { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public Customer(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
      base.AfterConstruction();
      // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }
    //private string _PersistentProperty;
    //[XafDisplayName("My display name"), ToolTip("My hint message")]
    //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
    //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
    //public string PersistentProperty {
    //    get { return _PersistentProperty; }
    //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
    //}

    //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
    //public void ActionMethod() {
    //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    //    this.PersistentProperty = "Paid";
    //}



    string email;
    string phoneNumber;
    string address;
    string name;

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Name
    {
      get => name;
      set => SetPropertyValue(nameof(Name), ref name, value);
    }


    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Address
    {
      get => address;
      set => SetPropertyValue(nameof(Address), ref address, value);
    }


    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string PhoneNumber
    {
      get => phoneNumber;
      set => SetPropertyValue(nameof(PhoneNumber), ref phoneNumber, value);
    }

    
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Email
    {
      get => email;
      set => SetPropertyValue(nameof(Email), ref email, value);
    }

  }
}