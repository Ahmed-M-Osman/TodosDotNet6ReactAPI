using System.ComponentModel.DataAnnotations;

namespace TodosAPIReact.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Reminder { get; set; }
    }
}
