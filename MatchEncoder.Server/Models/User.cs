using System.ComponentModel.DataAnnotations.Schema;

[Table("User")]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string password { get; set; }
    public bool IsAdmin { get; set; }

}
