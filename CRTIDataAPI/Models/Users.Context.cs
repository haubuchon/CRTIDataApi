﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRTIDataAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TimeMasterEntities : DbContext
    {
        public TimeMasterEntities()
            : base("name=TimeMasterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int sp_AddNewUser(string uSERID, string uSERNAME, string pASSWORD, string eMAIL, Nullable<bool> iSADMIN)
        {
            var uSERIDParameter = uSERID != null ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(string));
    
            var uSERNAMEParameter = uSERNAME != null ?
                new ObjectParameter("USERNAME", uSERNAME) :
                new ObjectParameter("USERNAME", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var iSADMINParameter = iSADMIN.HasValue ?
                new ObjectParameter("ISADMIN", iSADMIN) :
                new ObjectParameter("ISADMIN", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddNewUser", uSERIDParameter, uSERNAMEParameter, pASSWORDParameter, eMAILParameter, iSADMINParameter);
        }
    
        public virtual int sp_GetUser(string uSERID)
        {
            var uSERIDParameter = uSERID != null ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetUser", uSERIDParameter);
        }
    
        public virtual int sp_UpdateUser(string uSERID, string uSERNAME, string pASSWORD, string eMAIL, Nullable<bool> iSADMIN)
        {
            var uSERIDParameter = uSERID != null ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(string));
    
            var uSERNAMEParameter = uSERNAME != null ?
                new ObjectParameter("USERNAME", uSERNAME) :
                new ObjectParameter("USERNAME", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var iSADMINParameter = iSADMIN.HasValue ?
                new ObjectParameter("ISADMIN", iSADMIN) :
                new ObjectParameter("ISADMIN", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateUser", uSERIDParameter, uSERNAMEParameter, pASSWORDParameter, eMAILParameter, iSADMINParameter);
        }
    
        public virtual ObjectResult<sp_GetUser_Result> sp_GetUser1(string uSERID)
        {
            var uSERIDParameter = uSERID != null ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUser_Result>("sp_GetUser1", uSERIDParameter);
        }
    }
}
