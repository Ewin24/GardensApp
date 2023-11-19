using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public class Contact:BaseEntity
{
   
=======
public class Contact : BaseEntity
{
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public string ContactName { get; set; } = null!;

    public string ContactLastName { get; set; } = null!;

    public string ContactNumbrer { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
<<<<<<< HEAD

    public virtual ICollection<TypeContact> TypeContacts { get; set; } = new List<TypeContact>();
=======
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
}
