﻿namespace CompanyPost.Domain.Entities;
public class Contracts : BaseEntity
{
	public string Value { get; set; } = string.Empty;
	public string Details { get; set; } = string.Empty;
	public string ContractNumber { get; set; } = string.Empty;
	public string? Notes { get; set; }
	public string Attachments { get; set; } = string.Empty;	
	public DateTime Contract_Date { get; set; }
	public string working { get; set; } = string.Empty;
	public string purchase_order_ref { get; set; } = string.Empty;
	public Guid ProjectId { get; set; }
	public Projects Projects { get; set; } = null!;
	public Guid PersonOrgId { get; set; } 
	public PersonOrg PersonOrgs { get; set; } = null!;
	//public ContractStatus Status { get; set; }
	public Currency Currency { get; set; }
	public Guid CreatedById { get; set; }
	public SysUsers CreatedBy { get; set; } = null!;
}