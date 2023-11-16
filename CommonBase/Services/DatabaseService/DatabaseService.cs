using Blazored.SessionStorage;
using CommonBase.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Supabase.Functions;

namespace CommonBase.Services.DatabaseService
{
    public class DatabaseService
    {
        private readonly Supabase.Client _client;
        private readonly AuthenticationStateProvider _customAuthStateProvider;
        private readonly ISessionStorageService _localStorage;
        private readonly ILogger<DatabaseService> _logger;
       

        public DatabaseService(
            Supabase.Client client,
            AuthenticationStateProvider customAuthStateProvider,
            ISessionStorageService localStorage,
            ILogger<DatabaseService> logger
            )
        {
            logger.LogInformation("------------------- CONSTRUCTOR -------------------");

            _client = client;
            _customAuthStateProvider = customAuthStateProvider;
            _localStorage = localStorage;
            _logger = logger;
           
        }

        public async Task<IReadOnlyList<TModel>> From<TModel>() where TModel : BaseModelApp, new()
        {
            var modeledResponse = await _client
                .From<TModel>()
                .Get();
            return modeledResponse.Models;
        }

        public async Task<List<TModel>> Delete<TModel>(TModel item) where TModel : BaseModelApp, new()
        {
            var modeledResponse = await _client
                .From<TModel>()
                .Delete(item);
            return modeledResponse.Models;
        }

        public async Task<List<TModel>?> Insert<TModel>(TModel item) where TModel : BaseModelApp, new()
        {
            Postgrest.Responses.ModeledResponse<TModel> modeledResponse;
            try
            {
                modeledResponse = await _client
                    .From<TModel>()
                    .Insert(item);

                return modeledResponse.Models;
            }
            catch (Exception  ex)
            {
                return null;
            }

            return null;
        }

        public async Task<List<TModel>?> Update<TModel>(TModel item) where TModel : BaseModelApp, new()
        {
            Postgrest.Responses.ModeledResponse<TModel> modeledResponse;
            try
            {
                modeledResponse = await _client
                    .From<TModel>()
                    .Upsert(item);

                return modeledResponse.Models;
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }


    }
}
