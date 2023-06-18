using System.ComponentModel.DataAnnotations;

namespace Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Gender { get; set; }
    public string Role { get; set; }
}