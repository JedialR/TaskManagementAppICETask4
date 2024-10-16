using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Deadline is required.")]
        public DateTime Deadline { get; set; }
    }
}
