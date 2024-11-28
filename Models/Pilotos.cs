﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AreolineaAPI.Models;

public partial class Pilotos
{
    [Key]
    public int ID_Piloto { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string Codigo { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Nombre { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Apellido { get; set; }

    public bool? Sexo { get; set; }

    public double? Horas_vuelo { get; set; }

    public bool? Disponibilidad { get; set; }

    [InverseProperty("Piloto")]
    public virtual ICollection<Vuelos> Vuelos { get; set; } = new List<Vuelos>();
}