//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class VALIDATION
    {
        public string ID_ETUD { get; set; }
        public string ID_MOD { get; set; }
        public string VALIDATION1 { get; set; }
        public Nullable<decimal> NOTE_FINAL { get; set; }
    
        public virtual ETUDIANT ETUDIANT { get; set; }
        public virtual MODULE MODULE { get; set; }
    }
}