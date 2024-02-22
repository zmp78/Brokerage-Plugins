using Brokerage_Plugins.Repositories.Resources;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Models
{
    public enum CaseOrigin
    {
        Phone = 1,
        Email = 2,
        Web = 3
    }
    public enum CaseType
    {
        Request = 1,
        Question = 2,
        SuggestionsOrCritics = 3,
        Complaint = 4,
        Problem = 5
    }
    public enum CaseStatus
    {
        Active = 0,
        Resolved = 1,
        Canceled = 2
    }
    public enum CaseStatusReason
    {
        InProgress = 1,
        OnHold = 2,
        WaitingForDetails = 3,
        Researching = 4,
        ProblemSolved = 5,
        Canceled = 6
    }
    [EntityLogicalName("incident")]
    internal class Case : Entity
    {
        public Case()
        {
            this.LogicalName = PluginResource.Case_LogicalName;
        }
        public Money RequestAmount
        {
            get => this.GetAttributeValue<Money>(PluginResource.Case_RequestAmount);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_RequestAmount, value);
            }
        }
        public Money ApprovedAmount
        {
            get => this.GetAttributeValue<Money>(PluginResource.Case_ApprovedAmount);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_ApprovedAmount, value);
            }
        }
        public EntityReference Symbol
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Case_Symbol);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_Symbol, value);
            }
        }
        public EntityReference Customer
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Case_Customer);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_Customer, value);
            }
        }
        public OptionSetValue CaseType
        {
            get => this.GetAttributeValue<OptionSetValue>(PluginResource.Case_CaseType);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_CaseType, value);
            }
        }
        public EntityReference CaseCategory
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Case_CaseCategory);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_CaseCategory, value);
            }
        }
        public EntityReference CaseSubCategory
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Case_CaseSubCategory);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_CaseSubCategory, value);
            }
        }
        public DateTime CreateOn
        {
            get => this.GetAttributeValue<DateTime>(PluginResource.CreateOn);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.CreateOn, value);
            }
        }
        public string CaseNumber
        {
            get => this.GetAttributeValue<string>(PluginResource.Case_CaseNumber);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_CaseNumber, value);
            }
        }
        public EntityReference Owner
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Case_Owner);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Case_Owner, value);
            }
        }
    }
}
