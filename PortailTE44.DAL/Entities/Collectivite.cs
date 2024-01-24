﻿namespace PortailTE44.DAL.Entities
{
    public class Collectivite : BaseEntity
    {
        public string Libelle { get; set; } = default!;
        public string SydenetId { get; set; } = default!;
        public string CodeInsee { get; set; } = default!;
        public string Siret { get; set; } = default!;
        public bool CommunauteCommune { get; set; } = default!;
    }
}
