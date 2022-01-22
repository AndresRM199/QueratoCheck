using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace QueratoCheck.Model
{
    public class Information
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Enfermedad { get; set; }
        public string Fecha { get; set; }
        public string Ant { get; set; }
        public string Post { get; set; }
        public string Kmax { get; set; }
        public string Kmin { get; set; }
        public string Mean { get; set; }
        public string Sim { get; set; }
        public string Astig { get; set; }
        public string Thin { get; set; }
        public string resultado { get; set; }
        public DateTime Date { get; set; }
    }
}
