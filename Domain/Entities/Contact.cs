using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public class Contact:BaseEntity
{
   
=======
public class Contact : BaseEntity
{
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
public class Contact : BaseEntity
{
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public string ContactName { get; set; } = null!;

    public string ContactLastName { get; set; } = null!;

    public string ContactNumbrer { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
<<<<<<< HEAD
<<<<<<< HEAD

    public virtual ICollection<TypeContact> TypeContacts { get; set; } = new List<TypeContact>();
=======
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
}
