using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public  class Employee :BaseEntity
{
    
    public int EmployeeCode { get; set; }
=======
public partial class Employee : BaseEntity
{
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public string FirstName { get; set; } = null!;

    public string LastName1 { get; set; } = null!;

<<<<<<< HEAD
    public string? LastName2 { get; set; }
=======
    public string LastName2 { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public string Extension { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string OfficeCode { get; set; } = null!;

    public int IdBossFk { get; set; }

<<<<<<< HEAD
    public string? Position { get; set; }
=======
    public string Position { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Boss IdBossFkNavigation { get; set; } = null!;

    public virtual Office OfficeCodeNavigation { get; set; } = null!;
}
