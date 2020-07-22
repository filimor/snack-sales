using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SnackSales.Models
{
    public class Order
    {
        [BindNever] public int Id { get; set; }

        public List<OrderItem> OrdemItems { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        [Display(Name = "Sobrenome")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [Display(Name = "Endereço")]
        [StringLength(100)]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Informe o complemento")]
        [Display(Name = "Complemento")]
        [StringLength(100)]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP")]
        [StringLength(9, MinimumLength = 8)]
        public string ZipCode { get; set; }

        [Display(Name = "Estado")]
        [StringLength(10)]
        public string State { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Informe o telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Informe o telefone")]
        [StringLength(80)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^ ([\w\.\-] +)@([\w\-] +)((\.(\w){2, 3})+)$", ErrorMessage = "Digite um e-mail válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [BindNever] [ScaffoldColumn(false)] public decimal TotalValue { get; set; }

        [BindNever] [ScaffoldColumn(false)] public DateTime ShipmentDate { get; set; }
    }
}