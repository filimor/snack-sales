using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SnackSales.Models
{
    public class Order
    {
        public int Id { get; set; }

        public List<OrderItem> OrderItems { get; set; }

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
        [RegularExpression(
            @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Digite um e-mail válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [BindNever] [ScaffoldColumn(false)] public decimal TotalValue { get; set; }

        [Display(Name = "Data/Hora de recebimento do pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShipmentDate { get; set; }

        [Display(Name = "Data/Hora da entrega")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DeliveryDate { get; set; }
    }
}