using eBiblioteka.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Interfaces
{
    public interface IClanService: ICRUDService<Model.Clan,ClanSearchRequest,ClanInsertRequest, ClanUpdateRequest>
    {
        Task<Model.Clan> Authenticate(AuthenticationRequest request);

        Task<Model.Clan> UpdatePhoto(int ClanId, ClanUpdatePhotoRequest request);
        Task<bool> Delete(int id);
        Task<bool> UpdatePassword(int id, ClanUpdatePasswordRequest request);
        Task<Model.ClanCounter> GetCounter(int id);


    }
}
