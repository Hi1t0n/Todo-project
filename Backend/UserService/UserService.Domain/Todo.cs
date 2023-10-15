using System.ComponentModel.DataAnnotations;

namespace UserService.Domain;

public class Todo
{
    [Key]

    public long Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public DateTime CreatedDate { get; set; } = DateTime.Today;

    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1);

    public long UserId { get; set; }


}