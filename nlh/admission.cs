//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nlh
{
    using System;
    using System.Collections.Generic;
    
    public partial class admission
    {
        public int idAdmission { get; set; }
        public Nullable<bool> chirurgieProg { get; set; }
        public Nullable<System.DateTime> dateAdmission { get; set; }
        public Nullable<System.DateTime> dateChirurgie { get; set; }
        public Nullable<System.DateTime> dateConge { get; set; }
        public Nullable<bool> televiseur { get; set; }
        public Nullable<bool> telephone { get; set; }
        public Nullable<bool> prixReduit { get; set; }
        public Nullable<int> nss { get; set; }
        public Nullable<int> noLit { get; set; }
        public string idMedecin { get; set; }
    
        public virtual Medecin Medecin { get; set; }
        public virtual Lit Lit { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
