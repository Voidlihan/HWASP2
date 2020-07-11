using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_HW2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Display(Name = "Оценка")]
        [Range(1, 5, ErrorMessage = "Недоступная оценка")]
        public double Mark { get; set; }
        public Course Course { get; set; }
    }
}