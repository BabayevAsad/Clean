using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Base;
using Domain.Books;

namespace Domain.People;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public DateTime BirthDate { get; set; }
    public int GenderId { get; set; }
    public string FinNumber { get; set; }	
}